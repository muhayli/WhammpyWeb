using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WhammyWeb.Data;
using WhammyWeb.Models;

namespace WhammyWeb.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        public EditModel(AppDbContext dbContext) => _dbContext = dbContext;


        [BindProperty]
        public Category Category { get; set; }

        public async void OnGet(int id)
        {
            //Category = await _dbContext.categories.FindAsync(id);
            Category = _dbContext.categories.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty, "The DisplayOrder cannot exactly match the Name!");
            }
            if (ModelState.IsValid)
            {

                _dbContext.categories.Update(Category);
                await _dbContext.SaveChangesAsync();
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index"); // redirects to the home page after submitting.
            }
            return Page();
        }
    }
}
