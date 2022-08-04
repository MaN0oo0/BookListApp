
using BookList.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace BookList.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationContext db;

        public BookController(ApplicationContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new {data=db.Books.ToList()});
        }

        [HttpDelete]
 
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb = await db.Books.FirstOrDefaultAsync(u => u.Id == id);
            if (bookFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            db.Books.Remove(bookFromDb);
            await db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
