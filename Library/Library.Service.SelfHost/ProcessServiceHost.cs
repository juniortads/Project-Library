using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.SelfHost
{
    partial class ProcessServiceHost : ServiceBase
    {
        private readonly StartupServer _startupServer = new StartupServer();

        public ProcessServiceHost()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _startupServer.Run();
        }

        protected override void OnStop()
        {
            _startupServer.Dispose();
        }
    }
}
