[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CoachLancer.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CoachLancer.Web.App_Start.NinjectWebCommon), "Stop")]

namespace CoachLancer.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;
    using CoachLancer.Data.Repositories;
    using System.Data.Entity;
    using CoachLancer.Data;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using CoachLancer.Web.ViewModels.Factories;
    using CoachLancer.Data.Models;
    using Microsoft.Owin.Security;
    using CoachLancer.Services;
    using CoachLancer.Data.SaveContext;
    using Microsoft.AspNet.Identity.Owin;
    using AutoMapper;
    using CoachLancer.Services.Contracts;
    using CoachLancer.Web.Auth;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(x =>
            {
                x.FromThisAssembly()
                    .SelectAllClasses()
                    .BindDefaultInterface();
            });
            kernel.Bind(typeof(DbContext), typeof(MsSqlDbContext)).To(typeof(MsSqlDbContext)).InRequestScope();
            kernel.Bind(typeof(IEfRepository<>)).To(typeof(EfRepository<>));
            kernel.Bind<ISaveContext>().To<SaveContext>();

            // Account controller constructor
            kernel.Bind<SignInManager>().ToMethod(_ =>
                HttpContext.Current.GetOwinContext().Get<SignInManager>()
            );
            kernel.Bind<UserManager>().ToMethod(_ =>
                HttpContext.Current.GetOwinContext().GetUserManager<UserManager>()
            );
            //

            kernel.Bind(typeof(IRoleStore<IdentityRole, string>)).To(typeof(RoleStore<IdentityRole>));
            kernel.Bind(typeof(RoleManager<IdentityRole>)).ToSelf();
            kernel.Bind<IUserFactory>().To<UserFactory>().InSingletonScope();

            kernel.Bind<ICoachService>().To<CoachService>();
            kernel.Bind<IGroupsService>().To<GroupsService>();
            kernel.Bind<IPlayersService>().To<PlayersService>();
            

            kernel.Bind<IMapper>().ToMethod(m => Mapper.Instance).InSingletonScope();
        }
    }
}
