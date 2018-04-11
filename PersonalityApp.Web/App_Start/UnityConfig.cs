using System.Web.Http;
using Unity;
using Unity.WebApi;
using Microsoft.Practices.Unity;
using PersonalityApp.Web.Services;
using Unity.Injection;
using System.Configuration;
using PersonalityApp.Web.Security;
using Unity.Lifetime;

namespace PersonalityApp.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();


            container.RegisterType<IAuthenticationService, OwinAuthenticationService>();

            container.RegisterType<ICryptographyService, Base64StringCryptographyService>(new ContainerControlledLifetimeManager());

            container.RegisterType<IWordSearchService, WordSearchService>(new ContainerControlledLifetimeManager());

            container.RegisterType<IUserService, UserService>(new ContainerControlledLifetimeManager());

            container.RegisterType<IPersonalityService, PersonalityService>();
            container.RegisterType<IUserService, UserService>();

            container.RegisterType<IAccountService, AccountService>();

            container.RegisterType<IDataProvider, SqlDataProvider>(
                new InjectionConstructor(
                    ConfigurationManager.ConnectionStrings["NorthwindConnString"].ConnectionString));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}