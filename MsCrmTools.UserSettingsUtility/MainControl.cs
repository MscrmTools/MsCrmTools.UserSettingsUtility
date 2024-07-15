﻿using CrmEarlyBound;
using Microsoft.Xrm.Sdk;
using MsCrmTools.UserSettingsUtility.AppCode;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;
using UserSettings = CrmEarlyBound.UserSettings.Fields;

namespace MsCrmTools.UserSettingsUtility
{
    public partial class MainControl : PluginControlBase, IGitHubPlugin, IHelpPlugin, IMessageBusHost
    {
        private const string ACTIVE_USERS_FETCH = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' ><entity name='systemuser' ><attribute name='fullname' /><order attribute='fullname' descending='false' /><attribute name='businessunitid' /><attribute name='siteid' /><filter type='and' ><condition attribute='isdisabled' operator='eq' value='0' /><condition attribute='accessmode' operator='ne' value='3' /></filter><attribute name='systemuserid' /></entity></fetch>";
        private List<string> areas;
        private LogManager log;
        private string sitemapxml = "";
        private SiteMapManager smm;
        private List<Tuple<string, string>> subAreas;

        public MainControl()
        {
            InitializeComponent();

            log = new LogManager(GetType());
        }

        public event EventHandler<MessageBusEventArgs> OnOutgoingMessage;

        public string HelpUrl => "https://github.com/MscrmTools/MsCrmTools.UserSettingsUtility/wiki";

        public string RepositoryName => "MsCrmTools.UserSettingsUtility";

        public string UserName => "MscrmTools";

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
            cbbAutoDataCaptureEnabled.SelectedIndex =
                settings.GetAttributeValue<bool?>(UserSettings.IsAutoDataCaptureEnabled).HasValue &&
                settings.GetAttributeValue<bool?>(UserSettings.IsAutoDataCaptureEnabled).Value
                    ? 2
                    : 0;

            cbbSynchronizeResourceBookingWithOutlook.SelectedIndex =
                settings.GetAttributeValue<bool?>(UserSettings.IsResourceBookingExchangeSyncEnabled).HasValue &&
                settings.GetAttributeValue<bool?>(UserSettings.IsResourceBookingExchangeSyncEnabled).Value
                    ? 2
                    : 0;

            cbbShowWeekNumber.SelectedIndex = settings.GetAttributeValue<bool?>(UserSettings.ShowWeekNumber).HasValue && settings.GetAttributeValue<bool?>(UserSettings.ShowWeekNumber).Value
                ? 2
                : 0;

            if (cbbSearch.Items.Count > 1 && settings.GetAttributeValue<OptionSetValue>(UserSettings.DefaultSearchExperience) != null)
            {
                cbbSearch.SelectedIndex = settings.GetAttributeValue<OptionSetValue>(UserSettings.DefaultSearchExperience).Value + 1;
            }
            else
            {
                cbbSearch.SelectedIndex = 0;
            }

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
                    .Single(x => ((EntityReference)x).Id == settings.GetAttributeValue<EntityReference>(UserSettings.TransactionCurrencyId).Id);
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

            cbbShowEmailsAsConversation.SelectedIndex =
                settings.GetAttributeValue<bool?>(UserSettings.IsEmailConversationViewEnabled).HasValue
                && settings.GetAttributeValue<bool?>(UserSettings.IsEmailConversationViewEnabled).Value
                    ? 2
                    : 0;

            if (settings.GetAttributeValue<Guid?>(UserSettings.DefaultDashboardId).HasValue)
            {
                var defaultSystemDashboardId = cbbDefaultDashboard.Items.Cast<object>()
                    .Skip(1)
                    .SingleOrDefault(x => ((EntityReference)x).Id ==
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

        public void LoadSettings()
        {
            cbbSiteMapArea.Items.Clear();
            cbbSiteMapSubArea.Items.Clear();
            cbbTimeZones.Items.Clear();

            var ush = new UserSettingsHelper(Service, ConnectionDetail);
            smm = new SiteMapManager(Service, ConnectionDetail);

            tsbLoadCrmItems.Enabled = false;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Initializing...",
                AsyncArgument = null,
                Work = (bw, e) =>
                {
                    var sc = new SettingsCollection();
                    if (string.IsNullOrEmpty(sitemapxml))
                    {
                        bw.ReportProgress(0, "Loading SiteMaps...");
                        userSelector1.Service = Service;
                        sc.Apps = smm.GetHomeList();
                        sitemapxml = sc.Apps[0].SiteMapXml;
                    }

                    bw.ReportProgress(0, "Loading users...");
                    userSelector1.Service = Service;
                    sc.Views = userSelector1.LoadViews();

                    bw.ReportProgress(0, "Loading Available languages...");
                    sc.Languages = ush.RetrieveAvailableLanguages();

                    bw.ReportProgress(0, "Loading Currencies...");
                    sc.Currencies = ush.RetrieveCurrencies();

                    bw.ReportProgress(0, "Loading Time Zones...");
                    sc.TimeZones = ush.RetrieveTimeZones();

                    bw.ReportProgress(0, "Loading SiteMap elements...");
                    areas = smm.GetAreaList(sitemapxml);
                    subAreas = smm.GetSubAreaList(sitemapxml);

                    bw.ReportProgress(0, "Loading Dashboards...");
                    sc.Dashboards = ush.RetrieveDashboards();

                    bw.ReportProgress(0, "Loading Environment Settings...");
                    sc.OrgSettings = ush.RetrieveOrgSettings();
                    e.Result = sc;
                },
                PostWorkCallBack = e =>
                {
                    tsbLoadCrmItems.Enabled = true;

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
                        cbbSearch.Items.Clear();

                        var sc = (SettingsCollection)e.Result;

                        // Apps
                        if (sc.Apps != null)
                        {
                            SetHomes(sc.Apps);
                        }

                        // Views
                        if (sc.Views != null)
                        {
                            userSelector1.SetViews(sc.Views);
                        }

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

                        var version = ush.RetrieveVersion();
                        // Default search
                        cbbSearch.Items.Add("No change");
                        if (version.Major >= 9)
                        {
                            cbbSearch.Items.Add("Relevance search");
                            cbbSearch.Items.Add("Categorized search");
                            cbbSearch.Items.Add("Use last search");
                            cbbSearch.Items.Add("Custom search");
                            cbbSearch.Enabled = true;
                        }
                        else
                        {
                            cbbSearch.Enabled = false;
                        }

                        // AutoDataCapture
                        var isDataCaptureEnabled =
                            sc.OrgSettings.GetAttributeValue<bool>(OrganizationSettings.Fields
                                .IsAutoDataCaptureEnabled);
                        cbbAutoDataCaptureEnabled.Enabled = isDataCaptureEnabled &&
                            (version.Major == 8 && version.Minor >= 2 || version.Major >= 9);

                        // Sync Resources booking with Outlook
                        // For now, it's not necessary to have org level setting enabled to change
                        // user setting. Not using the org level settings for now.
                        var isResourceBookingExchangeSyncEnabled =
                            sc.OrgSettings.GetAttributeValue<bool>(OrganizationSettings.Fields
                                .IsResourceBookingExchangeSyncEnabled);
                        cbbSynchronizeResourceBookingWithOutlook.Enabled = //isResourceBookingExchangeSyncEnabled &&
                                                            (version.Major == 8 && version.Minor >= 2 || version.Major >= 9);

                        cbbShowEmailsAsConversation.Enabled =
                            version.Major == 9 && version.Minor >= 1 || version.Major > 9;

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

        internal void SetHomes(List<AppSiteMapItems> scHomes)
        {
            applist.SelectedIndexChanged -= applist_SelectedIndexChanged;
            applist.Items.Clear();
            applist.Items.AddRange(scHomes.OrderBy(s => s.ToString()).ToArray());
            applist.SelectedIndexChanged += applist_SelectedIndexChanged;
            applist.SelectedIndex = 0;
        }

        private void applist_SelectedIndexChanged(object sender, EventArgs e)
        {
            var appsitemapitem = (AppSiteMapItems)applist.SelectedItem;
            if (sitemapxml != appsitemapitem.SiteMapXml)
            {
                sitemapxml = appsitemapitem.SiteMapXml;

                areas = smm.GetAreaList(sitemapxml);
                subAreas = smm.GetSubAreaList(sitemapxml);

                cbbSiteMapArea.Items.Clear();
                cbbSiteMapSubArea.Items.Clear();

                cbbSiteMapArea.Items.Add("No change");
                cbbSiteMapArea.Items.AddRange(areas.ToArray());
                cbbSiteMapArea.SelectedIndex = 0;
                cbbSiteMapSubArea.Items.Add("No change");
                cbbSiteMapSubArea.Items.AddRange(subAreas.Select(t => t.Item1).ToArray());
                cbbSiteMapSubArea.SelectedIndex = 0;
                cbbSiteMapSubArea.Enabled = false;
            }
        }

        private void cbbFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbFormat.SelectedIndex == 0) return;

            var selectedCulture = (CultureInfo)cbbFormat.SelectedItem;
            var currentTime = DateTime.Now;
            txtNumberFormat.Text = 123456789.ToString("n", selectedCulture);
            txtCurrencyFormat.Text = 123456789.ToString("c", selectedCulture);
            txtTimeFormat.Text = currentTime.ToString(selectedCulture.DateTimeFormat.ShortTimePattern);
            txtShortDateFormat.Text = currentTime.ToString(selectedCulture.DateTimeFormat.ShortDatePattern);
            txtLongDateFormat.Text = currentTime.ToString(selectedCulture.DateTimeFormat.LongDatePattern);
        }

        private void cbbSiteMapArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbSiteMapSubArea.Enabled = cbbSiteMapArea.SelectedIndex != 0;
            cbbSiteMapSubArea.Items.Clear();
            cbbSiteMapSubArea.Items.Add("No change");
            cbbSiteMapSubArea.Items.AddRange(subAreas.Where(t => t.Item2 == cbbSiteMapArea.SelectedItem.ToString()).Select(t => t.Item1).ToArray());
            cbbSiteMapSubArea.SelectedIndex = 0;
        }

        private void TsbCloseClick(object sender, EventArgs e)
        {
            CloseTool();
        }

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
            var fetchXml = (((ComboBox)userSelector1.Controls.Find("cbbViews", true)?[0]).SelectedItem as ViewItem)?.FetchXml;
            messageBusEventArgs.TargetArgument = fetchXml ?? ACTIVE_USERS_FETCH;
            OnOutgoingMessage(this, messageBusEventArgs);
        }

        private void tsbLoadCrmItems_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadSettings);
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
            cbbAutoDataCaptureEnabled.SelectedIndex = 0;
            cbbSynchronizeResourceBookingWithOutlook.SelectedIndex = 0;
            cbbShowEmailsAsConversation.SelectedIndex = 0;
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
            cbbSearch.SelectedIndex = 0;
            cbbShowWeekNumber.SelectedIndex = 0;
            txtLongDateFormat.Text = "";
            txtCurrencyFormat.Text = "";
            txtNumberFormat.Text = "";
            txtShortDateFormat.Text = "";
            txtTimeFormat.Text = "";
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
                    {UserSettings.HomepageSubarea, cbbSiteMapSubArea.SelectedItem.ToString()},
                    {UserSettings.DefaultSearchExperience, new OptionSetValue(cbbSearch.SelectedIndex - 1)}
                }
            };

            if (cbbSendAsAllowed.SelectedIndex != 0)
            {
                setting[UserSettings.IsSendAsAllowed] = cbbSendAsAllowed.SelectedIndex == 2;
            }

            if (cbbAutoDataCaptureEnabled.SelectedIndex != 0)
            {
                setting[UserSettings.IsAutoDataCaptureEnabled] = cbbAutoDataCaptureEnabled.SelectedIndex == 2;
            }

            if (cbbSynchronizeResourceBookingWithOutlook.SelectedIndex != 0)
            {
                setting[UserSettings.IsResourceBookingExchangeSyncEnabled] =
                    cbbSynchronizeResourceBookingWithOutlook.SelectedIndex == 2;
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
                setting[UserSettings.TransactionCurrencyId] = (EntityReference)cbbCurrencies.SelectedItem;
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
            if (cbbFormat.SelectedIndex != 0)
            {
                setting[UserSettings.LocaleId] = ((CultureInfo)cbbFormat.SelectedItem).LCID;
            }

            if (cbbShowEmailsAsConversation.SelectedIndex != 0)
            {
                setting[UserSettings.IsEmailConversationViewEnabled] = cbbShowEmailsAsConversation.SelectedIndex == 2;
            }

            if (cbbShowWeekNumber.SelectedIndex != 0)
            {
                setting[UserSettings.ShowWeekNumber] = cbbShowWeekNumber.SelectedIndex == 2;
            }

            #endregion Initialisation des données à mettre à jour

            if (File.Exists(log.FilePath))
            {
                var result = MessageBox.Show(this,
                    @"A log file already exists for this tool. Would you like to overwrite it?", @"Question",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    log.DeleteLog();
                }
            }

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Initializing update...",
                AsyncArgument = new Tuple<List<Entity>, Entity>(userSelector1.SelectedItems, setting),
                Work = (bw, evt) =>
                {
                    var updateUserSettings = (Tuple<List<Entity>, Entity>)evt.Argument;
                    var ush = new UserSettingsHelper(Service, ConnectionDetail);
                    ush.OnResult += (helper, args) =>
                    {
                        if (args.Success)
                        {
                            log.LogInfo($"User {args.UserName} updated successfully");
                        }
                        else
                        {
                            log.LogError($"User {args.UserName} was not updated. Error message: {args.Message}");
                        }
                    };

                    foreach (var updateUserSetting in updateUserSettings.Item1)
                    {
                        string userFullName = updateUserSetting.GetAttributeValue<string>("fullname");
                        bw.ReportProgress(0, "Updating settings for user " + userFullName);
                        ush.UpdateSettings(updateUserSetting.Id, userFullName, updateUserSettings.Item2);
                    }
                },
                PostWorkCallBack = evt =>
                {
                    if (evt.Error != null)
                    {
                        // Don't show as message if the user has just cancelled the operation
                        if (!evt.Error.Message.Contains("UserAbortedException"))
                        {
                            MessageBox.Show(this, $@"An error occured: {evt.Error}", @"Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }

                    var message = "Do you want to open log file?";
                    if (MessageBox.Show(this, message, @"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                        DialogResult.Yes)
                    {
                        log.OpenLog();
                    }
                },
                ProgressChanged = evt => { SetWorkingMessage(evt.UserState.ToString()); }
            });
        }
    }
}