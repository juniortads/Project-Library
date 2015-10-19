using Library.Application.Interface;
using Library.Domain.Entities;
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

         

            return View(_viewModelBook);
        }

        public ActionResult NewDemand()
        {
            var lst = new List<Book>();
            lst.Add(new Book() { Id = 1, Name = "Jack" });
            lst.Add(new Book() { Id = 2, Name = "Jack 2" });

            ViewBag.LstBooks = new SelectList(lst.ToArray(), "Id", "Name");

            return View();
        }

        public ActionResult Search(string action_filter, string action_name)
        {
            var lst = new List<DemandsForBook>();
            //lst = _dispacher.ExecuteCommand<IBookAppService, List<DemandsForBook>>(service => service.GetAllDemandsForBookByStudent(1));

            _viewModelBook = new DemandsForBookViewModel();

            for (int i = 0; i < 100; i++)
            {
                var demands = new DemandsForBook();
                demands.Id = i;
                demands.Book = new Book() { Id = 1, Author = "Jack", Name = "Fuga", PublishingHouse = "Editora" };
                demands.Student = new Student() { Id = 1010, Age = DateTime.Now, Name = "JR" };
                lst.Add(demands);
            }
            _viewModelBook.DemandsForBooks = lst;

            return PartialView("_AjaxSearchDemandsForBookList", _viewModelBook);
        }

        public JsonResult Insert(int idBook)
        {   
            string results = null;
            try
            {
                //
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