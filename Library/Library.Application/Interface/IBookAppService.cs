using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Entities;
using System.ServiceModel;

namespace Library.Application.Interface
{
    [ServiceContract]
    public interface IBookAppService : IAppServiceBase<Book>
    {
        [OperationContract]
        void CreateNewDemandsForBook(DemandsForBook demand);

        [OperationContract]
        List<DemandsForBook> GetAllDemandsForBookByStudent(int id);
    }
}
