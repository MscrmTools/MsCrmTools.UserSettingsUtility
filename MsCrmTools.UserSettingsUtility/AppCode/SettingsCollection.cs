using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using CrmEarlyBound;

namespace MsCrmTools.UserSettingsUtility.AppCode
{
    internal class SettingsCollection
    {
        public List<string> Areas { get; set; }
        public IEnumerable<TransactionCurrency> Currencies { get; set; }
        public List<Language> Languages { get; set; }
        public List<Tuple<string, string>> SubAreas { get; set; }
        public EntityCollection TimeZones { get; set; }
        public IEnumerable<SystemForm> Dashboards { get; set; }
    }
}