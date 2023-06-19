using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mbbs2.Controllers
{
    public class AppRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AppRolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        //List all the Roles created by Users
        public IActionResult Index()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IdentityRole model)
        {
            //avoid duplicate role
            if (!roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");
        }
    }
}
