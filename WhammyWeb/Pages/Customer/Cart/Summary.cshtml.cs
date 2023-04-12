using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Whammy.Models;
using Whammy.DataAccess;
using Whammy.DataAccess.Repository.IRepository;
using Whammy.Utility;
using Microsoft.AspNetCore.Authorization;
using Stripe.Checkout;

namespace WhammyWeb.Pages.Customer
{
    [Authorize]
    [BindProperties]
    public class SummaryModel : PageModel
    {
        public IEnumerable<ShoppingCart> shoppingCartList { get; set; }

        private readonly IUnitOfWork _unitOfWork;

        public OrderHeader orderHeader { get; set; }

        public SummaryModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            orderHeader = new OrderHeader();
        }
        public void OnGet()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                shoppingCartList = _unitOfWork.shoppingCart.GetAll(filter: s => s.AppUserId == claim.Value, includeProps: "MenuItem,MenuItem.FoodType,MenuItem.Category");
                foreach (var cartItem in shoppingCartList)
                {
                    orderHeader.OrderTotal += (cartItem.MenuItem.Price * cartItem.Count);
                }
                AppUser appUser = _unitOfWork.appUser.GetFirstOrDefault(a => a.Id == claim.Value);
                orderHeader.pickupName = appUser.FirstName + ' ' + appUser.LastName;
                orderHeader.PhoneNumber = appUser.PhoneNumber;
            }
        }

        public IActionResult OnPost()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                shoppingCartList = _unitOfWork.shoppingCart.GetAll(filter: s => s.AppUserId == claim.Value, includeProps: "MenuItem,MenuItem.FoodType,MenuItem.Category");
                foreach (var cartItem in shoppingCartList)
                {
                    orderHeader.OrderTotal += (cartItem.MenuItem.Price * cartItem.Count);
                }
                orderHeader.OrderStatus = SD.StatusPending;
                orderHeader.OrderDate = System.DateTime.Now;
                orderHeader.AppUserId = claim.Value;
                orderHeader.PickUpTime = Convert.ToDateTime(orderHeader.PickUpDate.ToShortDateString() + " " + orderHeader.PickUpTime.ToLongTimeString());
                _unitOfWork.orderHeader.Add(orderHeader);
                _unitOfWork.Save();

                foreach (var item in shoppingCartList)
                {
                    OrderDetail od = new()
                    {
                        MenuItemId = item.MenuItem.Id,
                        OrderHeaderId = orderHeader.Id,
                        Name = item.MenuItem.Name,
                        Price = item.MenuItem.Price,
                        Count = item.Count
                    };

                    _unitOfWork.orderDetail.Add(od);
                }

                //_unitOfWork.shoppingCart.RemoveRange(shoppingCartList);
                _unitOfWork.Save();


                var domain = "http://localhost:21878";
                var options = new SessionCreateOptions
                {
                    LineItems = new List<SessionLineItemOptions>(),
                    Mode = "payment",
                    SuccessUrl = domain + $"/Customer/Cart/OrderConfirmation?id={orderHeader.Id}",
                    CancelUrl = domain + "/Customer/Cart/Index",
                };

                //add line items

                foreach (var item in shoppingCartList)
                {
                    var sessionLineItem = new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long)(item.MenuItem.Price * 100),
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = item.MenuItem.Name,
                            },

                        },

                        Quantity = item.Count

                    };

                    options.LineItems.Add(sessionLineItem);
                }


                var service = new SessionService();
                Session session = service.Create(options);

                orderHeader.SessionId = session.Id;
                orderHeader.PaymentIntentId = session.PaymentIntentId;

                _unitOfWork.Save();

                Response.Headers.Add("Location", session.Url);
                return new StatusCodeResult(303);
            }

            return Page();


        }
    }
}
