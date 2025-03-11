using System;
using System.Reflection.Emit;
using System.Text.RegularExpressions;


namespace HelloWorld  
{  
    class Program  
    {  
        static void Main(string[] args)  
        {  
            label:
            // Prompt the user for input  
            Console.WriteLine("Please enter a Roman numeral:");  

            // Read the input from the user  
            string userInput = Console.ReadLine();  

            if (!IsValidRomanNumeral(userInput))  
            {  
                Console.WriteLine($"{userInput} is a NOT a valid Roman numeral."); 
                return; 
            }  

            Dictionary<string, int> romanNumbers = new Dictionary<string, int>  
            {  
                { "M", 1000 },  
                { "D", 500 },  
                { "C", 100 },  
                { "L", 50 },  
                { "X", 10 },  
                { "V", 5 },  
                { "I", 1 } 
            };  

            int value = 0;
            int prevValue = 0;
            int crtValue = 0;

            for (int i = 0;i<userInput.Length;i++)
            {
                crtValue = romanNumbers[userInput.ElementAt(i).ToString()];
                value += crtValue;
                
                if (prevValue < crtValue)
                {
                    value -= 2*prevValue;
                }

                prevValue = crtValue;
            }


            // Display the input back to the user  
            Console.WriteLine("You entered: " + userInput + " = " + value);     

            goto label;     
        }  

        static bool IsValidRomanNumeral(string input)  
        {  
            // Regular expression for validating Roman numerals  
            string pattern = @"^(M{0,3})(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";  

            return Regex.IsMatch(input.ToUpper(), pattern);  
        }  
    }  
}  



