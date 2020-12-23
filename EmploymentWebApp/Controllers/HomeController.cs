using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentWebApp.Controllers
{
    public class HomeController: Controller
    {
        public JsonResult Index()
        {
            return Json(new {id=1, name="Ahmed"});
        }
    }
}