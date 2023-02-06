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
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;


        [BindProperty]
        public FoodType FoodType { get; set; }

        public async void OnGet(int id)
        {
            //Category = await _dbContext.categories.FindAsync(id);
            FoodType = unitOfWork.foodType.GetFirstOrDefault(f => f.Id == id);
        }
        public async Task<IActionResult> OnPost()
        {
            var foodTypeFromDb = unitOfWork.foodType.GetFirstOrDefault(f => f.Id == FoodType.Id);
            if (foodTypeFromDb != null)
            {
                unitOfWork.foodType.Remove(foodTypeFromDb);
                unitOfWork.Save();
                TempData["success"] = $"{nameof(FoodType)} deleted successfully";
                return RedirectToPage("Index"); // redirects to the home page after submitting.
            }
            return Page();
        }
    }
}
