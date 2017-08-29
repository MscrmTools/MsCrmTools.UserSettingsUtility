using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using CrmEarlyBound;

namespace MsCrmTools.UserSettingsUtility.AppCode
{
    internal class UserSettingsHelper
    {
        private readonly ConnectionDetail detail;
        private readonly IOrganizationService service;

        public UserSettingsHelper(IOrganizationService service, ConnectionDetail detail)
        {
            this.service = service;
            this.detail = detail;
        }

        public List<Language> RetrieveAvailableLanguages()
        {
            var lcidRequest = new RetrieveProvisionedLanguagesRequest();
            var lcidResponse = (RetrieveProvisionedLanguagesResponse)service.Execute(lcidRequest);
            return lcidResponse.RetrieveProvisionedLanguages.Select(lcid => new Language(lcid)).ToList();
        }

        public IEnumerable<Entity> RetrieveCurrencies()
        {
            var currencies = service.RetrieveMultiple(new FetchExpression(@"
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
            var response = (GetAllTimeZonesWithDisplayNameResponse)service.Execute(request);

            return response.EntityCollection;
        }

        public void UpdateSettings(Guid userId, Entity settings)
        {
            var currentUserId = detail.ServiceClient.OrganizationServiceProxy.CallerId;
            detail.ServiceClient.OrganizationServiceProxy.CallerId = userId;
            var records = detail.ServiceClient.OrganizationServiceProxy.RetrieveMultiple(new QueryByAttribute("usersettings")
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

            if (userSetting.Attributes.Count > 1)
            {
                service.Update(userSetting);
            }

            detail.ServiceClient.OrganizationServiceProxy.CallerId = currentUserId;
        }

        public IEnumerable<Entity> RetrieveDashboards()
        {
            var dashboards = service.RetrieveMultiple(new FetchExpression(@"
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