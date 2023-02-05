using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Whammy.DataAccess.Data;
using Whammy.Models;

namespace WhammyWeb.Pages.Admin.Categories
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        public CreateModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        public Category Category { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty, "The DisplayOrder cannot exactly match the Name!");
            }
            if (ModelState.IsValid)
            {

                await _dbContext.AddAsync(Category);
                await _dbContext.SaveChangesAsync();
                TempData["success"] = "Category created successfully";
                return RedirectToPage("Index"); // redirects to the home page after submitting.
            }
            return Page();
        }
    }
}
