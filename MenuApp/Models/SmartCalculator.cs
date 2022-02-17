using System;
using System.ComponentModel.DataAnnotations;

namespace MenuApp.Models
{
    public interface ISmartCalculator
    {
        double A { get; set; }
        string AInBinary { get; set; }
        double B { get; set; }
        string BInBinary { get; set; }

        void Serve();
    }

    public class SmartCalculator : ISmartCalculator
    {

        public double A { get; set; }

        [Required(ErrorMessage = "Please enter number for B!!")]
        [RegularExpression("(.*[1-9].*)|(.*[.].*[1-9].*)", ErrorMessage = "Not Equal to Zero")]
        public double B { get; set; }
        public string AInBinary { get; set; }
        public string BInBinary { get; set; }
        public void Serve()
        {
            try
            {

                A = Math.Truncate(10000 * A) / 10000;

                B = Math.Truncate(10000 * B) / 10000;


                AInBinary = decimalToBinary(A, 5);
                BInBinary = decimalToBinary(B, 5);

            }
            catch (DivideByZeroException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private String decimalToBinary(double num, int k_prec)
        {
            String binary = "";

            // Fetch the integral part of decimal number
            int Integral = (int)num;

            // Fetch the fractional part decimal number
            double fractional = num - Integral;

            // Conversion of integral part to
            // binary equivalent
            while (Integral > 0)
            {
                int rem = Integral % 2;

                // Append 0 in binary
                binary += ((char)(rem + '0'));

                Integral /= 2;
            }

            // Reverse string to get original binary
            // equivalent
            binary = reverse(binary);

            // Append point before conversion of
            // fractional part
            binary += ('.');

            // Conversion of fractional part to
            // binary equivalent
            while (k_prec-- > 0)
            {
                // Find next bit in fraction
                fractional *= 2;
                int fract_bit = (int)fractional;

                if (fract_bit == 1)
                {
                    fractional -= fract_bit;
                    binary += (char)(1 + '0');
                }
                else
                {
                    binary += (char)(0 + '0');
                }
            }

            return binary;
        }

        private String reverse(String input)
        {
            char[] temparray = input.ToCharArray();
            int left, right = 0;
            right = temparray.Length - 1;

            for (left = 0; left < right; left++, right--)
            {
                // Swap values of left and right
                char temp = temparray[left];
                temparray[left] = temparray[right];
                temparray[right] = temp;
            }
            return String.Join("", temparray);
        }
    }
}
