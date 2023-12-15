using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MsCrmTools.UserSettingsUtility.AppCode
{
    internal class SiteMapManager
    {
        private readonly IOrganizationService service;
        private XmlDocument siteMapDoc;

        public SiteMapManager(IOrganizationService service)
        {
            this.service = service;
        }

        public List<string> GetAreaList(string sitemapxml)
        {
            if (siteMapDoc == null)
            {
                LoadSiteMap(sitemapxml);
            }

            if (!string.IsNullOrEmpty(sitemapxml))
            {
                LoadSiteMap(sitemapxml);
            }

            var areaNodes = siteMapDoc.SelectNodes("//Area");
            return (from XmlNode node in areaNodes select node.Attributes["Id"].Value).ToList();
        }

        public List<AppSiteMapItems> GetHomeList()
        {
            //add default
            var qe = new QueryExpression("sitemap") { ColumnSet = new ColumnSet(true) };

            EntityCollection ecdefault = service.RetrieveMultiple(qe);
            ecdefault[0]["sitemapname"] = "Default";
            var ec = new EntityCollection();
            ec.Entities.Add(ecdefault[0]);

            //add other app sitemap
            var items = new List<AppSiteMapItems>();

            var sitemapsIds = service.RetrieveMultiple(new QueryExpression("appmodulecomponent")
            {
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression
                {
                    Conditions =
                                {
                                    new ConditionExpression("componenttype", ConditionOperator.Equal, 62)
                                }
                }
            });

            foreach (var siteMapId in sitemapsIds.Entities)
            {
                if (ec.Entities.Any(ent => ent.Id == siteMapId.GetAttributeValue<Guid>("objectid") ||
                 siteMapId.GetAttributeValue<EntityReference>("appmoduleidunique").Name == null))
                {
                    continue;
                }

                var tmpSiteMap = service.Retrieve("sitemap",
                    siteMapId.GetAttributeValue<Guid>("objectid"), new ColumnSet(true));

                if (tmpSiteMap.GetAttributeValue<OptionSetValue>("componentstate")?.Value != 0)
                {
                    continue;
                }

                tmpSiteMap["name"] =
                    siteMapId.GetAttributeValue<EntityReference>("appmoduleidunique").Name ?? "Default";
                ec.Entities.Add(tmpSiteMap);
            }

            items.AddRange(ec.Entities.Select(e => new AppSiteMapItems(e)));
            return items;
        }

        public List<Tuple<string, string>> GetSubAreaList(string sitemapxml)
        {
            if (siteMapDoc == null)
            {
                LoadSiteMap(sitemapxml);
            }
            if (string.IsNullOrEmpty(sitemapxml))
            {
                LoadSiteMap(sitemapxml);
            }

            var areaNodes = siteMapDoc.SelectNodes("//SubArea");
            return (from XmlNode node in areaNodes select new Tuple<string, string>(node.Attributes["Id"].Value, node.ParentNode.ParentNode.Attributes["Id"].Value)).ToList();
        }

        private void LoadSiteMap(string sitemapxml)
        {
            siteMapDoc = new XmlDocument();
            if (string.IsNullOrEmpty(sitemapxml))
            {
                var qe = new QueryExpression("sitemap") { ColumnSet = new ColumnSet(true) };

                EntityCollection ec = service.RetrieveMultiple(qe);
                siteMapDoc.LoadXml(ec[0]["sitemapxml"].ToString());
            }
            else
            {
                siteMapDoc.LoadXml(sitemapxml);
            }
        }
    }
}