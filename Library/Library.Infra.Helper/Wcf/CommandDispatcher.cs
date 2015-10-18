using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infra.Helper.Wcf
{
    public class CommandDispatcher : ICommandDispatcher
    {
        public TResult ExecuteCommand<TService, TResult>(Func<TService, TResult> command) where TService : class
        {
            using (var proxy = new WcfProxy<TService>())
            {
                try
                {
                    proxy.Open();
                    var result = command.Invoke(proxy.WcfChanel);
                    return result;
                }
                finally
                {
                    proxy.Close();
                }
            }
        }

        public async Task<TResult> ExecuteCommandAsync<TService, TResult>(Func<TService, TResult> command) where TService : class
        {
            return await Task.Run<TResult>(() => { return ExecuteCommand(command); });
        }

        private class WcfProxy<TService> : ClientBase<TService> where TService : class
        {
            public TService WcfChanel
            {
                get { return Channel; }
            }
        }
    }
}
