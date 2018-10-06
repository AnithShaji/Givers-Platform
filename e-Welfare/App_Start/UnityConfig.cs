using System.Web.Http;
using Microsoft.Practices.Unity;
using e_Welfare.BLL.Interfaces;
using e_Welfare.BLL.BusinessObjects;
//using Unity.WebApi;
using Microsoft.Practices.Unity.WebApi;
using e_Welfare.BLL.Persistence;

////using Monnie.BLL.Services;
////using Monnie.DAL.Repository;


namespace e_Welfare
{
    /// <summary>
    /// Unity configuration 
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// Register all components to Unity container
        /// </summary>
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            // container.RegisterType<IUsersIDTypeRepository, UsersIDTypeRepository>();

            //container.RegisterType<IUsersIDTypeService, UsersIDTypeService>();
            container.RegisterType<IManageUserLogin, ManageUserLogin>();
            //container.RegisterType<IUserLogin, ManageUserLogin>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            //container.RegisterType<IManageUsersIDType, ManageUsersIDType>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}