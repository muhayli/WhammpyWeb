using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Whammy.DataAccess.Repository.IRepository;
using Whammy.Models;

namespace WhammyWeb.Pages.Admin.Categories
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;

        public EditModel(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;


        [BindProperty]
        public Category Category { get; set; }

        public async void OnGet(int id)
        {
            //Category = await _dbContext.categories.FindAsync(id);
            Category = unitOfWork.category.GetFirstOrDefault(c => c.Id == id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty, "The DisplayOrder cannot exactly match the Name!");
            }
            if (ModelState.IsValid)
            {
                unitOfWork.category.Update(Category);
                unitOfWork.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index"); // redirects to the home page after submitting.
            }
            return Page();
        }
    }
}
