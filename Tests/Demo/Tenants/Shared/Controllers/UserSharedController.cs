using System.Web.Mvc;

namespace MvcMultiTenant.Demo.Tenants.Shared.Controllers
{
    public class UserSharedController : Controller
    {
        public ActionResult Landing()
        {
            return View("");
        }
    }
}
