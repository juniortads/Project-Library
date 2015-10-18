using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.Interface;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Services;

namespace Library.Application
{
    public class BookAppService : AppServiceBase<Book>, IBookAppService
    {
        private readonly IBookService _bookService;

        public BookAppService(IBookService clienteService)
            : base(clienteService)
        {
            _bookService = clienteService;
        }
    }
}
