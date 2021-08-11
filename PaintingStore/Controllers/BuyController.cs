using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PaintingStore.Models;
using PaintingStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintingStore.Controllers
{
    public class BuyController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly DatabaseContext databaseContext;

        public BuyController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, DatabaseContext databaseContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.databaseContext = databaseContext;
        }
        [Authorize]
        public IActionResult BuyMembership()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BuyMembership(BuyMembershipView buyMemberShipView)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(userManager.GetUserId(HttpContext.User));
                user.Membership = buyMemberShipView.Membership;
                await userManager.UpdateAsync(user);
                return View("BuyingMembershipSuccessful");
            }
            return View();
        }
        
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> BuyPainting(string id)
        {
            int y = Convert.ToInt32(id);
            PaintingView paint = (PaintingView)databaseContext.PaintingView.Find(y);
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            int membership = 0;
            if (user.Membership == "Platinum")
            {
                membership = 30;
            }
            else if (user.Membership == "Gold")
            {
                membership = 20;
            }
            else if (user.Membership == "Silver")
            {
                membership = 10;
            }
            else
            {
                membership = 0;
            }
            ViewBag.Membership = membership;
            ViewBag.Artist = paint.Artist;
            ViewBag.Name = paint.Name;
            ViewBag.PhotoPath = paint.PhotoPath;
            ViewBag.Id = paint.Id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BuyPainting(BuyPaintingView buyPaintingView, string id)
        {
            int y = Convert.ToInt32(id);
            PaintingView paint = (PaintingView)databaseContext.PaintingView.Find(y);
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            int membership = 0;
            if (user.Membership == "Platinum")
            {
                membership = 30;
            }
            else if (user.Membership == "Gold")
            {
                membership = 20;
            }
            else if (user.Membership == "Silver")
            {
                membership = 10;
            }
            else
            {
                membership = 0;
            }
            ViewBag.Membership = membership;
            ViewBag.Artist = paint.Artist;
            ViewBag.Name = paint.Name;
            ViewBag.PhotoPath = paint.PhotoPath;
            ViewBag.Id = paint.Id;
            if (ModelState.IsValid)
            {
                if (buyPaintingView.Term)
                {
                    return View("CongratulationsForBuying");
                }
                ModelState.AddModelError("", "Without your consent Buying process can't be done");
                return View();
            }
            ModelState.AddModelError("", "Without your consent Buying process can't be done");
            return View();
        }


    }
}
