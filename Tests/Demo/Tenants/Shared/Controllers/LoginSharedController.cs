using System.Web.Mvc;

namespace MvcMultiTenant.Demo.Tenants.Shared.Controllers
{
    public class LoginSharedController : Controller
    {
        [HttpPost]
        public ActionResult Authenticate()
        {
            return RedirectToAction("Landing", "User");
        }
    }
}
