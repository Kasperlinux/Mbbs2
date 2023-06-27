using Mbbs2.Data;
using Mbbs2.Models;
using Mbbs2.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mbbs2.Controllers
{
    public class UserController : Controller
    {
        private readonly DhsMagacousesContext context;

        public UserController(DhsMagacousesContext context)
        {
            this.context = new DhsMagacousesContext();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data= await context.DHSs.ToListAsync();
            return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(DhsViewModel addDHSRequest)
        {
            var dhs = new DHS()
            {
                Id = Guid.NewGuid(),
                Name = addDHSRequest.Name,
                Contact = addDHSRequest.Contact,
                Email = addDHSRequest.Email,
                Password = addDHSRequest.Password
            };

            await context.DHSs.AddAsync(dhs);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var DHS = await context.DHSs.FirstAsync(x => x.Id == id);
            if (DHS != null)
            {
                var viewModel = new UpdateDHSViewModel()
                {
                    Id = DHS.Id,
                    Name = DHS.Name,
                    Contact = DHS.Contact,
                    Email = DHS.Email,
                    Password = DHS.Password
                };

                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateDHSViewModel model)
        {
            var DHS = await context.DHSs.FindAsync(model.Id);
            if (DHS != null)
            {
                DHS.Name = model.Name;
                DHS.Contact = model.Contact;
                DHS.Email = model.Email;
                DHS.Password = model.Password;

                await context.SaveChangesAsync();

                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");


        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateDHSViewModel model)
        {
            var DHS = await context.DHSs.FindAsync(model.Id);

            if (DHS != null)
            {
                context.DHSs.Remove(DHS);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }

}

