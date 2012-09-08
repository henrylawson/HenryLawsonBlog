using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace Blog.Services
{
    public interface ISyndicationService
    {
        IList<SyndicationItem> Load(string configSettingKey);
    }
}