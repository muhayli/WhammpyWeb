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
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        public DeleteModel(AppDbContext dbContext) => _dbContext = dbContext;


        [BindProperty]
        public Category Category { get; set; }

        public async void OnGet(int id)
        {
            //Category = await _dbContext.categories.FindAsync(id);
            Category = _dbContext.categories.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
            var categoryFromDb = _dbContext.categories.Find(Category.Id);
            if (categoryFromDb != null)
            {
                _dbContext.categories.Remove(categoryFromDb);
                await _dbContext.SaveChangesAsync();
                TempData["success"] = "Category deleted successfully";
                return RedirectToPage("Index"); // redirects to the home page after submitting.
            }
            return Page();
        }
    }
}
