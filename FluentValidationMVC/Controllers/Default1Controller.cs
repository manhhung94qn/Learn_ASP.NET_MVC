using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.Mvc;

using FluentValidation.Results;

using FluentValidationMVC.Models;

namespace FluentValidationMVC.Controllers
{
    public class Default1Controller : Controller
    {
        // GET: Default1
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Student objStudent)

        {
            StudentValidator validator = new StudentValidator();

            ValidationResult result = validator.Validate(objStudent);

            if (result.IsValid)
            {

            } else
            {
                foreach(ValidationFailure failure in result.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
            }

            return View(objStudent);

        }
    }
}