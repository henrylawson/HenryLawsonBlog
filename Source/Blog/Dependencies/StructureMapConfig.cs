using System.Web.Http;
using System.Web.Mvc;
using StructureMap;

namespace Blog.Dependencies
{
    public class StructureMapConfig
    {
        public static void RegisterDependencies(HttpConfiguration configuration)
        {
            var defaultInstanceRegistry = new DefaultInstanceRegistry();
            var structureMapDependencyResolver = new StructureMapDependencyResolver(defaultInstanceRegistry);
            DependencyResolver.SetResolver(structureMapDependencyResolver);
            configuration.DependencyResolver = structureMapDependencyResolver;
            ObjectFactory.Initialize(expression => expression.AddRegistry(defaultInstanceRegistry));
        }
    }
}