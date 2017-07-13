using MsCrmTools.UserSettingsUtility.AppCode;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CrmEarlyBound;
using Microsoft.Xrm.Sdk;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;
using UserSettings = CrmEarlyBound.UserSettings.Fields;

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
            userSelector1.Service = Service;
            userSelector1.LoadViews();
            LoadSettings();
        }

        private void LoadSettings()
        {
            cbbSiteMapArea.Items.Clear();
            cbbSiteMapSubArea.Items.Clear();
            cbbTimeZones.Items.Clear();

            var ush = new UserSettingsHelper(Service, ConnectionDetail);
            var smm = new SiteMapManager(Service);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Initializing...",
                AsyncArgument = null,
                Work = (bw, e) =>
                {
                    var sc = new SettingsCollection();

                    bw.ReportProgress(0, "Loading Available languages...");
                    sc.Languages = ush.RetrieveAvailableLanguages();

                    bw.ReportProgress(0, "Loading Currencies...");
                    sc.Currencies = ush.RetrieveCurrencies();

                    bw.ReportProgress(0, "Loading Time Zones...");
                    sc.TimeZones = ush.RetrieveTimeZones();

                    bw.ReportProgress(0, "Loading SiteMap elements...");
                    areas = smm.GetAreaList();
                    subAreas = smm.GetSubAreaList();

                    bw.ReportProgress(0, "Loading Dashboards...");
                    sc.Dashboards = ush.RetrieveDashboards();

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
                        cbbDefaultDashboard.Items.Clear();
                        cbbFormat.Items.Clear();

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
                        cbbCurrencies.DisplayMember = "Name";
                        foreach (var c in sc.Currencies)
                        {
                            var currency = c.ToEntityReference();
                            currency.Name = c.GetAttributeValue<string>("currencyname");
                            cbbCurrencies.Items.Add(currency);
                        }

                        // SiteMap
                        cbbSiteMapArea.Items.Add("No change");
                        cbbSiteMapArea.Items.AddRange(areas.ToArray());
                        cbbSiteMapSubArea.Items.Add("No change");
                        cbbSiteMapSubArea.Items.AddRange(subAreas.Select(t => t.Item1).ToArray());
                        cbbSiteMapSubArea.Enabled = false;

                        cbbDefaultDashboard.Items.Add("No change");
                        cbbDefaultDashboard.DisplayMember = "Name";
                        foreach (var d in sc.Dashboards)
                        {
                            var dashboard = d.ToEntityReference();
                            dashboard.Name = d.GetAttributeValue<string>("name");
                            cbbDefaultDashboard.Items.Add(dashboard);
                        }

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
                        cbbFormat.Items.Add("No change");
                        cbbFormat.DisplayMember = "NativeName";
                        cbbFormat.Items.AddRange(CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures)
                            .Where(x => !x.IsNeutralCulture && x.LCID != 127)
                            .OrderBy(ci => ci.DisplayName)
                            .ToArray());
                        cbbFormat.SelectedIndex = 0;
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

            var setting = new Entity()
            {
                Attributes =
                {
                    {UserSettings.AdvancedFindStartupMode, cbbAdvancedFindMode.SelectedIndex},
                    {UserSettings.AutoCreateContactOnPromote, cbbCreateRecords.SelectedIndex - 1},
                    {UserSettings.DefaultCalendarView, cbbCalendar.SelectedIndex - 1},
                    {UserSettings.IncomingEmailFilteringMethod, new OptionSetValue(cbbTrackMessages.SelectedIndex - 1)},
                    {UserSettings.ReportScriptErrors, new OptionSetValue(cbbReportScriptErrors.SelectedIndex)},
                    {UserSettings.HomepageArea, cbbSiteMapArea.SelectedItem.ToString()},
                    {UserSettings.HomepageSubarea, cbbSiteMapSubArea.SelectedItem.ToString()}
                }
            };

            if (cbbSendAsAllowed.SelectedIndex != 0)
            {
                setting[UserSettings.IsSendAsAllowed] = cbbSendAsAllowed.SelectedIndex == 2;
            }

            if (cbbPagingLimit.SelectedIndex != 0)
            {
                setting[UserSettings.PagingLimit] = int.Parse(cbbPagingLimit.SelectedItem.ToString());
            }

            if (cbbTimeZones.SelectedIndex != 0)
            {
                setting[UserSettings.TimeZoneCode] = ((AppCode.TimeZone)cbbTimeZones.SelectedItem).Code;
            }

            if (cbbWorkStartTime.SelectedIndex != 0 || cbbWorkStartTime.SelectedText != null)
            {
                setting[UserSettings.WorkdayStartTime] = cbbWorkStartTime.SelectedItem.ToString();
                if (cbbWorkStartTime.SelectedIndex == 0)
                {
                    setting[UserSettings.WorkdayStartTime] = cbbWorkStartTime.SelectedText;
                }
            }

            if (cbbWorkStopTime.SelectedIndex != 0 || cbbWorkStopTime.SelectedText != null)
            {
                setting[UserSettings.WorkdayStopTime] = cbbWorkStopTime.SelectedItem.ToString();
                if (cbbWorkStopTime.SelectedIndex == 0)
                {
                    setting[UserSettings.WorkdayStopTime] = cbbWorkStopTime.SelectedText;
                }
            }

            if (cbbHelpLanguage.SelectedIndex != 0)
            {
                setting[UserSettings.HelpLanguageId] = ((Language)cbbHelpLanguage.SelectedItem).Lcid;
            }

            if (cbbUiLanguage.SelectedIndex != 0)
            {
                setting[UserSettings.UILanguageId] = ((Language)cbbUiLanguage.SelectedItem).Lcid;
            }

            if (cbbCurrencies.SelectedIndex != 0)
            {
                setting[UserSettings.TransactionCurrencyId] = (EntityReference)cbbCurrencies.SelectedItem; ;
            }

            if (cbbStartupPane.SelectedIndex != 0)
            {
                setting[UserSettings.GetStartedPaneContentEnabled] = cbbStartupPane.SelectedIndex == 2;
            }

            if (cbbUseCrmFormAppt.SelectedIndex != 0)
            {
                setting[UserSettings.UseCrmFormForAppointment] = cbbUseCrmFormAppt.SelectedIndex == 2;
            }

            if (cbbUseCrmFormContact.SelectedIndex != 0)
            {
                setting[UserSettings.UseCrmFormForContact] = cbbUseCrmFormContact.SelectedIndex == 2;
            }

            if (cbbUseCrmFormEmail.SelectedIndex != 0)
            {
                setting[UserSettings.UseCrmFormForEmail] = cbbUseCrmFormEmail.SelectedIndex == 2;
            }

            if (cbbUseCrmFormTask.SelectedIndex != 0)
            {
                setting[UserSettings.UseCrmFormForTask] = cbbUseCrmFormTask.SelectedIndex == 2;
            }
            if (cbbDefaultDashboard.SelectedIndex != 0)
            {
                var dashboard = (EntityReference)cbbDefaultDashboard.SelectedItem;
                setting[UserSettings.DefaultDashboardId] = dashboard.Id;
            }
            if(cbbFormat.SelectedIndex != 0)
            {
                setting[UserSettings.LocaleId] = ((CultureInfo) cbbFormat.SelectedItem).LCID;
            }
            #endregion Initialisation des données à mettre à jour

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Initializing update...",
                AsyncArgument = new Tuple<List<Entity>,Entity>(userSelector1.SelectedItems, setting),
                Work = (bw, evt) =>
                {
                    var updateUserSettings = (Tuple<List<Entity>, Entity>)evt.Argument;
                    var ush = new UserSettingsHelper(Service, ConnectionDetail);

                    foreach (var updateUserSetting in updateUserSettings.Item1)
                    {
                        bw.ReportProgress(0, "Updating settings for user " + updateUserSetting.GetAttributeValue<string>("fullname"));
                        ush.UpdateSettings(updateUserSetting.Id, updateUserSettings.Item2);
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

        public void LoadCurrentUserSetting(Entity settings)
        {
            cbbSiteMapArea.SelectedItem = settings.GetAttributeValue<string>(UserSettings.HomepageArea);
            cbbSiteMapSubArea.SelectedItem = settings.GetAttributeValue<string>(UserSettings.HomepageSubarea);
            if (settings.GetAttributeValue<int?>(UserSettings.AdvancedFindStartupMode) != null)
                cbbAdvancedFindMode.SelectedIndex = settings.GetAttributeValue<int?>(UserSettings.AdvancedFindStartupMode).Value;
            cbbCreateRecords.SelectedIndex = settings.GetAttributeValue<int?>(UserSettings.AutoCreateContactOnPromote).Value + 1;
            cbbCalendar.SelectedIndex = settings.GetAttributeValue<int?>(UserSettings.DefaultCalendarView).Value + 1;
            cbbTrackMessages.SelectedIndex = settings.GetAttributeValue<OptionSetValue>(UserSettings.IncomingEmailFilteringMethod).Value + 1;
            cbbReportScriptErrors.SelectedIndex = settings.GetAttributeValue<OptionSetValue>(UserSettings.ReportScriptErrors).Value;
            cbbSendAsAllowed.SelectedIndex = settings.GetAttributeValue<bool?>(UserSettings.IsSendAsAllowed).HasValue && settings.GetAttributeValue<bool?>(UserSettings.IsSendAsAllowed).Value
                ? 2
                : 0;
            if (settings.GetAttributeValue<int>(UserSettings.PagingLimit) != 0)
            {
                cbbPagingLimit.SelectedItem = settings.GetAttributeValue<int>(UserSettings.PagingLimit).ToString();
            }
            else
            {
                cbbPagingLimit.SelectedIndex = 0;
            }
            if (settings.GetAttributeValue<int>(UserSettings.TimeZoneCode) != 0)
            {
                cbbTimeZones.SelectedItem = cbbTimeZones.Items.Cast<AppCode.TimeZone>().Single(x => x.Code == settings.GetAttributeValue<int>(UserSettings.TimeZoneCode));
            }
            else
            {
                cbbTimeZones.SelectedIndex = 0;
            }
            if (!string.IsNullOrEmpty(settings.GetAttributeValue<string>(UserSettings.WorkdayStartTime)))
            {
                cbbWorkStartTime.SelectedItem = settings.GetAttributeValue<string>(UserSettings.WorkdayStartTime);
            }
            else
            {
                cbbWorkStartTime.SelectedIndex = 0;
            }
            if (!string.IsNullOrEmpty(settings.GetAttributeValue<string>(UserSettings.WorkdayStopTime)))
            {
                cbbWorkStopTime.SelectedItem = settings.GetAttributeValue<string>(UserSettings.WorkdayStopTime);
            }
            else
            {
                cbbWorkStopTime.SelectedIndex = 0;
            }
            if (settings.GetAttributeValue<int>(UserSettings.HelpLanguageId) != 0)
            {
                cbbHelpLanguage.SelectedItem = cbbHelpLanguage.Items
                    .Cast<object>()
                    .Skip(1)
                    .Single(x => ((Language)x).Lcid == settings.GetAttributeValue<int>(UserSettings.HelpLanguageId));
            }
            else
            {
                cbbHelpLanguage.SelectedIndex = 0;
            }
            if (settings.GetAttributeValue<int>(UserSettings.UILanguageId) != 0)
            {
                cbbUiLanguage.SelectedItem = cbbUiLanguage.Items
                    .Cast<object>()
                    .Skip(1)
                    .Single(x => ((Language)x).Lcid == settings.GetAttributeValue<int>(UserSettings.UILanguageId));
            }
            else
            {
                cbbUiLanguage.SelectedIndex = 0;
            }
            if (settings.GetAttributeValue<EntityReference>(UserSettings.TransactionCurrencyId) != null)
            {
                cbbCurrencies.SelectedItem = cbbCurrencies.Items
                    .Cast<object>()
                    .Skip(1)
                    .Single(x => ((EntityReference) x).Id == settings.GetAttributeValue<EntityReference>(UserSettings.TransactionCurrencyId).Id);
            }
            else
            {
                cbbCurrencies.SelectedIndex = 0;
            }
            cbbStartupPane.SelectedIndex = settings.GetAttributeValue<bool?>(UserSettings.GetStartedPaneContentEnabled).HasValue 
                && settings.GetAttributeValue<bool?>(UserSettings.GetStartedPaneContentEnabled).Value
                ? 2
                : 0;
            cbbUseCrmFormAppt.SelectedIndex = settings.GetAttributeValue<bool?>(UserSettings.UseCrmFormForAppointment).HasValue &&
                                              settings.GetAttributeValue<bool?>(UserSettings.UseCrmFormForAppointment).Value
                ? 2
                : 0;
            cbbUseCrmFormContact.SelectedIndex = settings.GetAttributeValue<bool?>(UserSettings.UseCrmFormForContact).HasValue &&
                                                 settings.GetAttributeValue<bool?>(UserSettings.UseCrmFormForContact).Value
                ? 2
                : 0;
            cbbUseCrmFormEmail.SelectedIndex = settings.GetAttributeValue<bool?>(UserSettings.UseCrmFormForEmail).HasValue 
                && settings.GetAttributeValue<bool?>(UserSettings.UseCrmFormForEmail).Value
                ? 2
                : 0;
            cbbUseCrmFormTask.SelectedIndex = settings.GetAttributeValue<bool?>(UserSettings.UseCrmFormForTask).HasValue 
                && settings.GetAttributeValue<bool?>(UserSettings.UseCrmFormForTask).Value
                ? 2
                : 0;
            if (settings.GetAttributeValue<Guid?>(UserSettings.DefaultDashboardId).HasValue)
            {
                var defaultSystemDashboardId = cbbDefaultDashboard.Items.Cast<object>()
                    .Skip(1)
                    .SingleOrDefault(x => ((EntityReference) x).Id ==
                                 settings.GetAttributeValue<Guid?>(UserSettings.DefaultDashboardId));
                cbbDefaultDashboard.SelectedItem = defaultSystemDashboardId ?? 0;
            }
            else
            {
                cbbDefaultDashboard.SelectedIndex = 0;
            }
            cbbFormat.SelectedItem = cbbFormat.Items.Cast<object>()
                .Skip(1)
                .Single(c => ((CultureInfo)c).LCID == settings.GetAttributeValue<int>(UserSettings.LocaleId));
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
            cbbDefaultDashboard.SelectedIndex = 0;
            cbbFormat.SelectedIndex = 0;
            txtLongDateFormat.Text = "";
            txtCurrencyFormat.Text = "";
            txtNumberFormat.Text = "";
            txtShortDateFormat.Text = "";
            txtTimeFormat.Text = "";
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

        private void cbbFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbFormat.SelectedIndex == 0) return;

            var selectedCulture = (CultureInfo) cbbFormat.SelectedItem;
            var currentTime = DateTime.Now;
            txtNumberFormat.Text = 123456789.ToString("f", selectedCulture);
            txtCurrencyFormat.Text = 123456789.ToString("c", selectedCulture);
            txtTimeFormat.Text = currentTime.ToString(selectedCulture.DateTimeFormat.ShortTimePattern);
            txtShortDateFormat.Text = currentTime.ToString(selectedCulture.DateTimeFormat.ShortDatePattern);
            txtLongDateFormat.Text = currentTime.ToString(selectedCulture.DateTimeFormat.LongDatePattern);
        }
    }
}