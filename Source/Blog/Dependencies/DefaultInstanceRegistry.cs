using Blog.Services.Feeds;
using StructureMap.Configuration.DSL;

namespace Blog.Dependencies
{
    public class DefaultInstanceRegistry : Registry
    {
        public DefaultInstanceRegistry()
        {
            Scan(assemblyScanner =>
                {
                    assemblyScanner.TheCallingAssembly();
                    assemblyScanner.WithDefaultConventions();
                    assemblyScanner.AddAllTypesOf<IEventFeed>();
                });
        }
    }
}