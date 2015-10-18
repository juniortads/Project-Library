using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interface
{
    [ServiceContract]
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        [OperationContract]
        void Add(TEntity obj);
        [OperationContract]
        TEntity GetById(int id);
        [OperationContract]
        IEnumerable<TEntity> GetAll();
        [OperationContract]
        void Update(TEntity obj);
        [OperationContract]
        void Remove(TEntity obj);
        void Dispose();
    }
}
