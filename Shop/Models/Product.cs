using System.Reflection.Metadata.Ecma335;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shop.Controllers;

namespace Shop.Models
{
	public class Product

	{
		[Key]
		public int Id { get; set; }

		[Required]
		[RegularExpression(@"[a-zA-Z''-'\s]{1,40}$" ,
			ErrorMessage ="Charactters Are Not Allowed.")]
		public string Name { get; set; }

		[Required]
		[MinLength(5)]
		[MaxLength(50)]
		[RegularExpression(@"[a-zA-Z''-'\s]{1,40}$",
			ErrorMessage = "Charactters Are Not Allowed.")]
		public string Description { get; set; }

        [Required]
		[Range(1 ,50000 , ErrorMessage = "Please Enter Price From 1 To 50000")]
		[CheckMaxCompanyPriceAttribute(30000)]
        public float Price { get; set; }

        [Required]

        public int	Quantity { get; set; }
		public bool EnableSize { get; set; }
		public int CompanyId { get; set; }
		[ForeignKey("CompanyId")]
        public Company? company { get; set; }

	}
}
