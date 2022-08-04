using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookList.Model
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name Is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = " Author Name Is Required")]
        public string Author { get; set; }

        public string ISBN { get; set; }

    }
}
