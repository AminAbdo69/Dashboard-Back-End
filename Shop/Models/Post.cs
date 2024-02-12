using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Shop.Models
{
	public class Post
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
        public string Date { get; set; }

        //public DateOnly Date { get; set; } 
        public string Descrition { get; set; }
		public bool Completed { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]

        
        public Category category { get; set; }

    }
}
