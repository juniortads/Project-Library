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
            _viewModelBook.Books = _dispacher.ExecuteCommand<IBookAppService, List<Book>>(service => service.GetAll().ToList());

            return View(_viewModelBook);
        }

        public ActionResult Search(string action_filter, string action_name)
        {
            _viewModelBook = new BookViewModel();
            var source = _dispacher.ExecuteCommand<IBookAppService, List<Book>>(service => service.GetAll().ToList());
            var sourceFilter = new List<Book>();

            switch (action_filter)
            {
                case "Description":
                    if (!string.IsNullOrWhiteSpace(action_name))
                        sourceFilter = source.Where(o => o.Name.Contains(action_name)).ToList();
                    else
                        sourceFilter = source;
                    break;
                default:
                    break;
            }

            _viewModelBook.Books = sourceFilter;
            return PartialView("_AjaxSearchBooksList", _viewModelBook);
        }
    }
}
