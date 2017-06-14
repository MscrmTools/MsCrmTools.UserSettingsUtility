namespace CrmEarlyBound
{
    public class UserSettings
    {
        public static class Fields
        {
            public const string AddressBookSyncInterval = "addressbooksyncinterval";
            public const string AdvancedFindStartupMode = "advancedfindstartupmode";
            public const string AllowEmailCredentials = "allowemailcredentials";
            public const string AMDesignator = "amdesignator";
            public const string AutoCreateContactOnPromote = "autocreatecontactonpromote";
            public const string BusinessUnitId = "businessunitid";
            public const string CalendarType = "calendartype";
            public const string CreatedBy = "createdby";
            public const string CreatedOn = "createdon";
            public const string CreatedOnBehalfBy = "createdonbehalfby";
            public const string CurrencyDecimalPrecision = "currencydecimalprecision";
            public const string CurrencyFormatCode = "currencyformatcode";
            public const string CurrencySymbol = "currencysymbol";
            public const string DataValidationModeForExportToExcel = "datavalidationmodeforexporttoexcel";
            public const string DateFormatCode = "dateformatcode";
            public const string DateFormatString = "dateformatstring";
            public const string DateSeparator = "dateseparator";
            public const string DecimalSymbol = "decimalsymbol";
            public const string DefaultCalendarView = "defaultcalendarview";
            public const string DefaultCountryCode = "defaultcountrycode";
            public const string DefaultDashboardId = "defaultdashboardid";
            public const string DefaultSearchExperience = "defaultsearchexperience";
            public const string EmailPassword = "emailpassword";
            public const string EmailUsername = "emailusername";
            public const string EntityFormMode = "entityformmode";
            public const string FullNameConventionCode = "fullnameconventioncode";
            public const string GetStartedPaneContentEnabled = "getstartedpanecontentenabled";
            public const string HelpLanguageId = "helplanguageid";
            public const string HomepageArea = "homepagearea";
            public const string HomepageLayout = "homepagelayout";
            public const string HomepageSubarea = "homepagesubarea";
            public const string IgnoreUnsolicitedEmail = "ignoreunsolicitedemail";
            public const string IncomingEmailFilteringMethod = "incomingemailfilteringmethod";
            public const string IsAppsForCrmAlertDismissed = "isappsforcrmalertdismissed";
            public const string IsAutoDataCaptureEnabled = "isautodatacaptureenabled";
            public const string IsDefaultCountryCodeCheckEnabled = "isdefaultcountrycodecheckenabled";

            public const string IsDuplicateDetectionEnabledWhenGoingOnline =
                "isduplicatedetectionenabledwhengoingonline";

            public const string IsGuidedHelpEnabled = "isguidedhelpenabled";
            public const string IsResourceBookingExchangeSyncEnabled = "isresourcebookingexchangesyncenabled";
            public const string IsSendAsAllowed = "issendasallowed";
            public const string LastAlertsViewedTime = "lastalertsviewedtime";
            public const string LocaleId = "localeid";
            public const string LongDateFormatCode = "longdateformatcode";
            public const string ModifiedBy = "modifiedby";
            public const string ModifiedOn = "modifiedon";
            public const string ModifiedOnBehalfBy = "modifiedonbehalfby";
            public const string NegativeCurrencyFormatCode = "negativecurrencyformatcode";
            public const string NegativeFormatCode = "negativeformatcode";
            public const string NextTrackingNumber = "nexttrackingnumber";
            public const string NumberGroupFormat = "numbergroupformat";
            public const string NumberSeparator = "numberseparator";
            public const string OfflineSyncInterval = "offlinesyncinterval";
            public const string OutlookSyncInterval = "outlooksyncinterval";
            public const string PagingLimit = "paginglimit";
            public const string PersonalizationSettings = "personalizationsettings";
            public const string PMDesignator = "pmdesignator";
            public const string PricingDecimalPrecision = "pricingdecimalprecision";
            public const string ReportScriptErrors = "reportscripterrors";
            public const string ResourceBookingExchangeSyncVersion = "resourcebookingexchangesyncversion";
            public const string ShowWeekNumber = "showweeknumber";
            public const string SplitViewState = "splitviewstate";
            public const string SyncContactCompany = "synccontactcompany";
            public const string SystemUserId = "systemuserid";
            public const string Id = "systemuserid";
            public const string TimeFormatCode = "timeformatcode";
            public const string TimeFormatString = "timeformatstring";
            public const string TimeSeparator = "timeseparator";
            public const string TimeZoneBias = "timezonebias";
            public const string TimeZoneCode = "timezonecode";
            public const string TimeZoneDaylightBias = "timezonedaylightbias";
            public const string TimeZoneDaylightDay = "timezonedaylightday";
            public const string TimeZoneDaylightDayOfWeek = "timezonedaylightdayofweek";
            public const string TimeZoneDaylightHour = "timezonedaylighthour";
            public const string TimeZoneDaylightMinute = "timezonedaylightminute";
            public const string TimeZoneDaylightMonth = "timezonedaylightmonth";
            public const string TimeZoneDaylightSecond = "timezonedaylightsecond";
            public const string TimeZoneDaylightYear = "timezonedaylightyear";
            public const string TimeZoneStandardBias = "timezonestandardbias";
            public const string TimeZoneStandardDay = "timezonestandardday";
            public const string TimeZoneStandardDayOfWeek = "timezonestandarddayofweek";
            public const string TimeZoneStandardHour = "timezonestandardhour";
            public const string TimeZoneStandardMinute = "timezonestandardminute";
            public const string TimeZoneStandardMonth = "timezonestandardmonth";
            public const string TimeZoneStandardSecond = "timezonestandardsecond";
            public const string TimeZoneStandardYear = "timezonestandardyear";
            public const string TrackingTokenId = "trackingtokenid";
            public const string TransactionCurrencyId = "transactioncurrencyid";
            public const string UILanguageId = "uilanguageid";
            public const string UseCrmFormForAppointment = "usecrmformforappointment";
            public const string UseCrmFormForContact = "usecrmformforcontact";
            public const string UseCrmFormForEmail = "usecrmformforemail";
            public const string UseCrmFormForTask = "usecrmformfortask";
            public const string UseImageStrips = "useimagestrips";
            public const string UserProfile = "userprofile";
            public const string VersionNumber = "versionnumber";
            public const string VisualizationPaneLayout = "visualizationpanelayout";
            public const string WorkdayStartTime = "workdaystarttime";
            public const string WorkdayStopTime = "workdaystoptime";
            public const string lk_usersettings_createdonbehalfby = "lk_usersettings_createdonbehalfby";
            public const string lk_usersettings_modifiedonbehalfby = "lk_usersettings_modifiedonbehalfby";
            public const string lk_usersettingsbase_createdby = "lk_usersettingsbase_createdby";
            public const string lk_usersettingsbase_modifiedby = "lk_usersettingsbase_modifiedby";
            public const string transactioncurrency_usersettings = "transactioncurrency_usersettings";
            public const string user_settings = "user_settings";
        }
    }
}