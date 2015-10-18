using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Infra.Data.MongoDb;

namespace Library.Infra.Data.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        //other specific methods...
    }
}
