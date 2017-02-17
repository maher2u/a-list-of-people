using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using a_list_of_people.Models;

namespace a_list_of_people.Controllers
{
    public class PeopleController : Controller
    {
        private static List<People> peoples;
        // GET: People

        public ActionResult Index()
        {
            if (peoples == null)
            {
                peoples = new List<People>();

                peoples.Add(new People
                {
                    ID = 1,
                    Name = "Maher",
                    Age=30,
                    Country = "Syria",
                    phonenumbers = "00000000"
                });
                peoples.Add(new People
                {
                    ID = 2,
                    Name = "Yaser",
                    Age = 56,
                    Country = "Syria",
                    phonenumbers = "00000000"
                });
                peoples.Add(new People
                {
                    ID = 3,
                    Name = "Kassem",
                    Age = 45,
                    Country = "Syria",
                    phonenumbers = "00000000"
                });
                peoples.Add(new People
                {
                    ID = 4,
                    Name = "Wassem",
                    Age = 20,
                    Country = "Syria",
                    phonenumbers = "00000000"
                });
                peoples.Add(new People
                {
                    ID = 5,
                    Name = "Nabel",
                    Country = "Syria",
                    Age = 23,
                    phonenumbers = "00000000"
                });
                peoples.Add(new People
                {
                    ID = 6,
                    Name = "Mohamad",
                    Age = 33,
                    Country = "Syria",
                    phonenumbers = "00000000"
                });
            }
            return View(peoples);
        }


        [HttpPost]
        public ActionResult Index(string searchTerm )
        {
            var people = peoples.Where(r => r.Name.StartsWith(searchTerm));
                                
            return View(people);
        }




        // GET: People/Details/5
        public ActionResult Details(int id)
        {
            People people = peoples.Single(s => s.ID == id);
            return View(people);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        public ActionResult Create(People people)
        {
            try
            {
                // TODO: Add insert logic here
                peoples.Add(people);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Edit/5
        public ActionResult Edit(int id)
        {
            People people = peoples.Single(a => a.ID == id);

            return View(people);
        }

        // POST: People/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, People people)
        {
            try
            {
                // TODO: Add update logic here
                People oldpeople = peoples.Single(a => a.ID == id);
                oldpeople.ID = people.ID;
                oldpeople.Name = people.Name;
                oldpeople.Country = people.Country;
                oldpeople.phonenumbers = people.phonenumbers;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Delete/5
        public ActionResult Delete(int id)
        {
            People people = peoples.Single(a => a.ID == id);
            return View(people);
        }

        // POST: People/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                People people = peoples.Single(a => a.ID == id);
                peoples.Remove(people);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
            public PartialViewResult OldestAge()
        {
            var age = peoples.OrderByDescending(r => r.Age).First();
                          
            return PartialView("_oldest", age);
        }

    
    }
}
