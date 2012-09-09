using Ninject;
using Ninject.Web.Common;
using Ninject.Web.WebApi.Filter;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Ninject.Web.WebApi.Filter
{
    public class IocConfig
    {
        public static void RegisterIoc(HttpConfiguration config)
        {
            var ninjectKernel = new StandardKernel(); // Ninject IoC

            // These registrations are "per instance request".
            // See http://blog.bobcravens.com/2010/03/ninject-life-cycle-management-or-scoping/

            ninjectKernel.Bind<ISomeInterface>().To<SomeClass>();

            // Tell WebApi how to use our Ninject IoC
            config.DependencyResolver = new NinjectDependencyResolver(ninjectKernel);

            // Register Filter Provider
            var providers = GlobalConfiguration.Configuration.Services.GetFilterProviders().ToList();
            GlobalConfiguration.Configuration.Services.Add(typeof (IFilterProvider),
                                                           new DefaultFilterProvider(ninjectKernel, providers));
            
            var defaultprovider = providers.First(i => i is ActionDescriptorFilterProvider);
            GlobalConfiguration.Configuration.Services.Remove(typeof(IFilterProvider), defaultprovider);
        }
    }
}