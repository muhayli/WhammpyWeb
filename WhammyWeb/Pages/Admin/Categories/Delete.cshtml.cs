using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Whammy.DataAccess.Data;
using Whammy.DataAccess.Repository.IRepository;
using Whammy.Models;

namespace WhammyWeb.Pages.Admin.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;


        [BindProperty]
        public Category Category { get; set; }

        public async void OnGet(int id)
        {
            //Category = await _dbContext.categories.FindAsync(id);
            Category = unitOfWork.category.GetFirstOrDefault(c => c.Id == id);
        }
        public async Task<IActionResult> OnPost()
        {
            var categoryFromDb = unitOfWork.category.GetFirstOrDefault(c => c.Id == Category.Id);
            if (categoryFromDb != null)
            {
                unitOfWork.category.Remove(categoryFromDb);
                unitOfWork.Save();
                TempData["success"] = "Category deleted successfully";
                return RedirectToPage("Index"); // redirects to the home page after submitting.
            }
            return Page();
        }
    }
}
