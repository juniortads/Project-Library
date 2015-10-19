using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 0 && args[0] == "-c")
            {
                using (var server = new StartupServer())
                {
                    server.Run();
                    
                    Console.WriteLine("####### WCF Service started ... Hit enter to stop!!!!");
                    Console.WriteLine(Environment.NewLine);

                    Console.ReadLine();
                }
            }
            else
            {

            }
        }
    }
}
