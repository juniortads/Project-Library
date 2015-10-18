using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infra.Helper.Wcf
{
    public interface ICommandDispatcher
    {
        TResult ExecuteCommand<TService, TResult>(Func<TService, TResult> command) where TService : class;
        Task<TResult> ExecuteCommandAsync<TService, TResult>(Func<TService, TResult> command) where TService : class;
    }
}
