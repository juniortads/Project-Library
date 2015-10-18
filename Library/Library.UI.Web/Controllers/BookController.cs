using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Application.Interface;
using Library.Domain.Entities;
using Library.Infra.Helper.Wcf;
using Library.UI.Web.Models;

namespace Library.UI.Web.Controllers
{
    public class BookController : Controller
    {
        private BookViewModel _viewModelBook;
        private ICommandDispatcher _dispacher;

        public BookController()
        {
            _dispacher = new CommandDispatcher();
        }

        // GET: /Book/
        public ActionResult Index()
        {
            _viewModelBook = new BookViewModel();
            return View(_viewModelBook);
        }

        public ActionResult Search(string acao_filtro, string acao_name)
        {
            var lst = new List<Book>();
            //lst = _dispacher.ExecuteCommand<IBookAppService, List<Book>>(service => service.GetAll().ToList());

            _viewModelBook = new BookViewModel();

            for (int i = 0; i < 100; i++)
            {
                var books = new Book();
                books.Id = i;
                books.Name = "Name Book "+i;
                lst.Add(books);
            }
            _viewModelBook.Books = lst;

            return PartialView("_AjaxSearchBooksList", _viewModelBook);
        }
    }
}
