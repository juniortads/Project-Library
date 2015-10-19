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
        private readonly IDemandsForBookService _demandsForBookService;
        
        public BookAppService(IBookService clienteService, IDemandsForBookService demandsForBookService)
            : base(clienteService)
        {
            _bookService = clienteService;
            _demandsForBookService = demandsForBookService;
        }
        public void CreateNewDemandsForBook(DemandsForBook demand)
        {
            _demandsForBookService.Add(demand);
        }
        public List<DemandsForBook> GetAllDemandsForBookByStudent(int id)
        {
            return _demandsForBookService.GetAll().Where(o => o.Student.Id.Equals(id)).ToList();
        }
    }
}
