using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // Inform user of what program accomplishes and prompts user to input integer
                Console.WriteLine("Hello! This program will tell you if each corresponding place in two numbers (ones, tens, hundreds, etc.) sums to the same total.");
                Console.WriteLine("Please enter a positive integer.");
                string input1 = Console.ReadLine();

                // Validate entry to ensure an integer was entered
                while (ValidateEntry(input1) == 0)
                {
                    Console.WriteLine("The value entered was not a positive integer. Please enter a positive integer.");
                    input1 = Console.ReadLine();
                    ValidateEntry(input1);
                }
                int number1 = ValidateEntry(input1);
                int length1 = number1.ToString().Count();

                // Prompt user to input second integer
                Console.WriteLine("Please enter another positive integer with the same number of digits ({0}) as the first:", length1);
                string input2 = Console.ReadLine();

                // Validate second entry to ensure integer was entered
                while (ValidateEntry(input2) == 0)
                {
                    Console.WriteLine("The value entered was not a positive integer. Please enter another positive integer value with the same number of digits ({0}) as the first:", length1);
                    input2 = Console.ReadLine();
                    ValidateEntry(input2);
                }
                int number2 = ValidateEntry(input2);
                int length2 = number2.ToString().Count();

                // Ensure integers have the same number of digits
                while (length2 != length1)
                {
                    Console.WriteLine("The integer entered did not contain the same number of digits as the first. Please enter another positive integer value with the same number of digits ({0}) as the first:", length1);
                    input2 = Console.ReadLine();
                    number2 = ValidateEntry(input2);
                    length2 = number2.ToString().Count();
                }

                // Seperate the individual digits of each integer into respective arrays
                int[] array1 = SeperateDigits(number1);
                int[] array2 = SeperateDigits(number2);

                // Do the computation, return true or false, and display result
                bool result = Compute(array1, array2);
                Console.WriteLine("Int 1 = " + number1 + "\r\nInt 2 = " + number2 + "\r\n" + result);
                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();

                // Run the program again
                Console.WriteLine("\r\nWould you like to run this program again? (Yes/No)");
                if (Console.ReadLine().ToLower() != "yes")
                break;
             }
        }

        // Method to parse user input, ensure integer is positive
        static int ValidateEntry(string input)
        {
            int.TryParse(input, out int number);
            if (number < 0)
            {
                return 0;
            }
            else
            {
                return number;
            }
        }

        // Method to convert each integer into array
        static int[] SeperateDigits(int number)
        {
            int[] digits = number.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            return digits;
        }

        // Method for the computation
        static bool Compute(int[] array1, int[] array2)
        {
            int answer = array1[0] + array2[0];

            for (int i = 1; i < array1.Length; i++)
            {
                if (array1[i] + array2[i] != answer)
                {
                    return false;
                }
            }

                   return true;
        }
    }
}
        
    

