using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Whammy.DataAccess.Data;
using Whammy.Models;

namespace WhammyWeb.Pages.Admin.FoodTypes
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        public EditModel(AppDbContext dbContext) => _dbContext = dbContext;


        [BindProperty]
        public FoodType FoodType { get; set; }

        public async void OnGet(int id)
        {
            //Category = await _dbContext.categories.FindAsync(id);
            FoodType = _dbContext.foodTypes.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _dbContext.foodTypes.Update(FoodType);
                await _dbContext.SaveChangesAsync();
                TempData["success"] = $"{nameof(FoodType)} updated successfully";
                return RedirectToPage("Index"); // redirects to the home page after submitting.
            }
            return Page();
        }
    }
}
