using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsCrmTools.UserSettingsUtility.AppCode
{
    internal class AppSiteMapItems
    {
        private readonly Entity app;

        public AppSiteMapItems(Entity home)
        {
            this.app = home;
        }

        public string SiteMapXml
        {
            get { return app.GetAttributeValue<string>("sitemapxml"); }
        }

        public override string ToString()
        {
            return app.GetAttributeValue<string>("sitemapname");
        }
    }
}
