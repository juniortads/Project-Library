using Library.Application;
using Library.Application.Interface;
using Library.Infra.Data.Manager;
using Library.Infra.IoC;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.SelfHost
{
    internal class StartupServer : IDisposable
    {
        internal StartupServer()
        {
            DataAccessManagerFactory.Init(TypeDataAccess.MongoDb);
        }

        private ServiceHost _serviceHostBooks;
        private ServiceHost _serviceHostStudents;

        public void Run()
        {
            var serviceFactory1 = new WcfServiceFactory();
            var serviceFactory2 = new WcfServiceFactory();

            _serviceHostBooks = serviceFactory1.CreateServiceHostWithType(typeof(BookAppService));
            _serviceHostStudents = serviceFactory2.CreateServiceHostWithType(typeof(StudentAppService));

            _serviceHostBooks.Open();
            _serviceHostStudents.Open();
        }
        public void Dispose()
        {
            _serviceHostBooks.Close();
            _serviceHostStudents.Close();
        }
    }
}
