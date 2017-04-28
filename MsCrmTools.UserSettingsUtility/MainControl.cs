using MsCrmTools.UserSettingsUtility.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace MsCrmTools.UserSettingsUtility
{
    public partial class MainControl : PluginControlBase, IGitHubPlugin, IHelpPlugin, IMessageBusHost
    {
        private List<string> areas;
        private List<Tuple<string, string>> subAreas;
        const string ACTIVE_USERS_FETCH = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' ><entity name='systemuser' ><attribute name='fullname' /><order attribute='fullname' descending='false' /><attribute name='businessunitid' /><attribute name='siteid' /><filter type='and' ><condition attribute='isdisabled' operator='eq' value='0' /><condition attribute='accessmode' operator='ne' value='3' /></filter><attribute name='systemuserid' /></entity></fetch>";

        public MainControl()
        {
            InitializeComponent();
        }

        private void cbbSiteMapArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbSiteMapSubArea.Enabled = cbbSiteMapArea.SelectedIndex != 0;
            cbbSiteMapSubArea.Items.Clear();
            cbbSiteMapSubArea.Items.Add("No change");
            cbbSiteMapSubArea.Items.AddRange(subAreas.Where(t => t.Item2 == cbbSiteMapArea.SelectedItem.ToString()).Select(t => t.Item1).ToArray());
            cbbSiteMapSubArea.SelectedIndex = 0;
        }

        private void LoadCrmItems()
        {
            userSelector1.LoadViews();
            LoadSettings();
        }

        private void LoadSettings()
        {
            cbbSiteMapArea.Items.Clear();
            cbbSiteMapSubArea.Items.Clear();
            cbbTimeZones.Items.Clear();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Initializing...",
                AsyncArgument = null,
                Work = (bw, e) =>
                {
                    var sc = new SettingsCollection();

                    bw.ReportProgress(0, "Loading Available languages...");
                    var ush = new UserSettingsHelper(Service, ConnectionDetail);
                    sc.Languages = ush.RetrieveAvailableLanguages();

                    bw.ReportProgress(0, "Loading Currencies...");
                    ush = new UserSettingsHelper(Service, ConnectionDetail);
                    sc.Currencies = ush.RetrieveCurrencies();

                    bw.ReportProgress(0, "Loading Time Zones...");
                    ush = new UserSettingsHelper(Service, ConnectionDetail);
                    sc.TimeZones = ush.RetrieveTimeZones();

                    bw.ReportProgress(0, "Loading SiteMap elements...");
                    var smm = new SiteMapManager(Service);
                    areas = smm.GetAreaList();
                    subAreas = smm.GetSubAreaList();

                    e.Result = sc;
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        MessageBox.Show(this, "An error occured: " + e.Error.Message, "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        cbbTimeZones.Items.Clear();
                        cbbHelpLanguage.Items.Clear();
                        cbbUiLanguage.Items.Clear();
                        cbbSiteMapArea.Items.Clear();
                        cbbSiteMapSubArea.Items.Clear();
                        cbbCurrencies.Items.Clear();

                        var sc = (SettingsCollection) e.Result;

                        // TimeZones
                        cbbTimeZones.Items.Add(new AppCode.TimeZone
                        {
                            Code = -1,
                            Name = "No change"
                        });
                        cbbTimeZones.Items.AddRange(
                            sc.TimeZones.Entities.ToList()
                                .Select(
                                    t =>
                                        new AppCode.TimeZone
                                        {
                                            Code = t.GetAttributeValue<int>("timezonecode"),
                                            Name = t.GetAttributeValue<string>("userinterfacename")
                                        })
                                .Cast<object>()
                                .ToArray());
                        cbbTimeZones.SelectedIndex = 0;

                        // Language
                        cbbHelpLanguage.Items.Add("No change");
                        cbbHelpLanguage.Items.AddRange(sc.Languages.ToArray());
                        cbbUiLanguage.Items.Add("No change");
                        cbbUiLanguage.Items.AddRange(sc.Languages.ToArray());

                        // Currencies
                        cbbCurrencies.Items.Add("No change");
                        cbbCurrencies.Items.AddRange(sc.Currencies.ToArray());

                        // SiteMap
                        cbbSiteMapArea.Items.Add("No change");
                        cbbSiteMapArea.Items.AddRange(areas.ToArray());
                        cbbSiteMapSubArea.Items.Add("No change");
                        cbbSiteMapSubArea.Items.AddRange(subAreas.Select(t => t.Item1).ToArray());
                        cbbSiteMapSubArea.Enabled = false;

                        foreach (var ctrl in panel1.Controls)
                        {
                            var gb = ctrl as GroupBox;
                            if (gb != null)
                            {
                                foreach (var ctrl2 in gb.Controls)
                                {
                                    var cbb = ctrl2 as ComboBox;
                                    if (cbb != null && cbb.Items.Count > 0)
                                    {
                                        cbb.SelectedIndex = 0;
                                    }
                                }
                            }
                        }

                        panel1.Enabled = true;
                    }
                },
                ProgressChanged = e => { SetWorkingMessage(e.UserState.ToString()); }
            });
        }

        private void TsbCloseClick(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbLoadCrmItems_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadCrmItems);
        }

        private void tsbUpdateUserSettings_Click(object sender, EventArgs e)
        {
            if (userSelector1.SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "No user has been selected!", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            #region Initialisation des données à mettre à jour

            var setting = new UserSettings
            {
                AdvancedFindStartupMode = cbbAdvancedFindMode.SelectedIndex,
                AutoCreateContactOnPromote = cbbCreateRecords.SelectedIndex - 1,
                DefaultCalendarView = cbbCalendar.SelectedIndex - 1,
                IncomingEmailFilteringMethod = cbbTrackMessages.SelectedIndex - 1,
                ReportScriptErrors = cbbReportScriptErrors.SelectedIndex,
                HomePageArea = cbbSiteMapArea.SelectedItem.ToString(),
                HomePageSubArea = cbbSiteMapSubArea.SelectedItem.ToString(),
                UsersToUpdate = userSelector1.SelectedItems,
            };

            if (cbbSendAsAllowed.SelectedIndex != 0)
            {
                setting.IsSendAsAllowed = cbbSendAsAllowed.SelectedIndex == 2;
            }

            if (cbbPagingLimit.SelectedIndex != 0)
            {
                setting.PagingLimit = int.Parse(cbbPagingLimit.SelectedItem.ToString());
            }

            if (cbbTimeZones.SelectedIndex != 0)
            {
                setting.TimeZoneCode = ((AppCode.TimeZone)cbbTimeZones.SelectedItem).Code;
            }

            if (cbbWorkStartTime.SelectedIndex != 0 || cbbWorkStartTime.SelectedText != null)
            {
                setting.WorkdayStartTime = cbbWorkStartTime.SelectedItem.ToString();
                if (cbbWorkStartTime.SelectedIndex == 0)
                {
                    setting.WorkdayStartTime = cbbWorkStartTime.SelectedText;
                }
            }

            if (cbbWorkStopTime.SelectedIndex != 0 || cbbWorkStopTime.SelectedText != null)
            {
                setting.WorkdayStopTime = cbbWorkStopTime.SelectedItem.ToString();
                if (cbbWorkStopTime.SelectedIndex == 0)
                {
                    setting.WorkdayStopTime = cbbWorkStopTime.SelectedText;
                }
            }

            if (cbbHelpLanguage.SelectedIndex != 0)
            {
                setting.HelpLanguage = ((Language)cbbHelpLanguage.SelectedItem).Lcid;
            }

            if (cbbUiLanguage.SelectedIndex != 0)
            {
                setting.UiLanguage = ((Language)cbbUiLanguage.SelectedItem).Lcid;
            }

            if (cbbCurrencies.SelectedIndex != 0)
            {
                setting.Currency = ((Currency)cbbCurrencies.SelectedItem).CurrencyReference;
            }

            if (cbbStartupPane.SelectedIndex != 0)
            {
                setting.StartupPaneEnabled = cbbStartupPane.SelectedIndex == 2;
            }

            if (cbbUseCrmFormAppt.SelectedIndex != 0)
            {
                setting.UseCrmFormForAppointment = cbbUseCrmFormAppt.SelectedIndex == 2;
            }

            if (cbbUseCrmFormContact.SelectedIndex != 0)
            {
                setting.UseCrmFormForContact = cbbUseCrmFormContact.SelectedIndex == 2;
            }

            if (cbbUseCrmFormEmail.SelectedIndex != 0)
            {
                setting.UseCrmFormForEmail = cbbUseCrmFormEmail.SelectedIndex == 2;
            }

            if (cbbUseCrmFormTask.SelectedIndex != 0)
            {
                setting.UseCrmFormForTask = cbbUseCrmFormTask.SelectedIndex == 2;
            }

            #endregion Initialisation des données à mettre à jour

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Initializing update...",
                AsyncArgument = setting,
                Work = (bw, evt) =>
                {
                    var settingArg = (UserSettings)evt.Argument;
                    var ush = new UserSettingsHelper(Service, ConnectionDetail);

                    foreach (var user in settingArg.UsersToUpdate)
                    {
                        bw.ReportProgress(0, "Updating settings for user " + user.GetAttributeValue<string>("fullname"));
                        ush.UpdateSettings(user.Id, setting);
                    }
                },
                PostWorkCallBack = evt =>
                {
                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, "An error occured: " + evt.Error.ToString(), "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                },
                ProgressChanged = evt => { SetWorkingMessage(evt.UserState.ToString()); }
            });
        }

        public void LoadCurrentUserSetting(UserSettings settings)
        {
            cbbSiteMapArea.SelectedItem = settings.HomePageArea;
            cbbSiteMapSubArea.SelectedItem = settings.HomePageSubArea;
            cbbAdvancedFindMode.SelectedIndex = settings.AdvancedFindStartupMode;
            cbbCreateRecords.SelectedIndex = settings.AutoCreateContactOnPromote + 1;
            cbbCalendar.SelectedIndex = settings.DefaultCalendarView + 1;
            cbbTrackMessages.SelectedIndex = settings.IncomingEmailFilteringMethod + 1;
            cbbReportScriptErrors.SelectedIndex = settings.ReportScriptErrors;

            if (settings.IsSendAsAllowed.HasValue && settings.IsSendAsAllowed.Value)
            {
                cbbSendAsAllowed.SelectedIndex = 2;
            }
            if (settings.PagingLimit != 0)
            {
                cbbPagingLimit.SelectedItem = settings.PagingLimit.ToString();
            }
            if (settings.TimeZoneCode != 0)
            {
                cbbTimeZones.SelectedItem = cbbTimeZones.Items.Cast<AppCode.TimeZone>().Single(x => x.Code == settings.TimeZoneCode);
            }
            if (!string.IsNullOrEmpty(settings.WorkdayStartTime))
            {
                cbbWorkStartTime.SelectedItem = settings.WorkdayStartTime;
            }
            if (!string.IsNullOrEmpty(settings.WorkdayStopTime))
            {
                cbbWorkStopTime.SelectedItem = settings.WorkdayStopTime;
            }
            if (settings.HelpLanguage != 0)
            {
                cbbHelpLanguage.SelectedItem = cbbHelpLanguage.Items.Cast<object>().Skip(1).Single(x => ((Language)x).Lcid == settings.HelpLanguage);
            }
            if (settings.UiLanguage != 0)
            {
                cbbUiLanguage.SelectedItem = cbbUiLanguage.Items.Cast<object>().Skip(1).Single(x => ((Language)x).Lcid == settings.UiLanguage);
            }
            if (settings.Currency != null)
            {
                cbbCurrencies.SelectedItem = cbbCurrencies.Items.Cast<object>().Skip(1).Single(x => ((Currency)x).CurrencyReference.Id == settings.Currency.Id);
            }
            if (settings.StartupPaneEnabled.HasValue && settings.StartupPaneEnabled.Value)
            {
                cbbStartupPane.SelectedIndex = 2;
            }
            if (settings.UseCrmFormForAppointment.HasValue && settings.UseCrmFormForAppointment.Value)
            {
                cbbUseCrmFormAppt.SelectedIndex = 2;
            }
            if (settings.UseCrmFormForContact.HasValue && settings.UseCrmFormForContact.Value)
            {
                cbbUseCrmFormContact.SelectedIndex = 2;
            }
            if (settings.UseCrmFormForEmail.HasValue && settings.UseCrmFormForEmail.Value)
            {
                cbbUseCrmFormEmail.SelectedIndex = 2;
            }
            if (settings.UseCrmFormForTask.HasValue && settings.UseCrmFormForTask.Value)
            {
                cbbUseCrmFormTask.SelectedIndex = 2;
            }
        }

        private void tsbReset_Click(object sender, EventArgs e)
        {
            cbbSiteMapArea.SelectedIndex = 0;
            cbbSiteMapSubArea.SelectedIndex = 0;
            cbbAdvancedFindMode.SelectedIndex = 0;
            cbbCreateRecords.SelectedIndex = 0;
            cbbCalendar.SelectedIndex = 0;
            cbbTrackMessages.SelectedIndex = 0;
            cbbReportScriptErrors.SelectedIndex = 0;
            cbbSendAsAllowed.SelectedIndex = 0;
            cbbPagingLimit.SelectedIndex = 0;
            cbbTimeZones.SelectedIndex = 0;
            cbbWorkStartTime.SelectedIndex = 0;
            cbbWorkStopTime.SelectedIndex = 0;
            cbbHelpLanguage.SelectedIndex = 0;
            cbbUiLanguage.SelectedIndex = 0;
            cbbCurrencies.SelectedIndex = 0;
            cbbStartupPane.SelectedIndex = 0;
            cbbUseCrmFormAppt.SelectedIndex = 0;
            cbbUseCrmFormContact.SelectedIndex = 0;
            cbbUseCrmFormEmail.SelectedIndex = 0;
            cbbUseCrmFormTask.SelectedIndex = 0;
        }

        public string RepositoryName => "MsCrmTools.UserSettingsUtility";
        public string UserName => "MscrmTools";
        public string HelpUrl => "https://github.com/MscrmTools/MsCrmTools.UserSettingsUtility/wiki";

        private void tsbEditInFXB_Click(object sender, EventArgs e)
        {
            if (Service != null && userSelector1.Service == null)
            {
                userSelector1.Service = Service;
            }
            if (areas == null || !areas.Any())
            {
                ExecuteMethod(LoadSettings);
            }
            var messageBusEventArgs = new MessageBusEventArgs("FetchXML Builder");
            var fetchXml = (((ComboBox) userSelector1.Controls.Find("cbbViews", true)?[0]).SelectedItem as ViewItem)?.FetchXml;
            messageBusEventArgs.TargetArgument = fetchXml ?? ACTIVE_USERS_FETCH;
            OnOutgoingMessage(this, messageBusEventArgs);
        }

        public void OnIncomingMessage(MessageBusEventArgs message)
        {
            if (message.SourcePlugin == "FetchXML Builder")
            {
                var fetchXml = (string)message.TargetArgument;
                if (Service != null && userSelector1.Service == null)
                {
                    userSelector1.Service = Service;
                }
                userSelector1.PopulateUsers(fetchXml);
            }
        }

        public event EventHandler<MessageBusEventArgs> OnOutgoingMessage;
    }
}