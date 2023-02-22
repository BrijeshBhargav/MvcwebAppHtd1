using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace MVCcoreWebAppHTD1.Models
{
    public class studentdatamodel
    {
        public int RefID { get; set; }
        [Required(ErrorMessage = "RollNO can't be empty")]
        public string Rollno { get; set; }
        [Required(ErrorMessage = "Name can't be empty")]
        [RegularExpression(@"^[a-z A-Z]+$", ErrorMessage = "Use letters only please")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email can't be empty")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}", ErrorMessage = "Invalid email")]
        public string EmailId {get; set;}
        [Required(ErrorMessage = " Password can't be empty")]

        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Password must contain at least six characters,a capital letter,a symbol,and a number")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Mobile can't be empty")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Gender can't be empty")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Date of Birth can't be empty")]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "FEE can't be empty")]

        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        [Range(10000, 100000000000)]
        public int Fee { get; set; }
        [Required(ErrorMessage = "Branch can't be empty")]
        public string Branch { get; set; }
        [Required(ErrorMessage = "status can't be empty")]

        public bool status { get; set; }
        public string role { get; set; }
      


    }
    public class Loginstudentdatamodel
    {
        [Required(ErrorMessage = "Email can't be empty")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}", ErrorMessage = "Invalid email")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Password can't be empty")]

        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Password must contain at least six characters,a capital letter,a symbol,and a number")]
        public string Password { get; set; }
    }
    public class checkdatamodel
    {
        public string name { get; set; }
        public string emailid { get; set; }


        public bool qualification { get; set; }
        public bool qualification1 { get; set; }
        public bool qualification2 { get; set; }
    }

    }
        public class resetpasswordmodel
    {
        [Required(ErrorMessage = "New Password Required")]
        [DataType (DataType.Password)]
        public string Newpassword { get; set; }
        [DataType(DataType.Password)]
        [Compare("Newpassword",ErrorMessage="New Password and Confirm password Doesn't match")]
        public string Confirmpassword { get; set; }
        public string EmailID { get; set; }
    }




