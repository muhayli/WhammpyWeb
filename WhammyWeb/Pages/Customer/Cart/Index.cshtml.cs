using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Whammy.DataAccess.Repository.IRepository;
using Whammy.Models;
using Whammy.Utility;

namespace WhammyWeb.Pages.Customer.Cart
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public double CartTotal { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CartTotal = 0;
        }
        public IEnumerable<ShoppingCart> shoppingCartList { get; set; }

        public void OnGet()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                shoppingCartList = _unitOfWork.shoppingCart.GetAll(filter: s => s.AppUserId == claim.Value, includeProps: "MenuItem,MenuItem.FoodType,MenuItem.Category");
                foreach (var cartItem in shoppingCartList)
                {
                    CartTotal += (cartItem.MenuItem.Price * cartItem.Count);
                }
            }
        }
        public IActionResult OnPostPlus(int cartId)
        {
            var cart = _unitOfWork.shoppingCart.GetFirstOrDefault(c => c.Id == cartId);
            _unitOfWork.shoppingCart.IncrementCount(cart, 1);
            return RedirectToPage("/Customer/Cart/Index");

        }
        public IActionResult OnPostMinus(int cartId)
        {
            var cart = _unitOfWork.shoppingCart.GetFirstOrDefault(c => c.Id == cartId);
            _unitOfWork.shoppingCart.decrementCount(cart, 1);
            return RedirectToPage("/Customer/Cart/Index");

        }
        public IActionResult OnPostRemove(int cartId)
        {
            var cart = _unitOfWork.shoppingCart.GetFirstOrDefault(c => c.Id == cartId);
            _unitOfWork.shoppingCart.Remove(cart);
            _unitOfWork.Save();
            return RedirectToPage("/Customer/Cart/Index");

        }
    }
}
