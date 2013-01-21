using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMultiTenant.Demo.Tenants.Shared.Controllers
{
    public class HomeSharedController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
