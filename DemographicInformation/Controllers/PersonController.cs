using System;
using System.Web.Mvc;
using System.Text;

using DemographicInformation.Models;
using DemographicInformation.Repository;

namespace DemographicInformation.Controllers
{
    public class PersonController : Controller
    {
        private IPerson<Person> person;

        public PersonController()
        {
            this.person = new PersonRepository<Person>();
        }

        public ActionResult Persons()
        {
            var personList = person.GetPersons();
            return View(personList);
        }

        [HttpGet]
        public PartialViewResult Create()
        {
            var personInfo = new Person();
            return PartialView(personInfo);
        }

        [HttpGet]
        public PartialViewResult Edit(int id)
        {
            var personTemp = person.GetPersonByID(id);
            return PartialView(personTemp);
        }

        [HttpPost]
        public JsonResult Edit(Person personToUpdate)
        {
            if (ModelState.IsValid)
            {
                personToUpdate.LastUpdatedOn = DateTime.Now;
                personToUpdate.LastUpdatedBy = 1;
                person.UpdatePerson(personToUpdate);
                person.Save();
                return Json(new { result = true });
            }
            else
            {
                var modelErrors = new StringBuilder();
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var modelError in modelState.Errors)
                    {
                        modelErrors.Append(modelError.ErrorMessage + Environment.NewLine);
                    }
                }
                return Json(new { result = false, error = modelErrors.ToString() });
            }
        }

        [HttpPost]
        public JsonResult Delete(string ids)
        {
            if (!string.IsNullOrWhiteSpace(ids))
            {
                person.DeletePerson(ids);
                person.Save();
                return Json(new { result = true });
            }
            else
            {
                var modelErrors = new StringBuilder();
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var modelError in modelState.Errors)
                    {
                        modelErrors.Append(modelError.ErrorMessage + Environment.NewLine);
                    }
                }
                return Json(new { result = false, error = modelErrors.ToString() });
            }
        }

        [HttpPost]
        public JsonResult Save(Person newPerson)
        {
            if (ModelState.IsValid)
            {
                newPerson.CreatedOn = DateTime.Now;
                newPerson.CreatedBy = 1;

                person.CreatePerson(newPerson);
                person.Save();
                return Json(new { result = true });
            }
            else
            {
                var modelErrors = new StringBuilder();
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var modelError in modelState.Errors)
                    {
                        modelErrors.Append(modelError.ErrorMessage + Environment.NewLine);
                    }
                }
                return Json(new { result = false, error = modelErrors.ToString() });
            }
        }
    }
}
