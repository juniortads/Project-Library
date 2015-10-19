using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Entities;

namespace Library.Application.Interface
{
    public interface IBookAppService : IAppServiceBase<Book>
    {
        void CreateNewDemandsForBook(DemandsForBook demand);

        List<DemandsForBook> GetAllDemandsForBookByStudent(int id);
    }
}
