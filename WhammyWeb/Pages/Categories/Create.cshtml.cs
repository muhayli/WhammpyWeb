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
            await _dbContext.AddAsync(Category);
            await _dbContext.SaveChangesAsync();
            return RedirectToPage("Index"); // redirects to the home page after submitting.
        }
    }
}
