using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace Library.Service.SelfHost
{
    [RunInstaller(true)]
    public partial class ProcessServiceInstaller : System.Configuration.Install.Installer
    {
        private const string Name = "LibraryService";

        public ProcessServiceInstaller()
        {
            var serviceProcessInstaller = new ServiceProcessInstaller();
            var serviceInstaller = new ServiceInstaller();

            serviceProcessInstaller.Account = ServiceAccount.NetworkService;
            serviceProcessInstaller.Username = null;
            serviceProcessInstaller.Password = null;

            serviceInstaller.DisplayName = "CrossOver Service Library";
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.ServiceName = Name;

            this.Installers.Add(serviceProcessInstaller);
            this.Installers.Add(serviceInstaller);

        }
    }
}
