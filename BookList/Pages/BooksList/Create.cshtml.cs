using BookList.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BookList.Pages.BooksList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationContext db;

        public CreateModel(ApplicationContext db)
        {
            this.db = db;
        }
        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
               await db.Books.AddAsync(Book);
              await  db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
