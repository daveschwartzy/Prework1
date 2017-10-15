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
                while (CheckInput(input1) == 0)
                {
                    Console.WriteLine("The value entered was not a positive integer. Please enter a positive integer.");
                    input1 = Console.ReadLine();
                    CheckInput(input1);
                }
                int number1 = CheckInput(input1);
                int length1 = number1.ToString().Count();

                // Prompt user to input second integer
                Console.WriteLine("Please enter another positive integer with the same number of digits ({0}) as the first:", length1);
                string input2 = Console.ReadLine();

                // Validate second entry to ensure integer was entered
                while (CheckInput(input2) == 0)
                {
                    Console.WriteLine("The value entered was not a positive integer. Please enter another positive integer value with the same number of digits ({0}) as the first:", length1);
                    input2 = Console.ReadLine();
                    CheckInput(input2);
                }
                int number2 = CheckInput(input2);
                int length2 = number2.ToString().Count();

                // Ensure integers have the same number of digits
                while (length2 != length1)
                {
                    Console.WriteLine("The integer entered did not contain the same number of digits as the first. Please enter another positive integer value with the same number of digits ({0}) as the first:", length1);
                    input2 = Console.ReadLine();
                    number2 = CheckInput(input2);
                    length2 = number2.ToString().Count();
                }

                // Seperate the individual digits of each integer into respective arrays
                int[] array1 = Seperate(number1);
                int[] array2 = Seperate(number2);

                // Do the computation, return true or false, and display result
                bool result = Computation(array1, array2);
                Console.WriteLine("Int 1 = " + number1 + "\r\nInt 2 = " + number2 + "\r\n" + result);
                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();

                // Run the program again
                Console.WriteLine("\r\nWould you like to run this program again? (Yes/No)");
                if (Console.ReadLine().ToLower() != "yes")
                break;
                
             }
        }
        // Method that separates digits into an array
        public static int[] Seperate(int number)
        {
            List<int> separateIntegers = new List<int>();
            while (number > 0)
            {
                separateIntegers.Add(number % 10);
                number = number / 10;
            }
            
            return separateIntegers.ToArray();
        }

        // Method checks user input to make sure it's a positive integer
        public static int CheckInput(string input)
        {
            int.TryParse(input, out int integer);
            if (integer < 0)
            {
                return 0;
            }
            else
            {
                return integer;
            }
        }

        // Method for adding each separate digit and checking if it returns true or false
        public static bool Computation(int[] arrayA, int[] arrayB)
        {
            int result = arrayA[0] + arrayB[0];

            for (int i = 1; i < arrayA.Length; i++)
            {
                if (arrayA[i] + arrayB[i] != result)
                {
                    return false;
                }
            }
                    return true;
        }
    }
}
        
    

