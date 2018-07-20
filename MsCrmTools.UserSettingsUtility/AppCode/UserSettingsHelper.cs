using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CrmEarlyBound;

namespace MsCrmTools.UserSettingsUtility.AppCode
{
    internal class UserSettingsHelper
    {
        private readonly ConnectionDetail _detail;
        private readonly IOrganizationService _service;
        private Boolean _ignoreDisabledUsers;
        private Boolean _ignoreUserWithoutRoles;
        private Guid _currentUserId;

        public UserSettingsHelper(IOrganizationService service, ConnectionDetail detail)
        {
            _service = service;
            _detail = detail;
        }

        public List<Language> RetrieveAvailableLanguages()
        {
            var lcidRequest = new RetrieveProvisionedLanguagesRequest();
            var lcidResponse = (RetrieveProvisionedLanguagesResponse)_service.Execute(lcidRequest);
            return lcidResponse.RetrieveProvisionedLanguages.Select(lcid => new Language(lcid)).ToList();
        }

        public Version RetrieveVersion()
        {
            var request = new RetrieveVersionRequest();
            var response = (RetrieveVersionResponse) _service.Execute(request);

            return Version.Parse(response.Version);
        }

        public IEnumerable<Entity> RetrieveCurrencies()
        {
            var currencies = _service.RetrieveMultiple(new FetchExpression(@"
            <fetch>
              <entity name='transactioncurrency' >
                <attribute name='transactioncurrencyid' />
                <attribute name='currencyname' />
                <order attribute='currencyname' />
              </entity>
            </fetch>")).Entities;
            return currencies;
        }

        public EntityCollection RetrieveTimeZones()
        {
            var request = new GetAllTimeZonesWithDisplayNameRequest { LocaleId = 1033 };
            var response = (GetAllTimeZonesWithDisplayNameResponse)_service.Execute(request);

            return response.EntityCollection;
        }

        public void UpdateSettings(Guid userId, string userFullName, Entity settings)
        {
            try
            {
                _currentUserId = _detail.ServiceClient.OrganizationServiceProxy.CallerId;
                _detail.ServiceClient.OrganizationServiceProxy.CallerId = userId;
                var records = _detail.ServiceClient.OrganizationServiceProxy.RetrieveMultiple(new QueryByAttribute("usersettings")
                {
                    Attributes = { UserSettings.Fields.SystemUserId },
                    Values = { userId },
                });

                var userSetting = records.Entities.FirstOrDefault();

                if (userSetting == null)
                {
                    return;
                }

                if (settings.GetAttributeValue<int?>(UserSettings.Fields.AdvancedFindStartupMode) >= 1)
                    userSetting[UserSettings.Fields.AdvancedFindStartupMode] = settings.GetAttributeValue<int?>(UserSettings.Fields.AdvancedFindStartupMode);

                if (settings.GetAttributeValue<int?>(UserSettings.Fields.AutoCreateContactOnPromote) >= 0)
                    userSetting[UserSettings.Fields.AutoCreateContactOnPromote] = settings.GetAttributeValue<int?>(UserSettings.Fields.AutoCreateContactOnPromote);

                if (settings.GetAttributeValue<int?>(UserSettings.Fields.DefaultCalendarView) >= 0)
                    userSetting[UserSettings.Fields.DefaultCalendarView] = settings.GetAttributeValue<int?>(UserSettings.Fields.DefaultCalendarView);

                if (settings.GetAttributeValue<string>(UserSettings.Fields.HomepageArea) != "No change")
                    userSetting[UserSettings.Fields.HomepageArea] = settings.GetAttributeValue<string>(UserSettings.Fields.HomepageArea);

                if (settings.GetAttributeValue<string>(UserSettings.Fields.HomepageSubarea) != "No change")
                    userSetting[UserSettings.Fields.HomepageSubarea] = settings.GetAttributeValue<string>(UserSettings.Fields.HomepageSubarea);

                if (settings.GetAttributeValue<OptionSetValue>(UserSettings.Fields.IncomingEmailFilteringMethod).Value >= 0)
                    userSetting[UserSettings.Fields.IncomingEmailFilteringMethod] = settings.GetAttributeValue<OptionSetValue>(UserSettings.Fields.IncomingEmailFilteringMethod);

                if (settings.GetAttributeValue<int?>(UserSettings.Fields.PagingLimit).HasValue)
                    userSetting[UserSettings.Fields.PagingLimit] = settings.GetAttributeValue<int?>(UserSettings.Fields.PagingLimit).Value;

                if (settings.GetAttributeValue<int?>(UserSettings.Fields.TimeZoneCode) >= 0)
                    userSetting[UserSettings.Fields.TimeZoneCode] = settings.GetAttributeValue<int?>(UserSettings.Fields.TimeZoneCode);

                if (!string.IsNullOrEmpty(settings.GetAttributeValue<string>(UserSettings.Fields.WorkdayStartTime)) && settings.GetAttributeValue<string>(UserSettings.Fields.WorkdayStartTime) != "No change")
                    userSetting[UserSettings.Fields.WorkdayStartTime] = settings.GetAttributeValue<string>(UserSettings.Fields.WorkdayStartTime);

                if (!string.IsNullOrEmpty(settings.GetAttributeValue<string>(UserSettings.Fields.WorkdayStopTime)) && settings.GetAttributeValue<string>(UserSettings.Fields.WorkdayStopTime) != "No change")
                    userSetting[UserSettings.Fields.WorkdayStopTime] = settings.GetAttributeValue<string>(UserSettings.Fields.WorkdayStopTime);

                if (settings.GetAttributeValue<OptionSetValue>(UserSettings.Fields.ReportScriptErrors).Value >= 1)
                    userSetting[UserSettings.Fields.ReportScriptErrors] = settings.GetAttributeValue<OptionSetValue>(UserSettings.Fields.ReportScriptErrors);

                if (settings.GetAttributeValue<bool?>(UserSettings.Fields.IsSendAsAllowed).HasValue)
                    userSetting[UserSettings.Fields.IsSendAsAllowed] = settings.GetAttributeValue<bool?>(UserSettings.Fields.IsSendAsAllowed).Value;

                if (settings.GetAttributeValue<int?>(UserSettings.Fields.UILanguageId).HasValue)
                    userSetting[UserSettings.Fields.UILanguageId] = settings.GetAttributeValue<int?>(UserSettings.Fields.UILanguageId).Value;

                if (settings.GetAttributeValue<int?>(UserSettings.Fields.HelpLanguageId).HasValue)
                    userSetting[UserSettings.Fields.HelpLanguageId] = settings.GetAttributeValue<int?>(UserSettings.Fields.HelpLanguageId).Value;

                if (settings.GetAttributeValue<EntityReference>(UserSettings.Fields.TransactionCurrencyId) != null)
                    userSetting[UserSettings.Fields.TransactionCurrencyId] = settings.GetAttributeValue<EntityReference>(UserSettings.Fields.TransactionCurrencyId);

                if (settings.GetAttributeValue<bool?>(UserSettings.Fields.GetStartedPaneContentEnabled).HasValue)
                    userSetting[UserSettings.Fields.GetStartedPaneContentEnabled] = settings.GetAttributeValue<bool?>(UserSettings.Fields.GetStartedPaneContentEnabled).Value;

                if (settings.GetAttributeValue<bool?>(UserSettings.Fields.UseCrmFormForAppointment).HasValue)
                    userSetting[UserSettings.Fields.UseCrmFormForAppointment] = settings.GetAttributeValue<bool?>(UserSettings.Fields.UseCrmFormForAppointment).Value;

                if (settings.GetAttributeValue<bool?>(UserSettings.Fields.UseCrmFormForContact).HasValue)
                    userSetting[UserSettings.Fields.UseCrmFormForContact] = settings.GetAttributeValue<bool?>(UserSettings.Fields.UseCrmFormForContact).Value;

                if (settings.GetAttributeValue<bool?>(UserSettings.Fields.UseCrmFormForEmail).HasValue)
                    userSetting[UserSettings.Fields.UseCrmFormForEmail] = settings.GetAttributeValue<bool?>(UserSettings.Fields.UseCrmFormForEmail).Value;

                if (settings.GetAttributeValue<bool?>(UserSettings.Fields.UseCrmFormForTask).HasValue)
                    userSetting[UserSettings.Fields.UseCrmFormForTask] = settings.GetAttributeValue<bool?>(UserSettings.Fields.UseCrmFormForTask).Value;

                if (settings.GetAttributeValue<Guid?>(UserSettings.Fields.DefaultDashboardId).HasValue)
                    userSetting[UserSettings.Fields.DefaultDashboardId] = settings.GetAttributeValue<Guid?>(UserSettings.Fields.DefaultDashboardId);

                if (settings.GetAttributeValue<int?>(UserSettings.Fields.LocaleId).HasValue)
                    userSetting[UserSettings.Fields.LocaleId] = settings.GetAttributeValue<int?>(UserSettings.Fields.LocaleId).Value;

                if (settings.GetAttributeValue<OptionSetValue>(UserSettings.Fields.DefaultSearchExperience).Value >= 0)
                    userSetting[UserSettings.Fields.DefaultSearchExperience] = settings.GetAttributeValue<OptionSetValue>(UserSettings.Fields.DefaultSearchExperience);

                if (userSetting.Attributes.Count > 1)
                {
                    _service.Update(userSetting);
                }

                _detail.ServiceClient.OrganizationServiceProxy.CallerId = _currentUserId;
            }
            catch (Exception e)
            {
                // Reset callerid to the logged in user so later queries don't fail
                _detail.ServiceClient.OrganizationServiceProxy.CallerId = _currentUserId;

                // If the user is disabled, they can't be updated - raise error and ask if processing should continue
                if (e.Message.StartsWith("The user with SystemUserId") && e.Message.EndsWith("is disabled"))
                {
                    if (!_ignoreDisabledUsers)
                    {
                        ContinueIgnoreOrAbort(userFullName, "UserIsDisabled");
                    }
                }
                // If the user has no security roles, they can't be updated - raise error and ask if processing should continue
                else if (e.Message.Contains("no roles are assigned to user"))
                {
                    if (!_ignoreUserWithoutRoles)
                    {
                        ContinueIgnoreOrAbort(userFullName, "UserHasNoSecurityRoles");
                    }
                }
                // Some other unexpected error has occured
                else
                {                    
                    throw;
                }
            }
        }

        private void ContinueIgnoreOrAbort(string userFullName, string errorType)
        {
            String title = null;
            String message = null;

            switch (errorType)
            {
                case "UserIsDisabled":
                    title = "User is disabled!";
                    message = "User " + userFullName + " is disabled";
                    break;
                case "UserHasNoSecurityRoles":
                    title = "User has no security roles!";
                    message = "User " + userFullName + " has no security roles";
                    break;
            }

            DialogResult dr = DialogueBoxManager.DialogBox(title,
                message + ", so their settings can not be updated. " +
                @"Do you want to Continue, Ignore any similar errors, or Cancel?", "Continue", "Ignore All", "Abort");
            if (dr == DialogResult.Ignore)
            {
                // Continue, suppressing any similar messages
                if (errorType == "UserIsDisabled")
                {
                    _ignoreDisabledUsers = true;
                }

                if (errorType == "UserHasNoSecurityRoles")
                {
                    _ignoreUserWithoutRoles = true;
                }
            }

            else if (dr == DialogResult.Abort)
            {
                // Abort processing
                throw new UserAbortedException();
            }
        }

        public class UserAbortedException : Exception
        { }

        public IEnumerable<Entity> RetrieveDashboards()
        {
            var dashboards = _service.RetrieveMultiple(new FetchExpression(@"
            <fetch>
              <entity name='systemform' >
                <attribute name='formid' />
                <attribute name='name' />
                <filter>
                  <condition attribute='type' operator='eq' value='0' />
                </filter>
                <order attribute='name' />
              </entity>
            </fetch>")).Entities;
            return dashboards;
        }
    }
}