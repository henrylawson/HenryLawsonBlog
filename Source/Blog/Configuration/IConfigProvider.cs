namespace Blog.Configuration
{
    public interface IConfigProvider
    {
        string Setting(string settingKey);
    }
}