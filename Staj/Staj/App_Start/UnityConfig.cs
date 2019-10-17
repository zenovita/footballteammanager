using Staj.Business;
using Staj.Business.Interface;
using Staj.Repository.Infrastructure;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace Staj
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();


            //IF THEY HAVE A CONSTUCTOR WITH A PARAMETER UNCOMMENT THESE LINES

            //container.RegisterType<FixtureBusiness>(new InjectionConstructor(0));
            //container.RegisterType<PlayerBusiness>(new InjectionConstructor(0));
            //container.RegisterType<PlayerSkillBusiness>(new InjectionConstructor(0));
            //container.RegisterType<TeamBusiness>(new InjectionConstructor(0));
            //container.RegisterType<UserBusiness>(new InjectionConstructor(0));
            //container.RegisterType<UserTypeBusiness>(new InjectionConstructor(0));

            container.RegisterType<IFixtureBusiness, FixtureBusiness>();
            container.RegisterType<IPlayerBusiness, PlayerBusiness>();
            container.RegisterType<IPlayerSkillBusiness, PlayerSkillBusiness>();
            container.RegisterType<ITeamBusiness, TeamBusiness>();
            container.RegisterType<IUserBusiness, UserBusiness>();
            container.RegisterType<IUserTypeBusiness, UserTypeBusiness>();
            container.RegisterType<IImageBusiness, ImageBusiness>();

            container.RegisterType<IUnitOfWork, UnitOfWork>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}