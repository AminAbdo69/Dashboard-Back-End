using Shop.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Shop.Models
{
	public class Post
	{



        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z''-'\s]{1,40}$",
            ErrorMessage = "Charactters In Author Name Are Not Allowed.")]
        public string Author { get; set; }
        public string Date { get; set; }

        //public DateOnly Date { get; set; } 

        [Required]
        [RegularExpression(@"[a-zA-Z''-'\s]{1,40}$",
                  ErrorMessage = "Charactters In Descrition Are Not Allowed.")]
        public string Descrition { get; set; }
		public bool Completed { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]

        
        public Category category { get; set; }

    }
}
