using Library.Application.Interface;
using Library.Domain.Entities;
using Library.Infra.Helper.Session;
using Library.Infra.Helper.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICommandDispatcher _dispacher;

        public HomeController()
        {
            _dispacher = new CommandDispatcher();
        }
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Authenticate(string email, string password)
        {
            if (_dispacher.ExecuteCommand<IStudentAppService, bool>(service => service.Authenticate(email, password)))
            {
                var user = _dispacher.ExecuteCommand<IStudentAppService, Student>(service => service.SearchByMail(email));
                if (user != null)
                {
                    GlobalManager.AddSession(user);
                    return RedirectToAction("Index", "Book");
                }
                else
                {
                    return View("Index");
                }

            }

            return View("Index");
        }
    }
}
