using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspEx10.Models;

namespace AspEx10.Controllers
{
    public class HomeController : Controller
    {
        private IPeopleRepository repository;
        public HomeController(IPeopleRepository repo)
        {
            repository = repo;
        }
        
        public IActionResult Index()
        {
            
            return View(repository.People);
        }
        [HttpPost]
        public IActionResult Index(string Name)
        {
            return View(repository.People.Where(a => a.Name == Name));
        }
        //return View(Repository.Responses.Where(r => r.WillAttend == true));

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person newPEEPs)
        {

            if (ModelState.IsValid)
            {
                repository.CreatePerson(newPEEPs);

                return RedirectToAction("Index");
            }
            else
            {
                return View(newPEEPs);
            }
        }
    
        
    }
}
