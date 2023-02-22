using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVCcoreWebAppHTD1.Models
{
    public class CalcModel
    {


        public decimal firstNumber { get; set; }
        public decimal secondNumber { get; set; }
        public string operations { get; set; }
        public decimal result { get; set; }
        public CalculationMethod calculationMethod { get; set; }

        public enum CalculationMethod
        {
            [Display(Name = "+")]
            Addition,
            [Display(Name = "-")]
            Subtraction,
            [Display(Name = "*")]
            Multiplication,
            [Display(Name = "/")]
            Division
        }
    }
    public class CalcModel2
    {
        public int Id { get; set; }
        public decimal number1 { get; set; }
        public decimal number2 { get; set; }
        public decimal result { get; set; }
        public string operations { get; set; }
    }
    public class calculator3
    {
        //public long number1 { get; set; }
        //public long number2 { get; set; }
        //public string operation { get; set; }
        public string result { get; set; }
    }
    public class CalculatorModel1
    {
        public long number1 { get; set; }
        public long number2 { get; set; }
        public string operation { get; set; }
        public string result { get; set; }
    }
}

