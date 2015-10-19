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

        public ActionResult Search(string action_filter, string action_name)
        {
            _viewModelBook = new BookViewModel();
            _viewModelBook.Books = _dispacher.ExecuteCommand<IBookAppService, List<Book>>(service => service.GetAll().ToList());

            return PartialView("_AjaxSearchBooksList", _viewModelBook);
        }
    }
}
