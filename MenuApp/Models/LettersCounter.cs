using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace MenuApp.Models
{
    public interface ILettersCounter
    {
        string InvalidChar { get; set; }
        string Text { get; set; }

        void Serve();
    }

    public class LettersCounter : ILettersCounter
    {
        [Required(ErrorMessage = "Please enter a Text!!")]
        public string Text { get; set; }

        public string InvalidChar { get; set; }

        public void Serve()

        {
            try
            {



                Text = Text.Replace(" ", "");


                if (!Regex.IsMatch(Text, @"^[a-zA-Z]+$"))
                {
                    InvalidChar = new string(Text.Where(c => !Char.IsLetter(c)).ToArray());

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
