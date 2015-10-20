using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.Interface;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Services;
using Library.Infra.Helper.Session;

namespace Library.Application
{
    public class BookAppService : AppServiceBase<Book>, IBookAppService
    {
        private readonly IBookService _bookService;
        private readonly IDemandsForBookService _demandsForBookService;
        private readonly IStudentService _studentService;
        
        public BookAppService(IBookService clienteService, IDemandsForBookService demandsForBookService, IStudentService studentService)
            : base(clienteService)
        {
            _bookService = clienteService;
            _demandsForBookService = demandsForBookService;
            _studentService = studentService;
        }
        public void CreateNewDemandsForBook(DemandsForBook demand)
        {
            demand.Id = new Random().Next();
            demand.Book = _bookService.GetById(demand.Book.Id);
            demand.DateRequest = DateTime.Now;
            demand.TypeStateDemands = TypeStateDemands.Pending;
            demand.Student = _studentService.GetById(demand.Student.Id);

            _demandsForBookService.Add(demand);
        }
        public List<DemandsForBook> GetAllDemandsForBookByStudent(int id)
        {
            return _demandsForBookService.GetAll().Where(o => o.Student.Id.Equals(id)).ToList();
        }
    }
}
