using Library.Domain.Interfaces.Repositories;
using Library.Domain.Interfaces.Services;
using Library.Domain.Services;
using Library.Infra.Data.Repositories;
using Microsoft.Practices.Unity;
using Unity.Wcf;

namespace Library.Infra.IoC
{
    public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterType<IBookService, BookService>().
            RegisterType<IBookRepository,BookRepository>(new HierarchicalLifetimeManager());
        }
    }
}