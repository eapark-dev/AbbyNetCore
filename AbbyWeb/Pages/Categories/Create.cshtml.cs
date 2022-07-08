using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories;

[BindProperties]
public class CreateModel : PageModel
{
    public readonly ApplicationDbContext _db;
    public Category Category { get; set; }

    public CreateModel(ApplicationDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost(Category category)
    {
        if (Category.Name == Category.DisplayOrder.ToString())
        {
            ModelState.AddModelError(string.Empty, "이름과 순서가 같습니다.");
        }

        if (ModelState.IsValid)
        { 
            //비동기식 DB 저장
            await _db.Category.AddAsync(category);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }

        return Page();
    }
}
