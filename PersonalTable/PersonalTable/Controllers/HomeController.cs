using PersonalTable.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static PersonalTable.Models.Person;

namespace PersonalTable.Controllers
{
    public class HomeController : Controller
    {
        protected PersonContext db = new PersonContext();

        public ActionResult Index()
        {


            ViewModel model = new ViewModel()
            {
                Person = db.Persons.ToList(),

            };


            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            PersonWM model = new PersonWM();
            ViewBag.Positions = db.Positions.ToList();
            Person person = db.Persons.Find(id);
            string days = db.Persons.Where(m => m.Id == id).FirstOrDefault().Days;
            if (!string.IsNullOrEmpty(days))
            {
               
                List<string> week = days.Split(',').ToList();
                List<int> Week = week.Select(int.Parse).ToList();


                

                foreach (var item in Week)
                {
                    switch (item)
                    {
                        case 1:
                            model.Be = true;
                            break;
                        case 2:
                            model.Ca = true;
                            break;
                        case 3:
                            model.C = true;
                            break;
                        case 4:
                            model.CumaA = true;
                            break;
                        case 5:
                            model.Cuma = true;
                            break;
                        case 6:
                            model.S = true;
                            break;
                        case 7:
                            model.B = true;
                            break;
                    }

                }
            }
            


            if (person != null)
            {

                model.Person = person;
                model.Enterdate = person.EnterDate.ToString("HH:mm");
                model.Exitdate = person.ExitDate.ToString("HH:mm");
                    

                
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }


        }
        [HttpPost]
        public ActionResult Editt( HttpPostedFileBase File , PersonWM personWM)
        {
            string pName = "";
            string img = "";
            string days = "";
            string d = ",";
            
           var p = db.Persons.Where(m => m.Id == personWM.Person.Id).FirstOrDefault();
            if (personWM.Be)
            {
                days += "1" ;
            }
            if (personWM.Ca)
            {
                days+=  d+"2";
            }
            if (personWM.C)
            {
                days += d + "3";
            }
            if (personWM.CumaA)
            {
                days += d + "4";
            }
            if (personWM.Cuma)
            {
                days += d + "5";
            }
            if (personWM.S)
            {
                days += d + "6";
            }
            if (personWM.B)
            {
                days += d + "7";
            }
            if (days.StartsWith(","))
            {
                days = days.Substring(1);
            }
            p.Days = days;
            if (File != null)
            {
                pName = DateTime.Now.ToString("yyyyMMddHHffss") + File.FileName;
                img = Path.Combine(Server.MapPath("~/Uploads"), pName);
                File.SaveAs(img);
                p.Photo = pName;
            }
            p.Name = personWM.Person.Name;
            p.Surname = personWM.Person.Surname;
            p.PositionId = personWM.Person.PositionId;
            p.EnterDate = personWM.Person.EnterDate;
            p.ExitDate = personWM.Person.ExitDate;
             
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();

            ViewModel model = new ViewModel()
            {
                Person = db.Persons.ToList(),

            };
            return RedirectToAction("index", model);
        }
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Positions = db.Positions.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Add(Person person, List<int> week, HttpPostedFileBase Photo)
        {
            string days = "";
            string pName = "";
            string img = "";
            Person p = new Person();
            p.Name = person.Name;
            p.Surname = person.Surname;
            p.EnterDate = person.EnterDate;
            p.ExitDate = person.ExitDate;
            if (Photo != null)
            {
                pName = DateTime.Now.ToString("yyyyMMddHHmmss") + Photo.FileName;
                img = Path.Combine(Server.MapPath("~/Uploads"), pName);

                Photo.SaveAs(img);
                p.Photo = pName;
            }

            if (week != null)
            {
                foreach (var w in week)
                {
                    days = days + w.ToString() + ",";
                };


                days = days.Remove(days.Length - 1);
                p.Days = days;
            }
            ViewModel model = new ViewModel()
            {
                Person = db.Persons.ToList(),

            };
            p.PositionId = person.PositionId;
            db.Persons.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index", model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var person = db.Persons.Find(id);
            if (person!= null)
            {
                db.Persons.Remove(person);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult See(int id)
        {
            PersonWM model = new PersonWM();
            ViewBag.Positions = db.Positions.ToList();
            Person person = db.Persons.Find(id);
            string days = db.Persons.Where(m => m.Id == id).FirstOrDefault().Days;
            if (!string.IsNullOrEmpty(days))
            {

                List<string> week = days.Split(',').ToList();
                List<int> Week = week.Select(int.Parse).ToList();




                foreach (var item in Week)
                {
                    switch (item)
                    {
                        case 1:
                            model.Be = true;
                            break;
                        case 2:
                            model.Ca = true;
                            break;
                        case 3:
                            model.C = true;
                            break;
                        case 4:
                            model.CumaA = true;
                            break;
                        case 5:
                            model.Cuma = true;
                            break;
                        case 6:
                            model.S = true;
                            break;
                        case 7:
                            model.B = true;
                            break;
                    }

                }
            }



            if (person != null)
            {

                model.Person = person;
                model.Enterdate = person.EnterDate.ToString("HH:mm");
                model.Exitdate = person.ExitDate.ToString("HH:mm");



                return View(model);
            }
            else
            {
                return HttpNotFound();
            }


        }

       
        [HttpGet]
        public ActionResult AddPosition()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult AddPosition(Position position)
        {
            if (position != null)
            {
                db.Positions.Add(position);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}