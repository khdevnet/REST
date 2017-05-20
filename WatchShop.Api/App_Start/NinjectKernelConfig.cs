using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Filters;
using Ninject;
using Ninject.Web.WebApi;
using Ninject.Web.WebApi.FilterBindingSyntax;
using WatchShop.Api.Infrastructure.Validation;

namespace WatchShop.Api
{
    public static class NinjectKernelConfig
    {
        private const string NinjectModuleAssemblyKey = "domain";

        public static void Register()
        {
            var kernel = new StandardKernel();
            kernel.BindHttpFilter<ModelValidatorAttribute>(FilterScope.Global);
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