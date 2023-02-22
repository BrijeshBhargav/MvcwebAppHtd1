namespace MVCcoreWebAppHTD1.Models
{
    public class Contactmodel
    {
       
            public int ID { get; set; }
            
            public string ContactName { get; set; }
           
            public string ContactNo { get; set; }
    }

      public partial class ContactInfo
    {
        public int ID { get; set; }

        public string ContactName { get; set; }

        public string ContactNo { get; set; }
        public string Emailid { get; set; }
    }

    public partial class Contactdata
    {
        public string ContactName { get; set; }

        public string ContactNo { get; set; }
  
    }
}

