using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Whammy.DataAccess.Repository.IRepository;
using Whammy.Models;

namespace WhammyWeb.Pages.Customer.Home
{
    [Authorize]
    [BindProperties]
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;
        //public MenuItem MenuItem { get; set; }

        //[Range(1, 100, ErrorMessage = "Please select count between 1 and 100")]
        //public int Count { get; set; }

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ShoppingCart ShoppingCart { get; set; }



        public void OnGet(int id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ShoppingCart = new ShoppingCart
            {
                AppUserId = claim.Value,
                MenuItem = unitOfWork.menuItem.GetFirstOrDefault(m => m.Id == id, includeProps: "Category,FoodType"),
                MenuItemId = id

            };
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                ShoppingCart shoppingCartFromDb = unitOfWork.shoppingCart.GetFirstOrDefault(filter: s => s.AppUserId == ShoppingCart.AppUserId && s.MenuItemId == ShoppingCart.MenuItemId);
                if (shoppingCartFromDb == null)
                {
                    unitOfWork.shoppingCart.Add(ShoppingCart);
                    unitOfWork.Save();

                }
                else
                {
                    unitOfWork.shoppingCart.IncrementCount(shoppingCartFromDb, ShoppingCart.Count);
                }

                return RedirectToPage("Index");
            }
            return Page();
        }

    }
}
