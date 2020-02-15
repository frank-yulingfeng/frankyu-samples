using MvcDemo.Helpers;
using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Pager(int? page)
        {
            if (!page.HasValue || page.Value < 1)
                page = 1;

            ViewBag.Message = "Pager Demo page";
            var PAGE_SZ = 6;
            var people = GetRecords();
            var recordCount = people.Count();
            people = people.Skip((page.Value - 1) * PAGE_SZ).Take(PAGE_SZ).ToList();
            ViewBag.Pager = new Pager()
            {
                PageIndex = page.Value,
                PageSize = PAGE_SZ,
                RecordCount = recordCount,
            };

            return View(people);
        }

        private List<PersonViewModel> GetRecords()
        {
            var people = new List<PersonViewModel>();

            for (int i = 0; i < 100; i++)
            {
                people.Add(new PersonViewModel
                {
                    FirstName = "Kobe" + i,
                    LastName = "Bryant",
                    Gender = Gender.Male,
                    Age = 30 + (i % 3),
                    EmailAddress = "kobe@email.com",
                });
            }
            return people;
        }
    }
}