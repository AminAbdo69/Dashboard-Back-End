namespace Shop.Models
{
	public class Post
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public DateOnly Date { get; set; }
		public string Descrition { get; set; }
		public bool Completed { get; set; }
		public Category category { get; set; }
	}
}
