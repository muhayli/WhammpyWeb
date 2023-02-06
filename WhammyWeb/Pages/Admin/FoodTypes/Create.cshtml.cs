using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Whammy.DataAccess.Data;
using Whammy.DataAccess.Repository.IRepository;
using Whammy.Models;

namespace WhammyWeb.Pages.Admin.FoodTypes
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

        [BindProperty]
        public FoodType FoodType { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            //if (Category.Name == Category.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError(string.Empty, "The DisplayOrder cannot exactly match the Name!");
            //}
            if (ModelState.IsValid)
            {

                unitOfWork.foodType.Add(FoodType);
                unitOfWork.Save();
                TempData["success"] = $"{nameof(FoodType)} created successfully";
                return RedirectToPage("Index"); // redirects to the home page after submitting.
            }
            return Page();
        }
    }
}
