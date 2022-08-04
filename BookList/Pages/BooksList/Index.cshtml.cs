using BookList.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Pages.BooksList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationContext db;

        public IndexModel(ApplicationContext db)
        {
            this.db = db;
        }

        public IEnumerable<Book>books { get; set; }
     
        public async Task OnGet()
        {
            books = await db.Books.ToListAsync();
        }


        public async Task <IActionResult>OnPostDelete(int id)
        {
            var book=await db.Books.FindAsync(id);
            if (book==null)
            {
                return NotFound();
            }

             db.Books.Remove(book);
            await db.SaveChangesAsync();
            return RedirectToPage("Index");

        }
    }
}
