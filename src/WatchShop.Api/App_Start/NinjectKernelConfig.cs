using System.Web.Http;
using Ninject.Web.WebApi;
using Ninject;
using System;
using System.Linq;
using System.Reflection;

namespace WatchShop.Api
{
    public static class NinjectKernelConfig
    {
        private const string  NinjectModuleAssemblyKey = "domain";

        public static void Register()
        {
            var kernel = new StandardKernel();
            kernel.Load(GetDomainAssemblies());
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
        }

        private static System.Collections.Generic.IEnumerable<Assembly> GetDomainAssemblies()
        {
            return AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(assembly => assembly.GetName().Name.ToLower().EndsWith(NinjectModuleAssemblyKey));
        }
    }
}