using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Blog.Dependencies
{
    public class StructureMapDependencyResolver : System.Web.Mvc.IDependencyResolver, IDependencyResolver
    {
        private readonly IContainer container;

        public StructureMapDependencyResolver(Registry registry)
        {
            container = new Container(registry);
        }

        public object GetService(Type serviceType)
        {
            if (serviceType.IsAbstract || serviceType.IsInterface)
            {
                return container.TryGetInstance(serviceType);
            }

            return container.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.GetAllInstances<object>().Where(s => s.GetType() == serviceType);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
        }
    }
}