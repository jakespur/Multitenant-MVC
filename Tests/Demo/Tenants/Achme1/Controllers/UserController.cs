using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMultiTenant.Demo.Tenants.Achme1.Controllers
{
    using MvcMultiTenant.Demo.Tenants.Shared.Controllers;

    public class UserController : UserSharedController
    {
        public ActionResult DeleteAccount()
        {
            return View("DeleteAccount");
        }

    }
}
