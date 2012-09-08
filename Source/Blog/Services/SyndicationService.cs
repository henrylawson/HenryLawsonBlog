using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using Blog.Configuration;
using StructureMap;

namespace Blog.Services
{
    public class SyndicationService : ISyndicationService
    {
        public IList<SyndicationItem> Load(string configSettingKey)
        {
            var uri = ObjectFactory.GetInstance<IConfigProvider>().Setting(configSettingKey);
            var reader = XmlReader.Create(uri);
            var syndicateItems = SyndicationFeed.Load(reader);
            reader.Close();
            return syndicateItems == null ? new List<SyndicationItem>() : syndicateItems.Items.ToList();
        }
    }
}