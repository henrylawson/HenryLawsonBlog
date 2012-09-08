using System.Collections.Generic;

namespace Blog.Configuration
{
    public class ConfigProvider : IConfigProvider
    {
        private readonly Dictionary<string, string> Settings = new Dictionary<string, string>
            {
                { "gitHubUri", "https://github.com/henrylawson.atom" },
                { "blogPostFeedUri", "http://localhost:44613/atom" },
            };

        public string Setting(string settingKey)
        {
            return Settings[settingKey];
        }
    }
}
