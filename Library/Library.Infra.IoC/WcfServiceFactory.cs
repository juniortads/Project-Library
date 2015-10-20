using System;
using System.ServiceModel;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Interfaces.Services;
using Library.Domain.Services;
using Library.Infra.Data.Manager;
using Library.Infra.Data.Repositories;
using Microsoft.Practices.Unity;
using Unity.Wcf;
using Library.Application.Interface;
using Library.Application;

namespace Library.Infra.IoC
{
    public class WcfServiceFactory : UnityServiceHostFactory
    {
        private static IUnityContainer mContainer;

        public WcfServiceFactory()
        {
            mContainer = new UnityContainer();
            this.ConfigureContainer(mContainer);
        }

        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            return base.CreateServiceHost(constructorString, baseAddresses);
        }
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return base.CreateServiceHost(serviceType, baseAddresses);
        }

        public ServiceHost CreateServiceHostWithType(Type serviceType, Uri[] baseAddresses)
        {
            return new UnityServiceHost(mContainer, serviceType, baseAddresses);
        }

        public ServiceHost CreateServiceHostWithType(Type serviceType)
        {
            return new UnityServiceHost(mContainer, serviceType);
        }

        protected override void ConfigureContainer(IUnityContainer container)
        {
            switch (DataAccessManagerFactory.GetTypeDataAccess)
            {
                case TypeDataAccess.EntityFramework:
                    this.RegisterTypeDataAccessEf();
                    break;
            }
            RegisterTypeStudent(container);
            RegisterTypeBook(container);
            RegisterTypeDemandsForBook(container);
        }

        private void RegisterTypeStudent(IUnityContainer container)
        {
            container
                .RegisterType<IStudentAppService, StudentAppService>()
                .RegisterType<IStudentService, StudentService>()
                .RegisterType<IStudentRepository, StudentRepository>(new HierarchicalLifetimeManager());
        }

        private void RegisterTypeBook(IUnityContainer container)
        {
            container
                .RegisterType<IBookAppService, BookAppService>()
                .RegisterType<IBookService, BookService>()
                .RegisterType<IBookRepository, BookRepository>(new HierarchicalLifetimeManager());
        }

        private void RegisterTypeDemandsForBook(IUnityContainer container)
        {
            container
                .RegisterType<IDemandsForBookService, DemandsForBookService>()
                .RegisterType<IDemandsForBookRepository, DemandsForBookRepository>(new HierarchicalLifetimeManager());
        }

        private void RegisterTypeDataAccessEf()
        {

        }
    }
}