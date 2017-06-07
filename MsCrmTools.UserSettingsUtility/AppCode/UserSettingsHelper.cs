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
    internal class UserSettingsHelper : IDisposable
    {
        private readonly ConnectionDetail detail;
        private readonly IOrganizationService service;
        private readonly CrmServiceContext serviceContext;

        public UserSettingsHelper(IOrganizationService service, ConnectionDetail detail)
        {
            this.service = service;
            this.serviceContext = new CrmServiceContext(service);
            this.detail = detail;
        }

        public List<Language> RetrieveAvailableLanguages()
        {
            var lcidRequest = new RetrieveProvisionedLanguagesRequest();
            var lcidResponse = (RetrieveProvisionedLanguagesResponse)service.Execute(lcidRequest);
            return lcidResponse.RetrieveProvisionedLanguages.Select(lcid => new Language(lcid)).ToList();
        }

        public IEnumerable<TransactionCurrency> RetrieveCurrencies()
        {
            var currencies = serviceContext.TransactionCurrencySet
                .OrderBy(c => c.CurrencyName)
                .Select(c => new TransactionCurrency { Id = c.Id, CurrencyName = c.CurrencyName })
                .ToList();
            return currencies;
        }

        public EntityCollection RetrieveTimeZones()
        {
            var request = new GetAllTimeZonesWithDisplayNameRequest { LocaleId = 1033 };
            var response = (GetAllTimeZonesWithDisplayNameResponse)service.Execute(request);

            return response.EntityCollection;
        }

        public void UpdateSettings(Guid userId, UserSettings settings)
        {
            var currentUserId = detail.ServiceClient.OrganizationServiceProxy.CallerId;
            detail.ServiceClient.OrganizationServiceProxy.CallerId = userId;
            var records = detail.ServiceClient.OrganizationServiceProxy.RetrieveMultiple(new QueryByAttribute("usersettings")
            {
                Attributes = { "systemuserid" },
                Values = { userId },
            });

            var userSetting = records.Entities.FirstOrDefault().ToEntity<UserSettings>();

            if (userSetting == null)
            {
                return;
            }

            if (settings.AdvancedFindStartupMode >= 1)
                userSetting.AdvancedFindStartupMode = settings.AdvancedFindStartupMode;
            if (settings.AutoCreateContactOnPromote >= 0)
                userSetting.AutoCreateContactOnPromote = settings.AutoCreateContactOnPromote;
            if (settings.DefaultCalendarView >= 0)
                userSetting.DefaultCalendarView = settings.DefaultCalendarView;
            if (settings.HomepageArea.Length > 0 && settings.HomepageArea != "No change")
                userSetting.HomepageArea = settings.HomepageArea;
            if (settings.HomepageSubarea.Length > 0 && settings.HomepageSubarea != "No change")
                userSetting.HomepageSubarea = settings.HomepageSubarea;
            if (settings.IncomingEmailFilteringMethod.Value >= 0)
                userSetting .IncomingEmailFilteringMethod= settings.IncomingEmailFilteringMethod;
            if (settings.PagingLimit.HasValue)
                userSetting.PagingLimit = settings.PagingLimit.Value;
            if (settings.TimeZoneCode >= 0)
                userSetting.TimeZoneCode = settings.TimeZoneCode;
            if (settings.WorkdayStartTime.Length > 0 && settings.WorkdayStartTime != "No change")
                userSetting.WorkdayStartTime = settings.WorkdayStartTime;
            if (settings.WorkdayStopTime.Length > 0 && settings.WorkdayStopTime != "No change")
                userSetting.WorkdayStopTime = settings.WorkdayStopTime;
            if (settings.ReportScriptErrors.Value >= 1)
                userSetting.ReportScriptErrors = settings.ReportScriptErrors;
            if (settings.IsSendAsAllowed.HasValue)
                userSetting.IsSendAsAllowed = settings.IsSendAsAllowed.Value;
            if (settings.UILanguageId.HasValue)
                userSetting.UILanguageId = settings.UILanguageId.Value;
            if (settings.HelpLanguageId.HasValue)
                userSetting.HelpLanguageId = settings.HelpLanguageId.Value;
            if (settings.TransactionCurrencyId != null)
                userSetting.TransactionCurrencyId = settings.TransactionCurrencyId;
            if (settings.GetStartedPaneContentEnabled.HasValue)
                userSetting.GetStartedPaneContentEnabled = settings.GetStartedPaneContentEnabled.Value;
            if (settings.UseCrmFormForAppointment.HasValue)
                userSetting.UseCrmFormForAppointment = settings.UseCrmFormForAppointment.Value;
            if (settings.UseCrmFormForContact.HasValue)
                userSetting.UseCrmFormForContact = settings.UseCrmFormForContact.Value;
            if (settings.UseCrmFormForEmail.HasValue)
                userSetting.UseCrmFormForEmail = settings.UseCrmFormForEmail.Value;
            if (settings.UseCrmFormForTask.HasValue)
                userSetting.UseCrmFormForTask = settings.UseCrmFormForTask.Value;
            if(settings.DefaultDashboardId.HasValue)
                userSetting.DefaultDashboardId = settings.DefaultDashboardId;
            if (settings.LocaleId.HasValue)
                userSetting.LocaleId = settings.LocaleId;
            service.Update(userSetting);

            detail.ServiceClient.OrganizationServiceProxy.CallerId = currentUserId;
        }

        public IEnumerable<SystemForm> RetrieveDashboards()
        {
            var dashboards = serviceContext.SystemFormSet
                .Where(s => s.ObjectTypeCode == "none" && s.UniqueName == null)
                .OrderBy(s => s.Name)
                .Select(s => new SystemForm {Id = s.Id, Name = s.Name})
                .ToList();
            return dashboards;
        }

        public void Dispose()
        {
            serviceContext.Dispose();
        }
    }
}