using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using UphiweSkills.Models;

namespace UphiweSkills.Controllers
{
    public class RoleController : Controller
    {

        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        private ApplicationUserManager _userManager;
        
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        // GET: Role
        public ActionResult Index()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_dbContext));
            return View(roleManager.Roles.ToList());
        }

        // GET: Role/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel model)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_dbContext));

            if (ModelState.IsValid)
            {
                IdentityResult result = null;

                if (!roleManager.RoleExists(model.Name))
                {
                    result = await roleManager.CreateAsync(new IdentityRole(model.Name));
                }
                else
                {
                    ModelState.AddModelError("", "Role already exists.");
                }

                try
                {
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Role not Saved.");
                }

            }

            return View(model);
        }

        // GET: Role/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Role/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
