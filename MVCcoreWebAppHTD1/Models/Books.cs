using System.ComponentModel.DataAnnotations;

namespace MVCcoreWebAppHTD1.Models
{
    public class Books
    {
        public int ID { get; set; }
        public string TITLE { get; set; }
        public string AUTHOR { get; set; }
        public string DESCRIPTION { get; set; }
        //[DisplayFormat(DataFormatString ="{0:DD-MMM-YY}")]
        public DateTime PUBLISHED_YEAR { get; set; }
    }
}
