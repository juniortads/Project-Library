using Library.Application.Interface;
using Library.Domain.Entities;
using Library.Infra.Helper.Session;
using Library.Infra.Helper.Wcf;
using Library.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.UI.Web.Controllers
{
    public class DemandsForBookController : Controller
    {
        private DemandsForBookViewModel _viewModelBook;
        private ICommandDispatcher _dispacher;

        public DemandsForBookController()
        {
            _dispacher = new CommandDispatcher();
        }

        // GET: Library
        public ActionResult Index()
        {
            _viewModelBook = new DemandsForBookViewModel();
            _viewModelBook.DemandsForBooks = _dispacher.ExecuteCommand<IBookAppService, List<DemandsForBook>>(service => service.GetAllDemandsForBookByStudent(((Student)GlobalManager.UserCurrent).Id));
            return View(_viewModelBook);
        }

        public ActionResult NewDemand()
        {
            var books = new List<Book>();
            books = _dispacher.ExecuteCommand<IBookAppService, List<Book>>(service => service.GetAll().ToList());
            ViewBag.LstBooks = new SelectList(books.ToArray(), "Id", "Name");

            return View();
        }

        public ActionResult Search(string action_filter, string action_name)
        {
            _viewModelBook = new DemandsForBookViewModel();
            _viewModelBook.DemandsForBooks = _dispacher.ExecuteCommand<IBookAppService, List<DemandsForBook>>(service => service.GetAllDemandsForBookByStudent(((Student)GlobalManager.UserCurrent).Id));

            return PartialView("_AjaxSearchDemandsForBookList", _viewModelBook);
        }

        public JsonResult Insert(int idBook)
        {   
            string results = null;
            try
            {
                _dispacher.ExecuteCommand<IBookAppService>(s => s.CreateNewDemandsForBook(new DemandsForBook()
                {
                    Book = new Book() { Id = idBook },
                    Student = new Student() { Id = ((Student)GlobalManager.UserCurrent).Id }
                    
                }));
                results = "Record saved successfully!";
            }
            catch (Exception ex)
            {
                results = ex.Message;
            }
            return new JsonResult() { Data = results, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}