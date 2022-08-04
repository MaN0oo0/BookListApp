using BookList.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Pages.BooksList
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationContext db;

        public DeleteModel(ApplicationContext db)
        {
            this.db = db;
        }
        [BindProperty]
        public Book book { get; set; }
        public async Task OnGet(int id)
        {
            book=await db.Books.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                db.Books.Remove(book);
                await db.SaveChangesAsync();
                return RedirectToPage("index");

            }
            else
            {
                return Page();
            }
        }

    }
}
