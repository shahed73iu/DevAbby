using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class CategoryDeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        //[BindProperty] for a single property
        public Category Category { get; set; }
        public CategoryDeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            Category = _db.Categories.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
            var categoryFromDb = _db.Categories.Find(Category.Id);
            if (categoryFromDb != null)
            {
                _db.Categories.Remove(categoryFromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category Deleted Successfully!!";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
