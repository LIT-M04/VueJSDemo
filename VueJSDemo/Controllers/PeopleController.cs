using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vue.Data;

namespace VueJSDemo.Controllers
{
    public class PeopleController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get()
        {
            var repo = new PeopleRepository(Properties.Settings.Default.ConStr);
            return Json(repo.GetPeople(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void Add(Person person)
        {
            var repo = new PeopleRepository(Properties.Settings.Default.ConStr);
            repo.Add(person);
        }

        [HttpPost]
        public void Update(Person person)
        {
            var repo = new PeopleRepository(Properties.Settings.Default.ConStr);
            repo.Update(person);
        }

        [HttpPost]
        public void Delete(int id)
        {
            var repo = new PeopleRepository(Properties.Settings.Default.ConStr);
            repo.Delete(id);
        }


    }
}
