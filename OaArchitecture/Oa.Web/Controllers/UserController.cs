using Microsoft.AspNetCore.Mvc;

namespace Oa.Web.Controllers
{
    public class UserController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}