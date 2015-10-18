using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Interfaces.Services;

namespace Library.Domain.Services
{
    public class BookService : ServiceBase<Book>, IBookService
    {
         private readonly IBookRepository _bookRepository;

         public BookService(IBookRepository bookRepository)
            : base(bookRepository)
        {
            _bookRepository = bookRepository;
        }
    }
}
