using System.Web.Mvc;
using StructureMap;

namespace Blog.Dependencies
{
    public class StructureMapSetup
    {
        public static void InitializeContainer()
        {
            var container = (IContainer)new Container(new RepositoryRegistry());
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
        }
    }
}