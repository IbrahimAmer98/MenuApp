using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MenuApp.Models
{
    public interface INamePrinter
    {
        string Name { get; set; }
        string NameCapital { get; set; }
        string NameSmall { get; set; }
        string ReverseName { get; set; }
        string Valid { get; set; }

        void Serve();
    }

    public class NamePrinter : INamePrinter
    {
        [Required(ErrorMessage = "Please enter your name!!")]
        public string Name { get; set; }
        public string ReverseName { get; set; }
        public string NameCapital { get; set; }
        public string NameSmall { get; set; }

        public string Valid { get; set; }
        public void Serve()
        {
            try
            {

                char[] arr = Name.ToCharArray();
                Array.Reverse(arr);
                ReverseName = new string(arr);
                NameCapital = Name.ToUpper();
                NameSmall = Name.ToLower();

                if (Regex.IsMatch(Name.Replace(" ", ""), @"^[a-zA-Z]+$"))
                    Valid = "Name is Valid";
                else
                    Valid = "Name is Not Valid";

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
