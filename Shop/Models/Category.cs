using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
	public class Category
	{
        //Data Anotation like key ,required and so on
        [Key]//to Make this prop the primary Key
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
