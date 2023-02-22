using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCcoreWebAppHTD1.Models
{
   
    public class Customer
    {
        public string Name { get; set; }
        public int OrderId { get; set; }
        public decimal Price { get; set; }
    }
   


}
