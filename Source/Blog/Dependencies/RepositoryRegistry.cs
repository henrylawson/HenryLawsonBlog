using StructureMap.Configuration.DSL;

namespace Blog.Dependencies
{
    public class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            Scan(assemblyScanner =>
                {
                    assemblyScanner.TheCallingAssembly();
                    assemblyScanner.WithDefaultConventions();
                });
        }
    }
}