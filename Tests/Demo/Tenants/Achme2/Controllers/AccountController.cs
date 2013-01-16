namespace MvcMultiTenant.Demo.Tenants.Achme2.Controllers
{
    using System.Web.Mvc;

    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return this.View();
        }

    }
}
