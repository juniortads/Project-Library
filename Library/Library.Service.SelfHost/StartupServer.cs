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

        private ServiceHost _serviceHost;

        public void Run()
        {
            var serviceFactory = new WcfServiceFactory();
            _serviceHost = serviceFactory.CreateServiceHostWithType(typeof(BookAppService));

            _serviceHost.Open();
        }
        public void Dispose()
        {
            _serviceHost.Close();
        }
    }
}
