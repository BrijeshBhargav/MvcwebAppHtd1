namespace MVCcoreWebAppHTD1.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string  Author { get; set; }
        public string Description { get; set; }

        public DateTime PublishedYear { get; set; }
    }
}
