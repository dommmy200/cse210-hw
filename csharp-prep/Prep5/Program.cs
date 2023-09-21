using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string result = PromptUserName();   
        int resultNumber = PromptUserNumber();
        int squared = SquareNumber(resultNumber);
        
        DisplayResult(result, squared);


        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program. ");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }
        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            string number = Console.ReadLine();
            int numberReal = int.Parse(number);
            return numberReal;
        }
        static int SquareNumber(int numb)
        {
            int squaredNumber = numb*numb;
            return squaredNumber;
        }
        static void DisplayResult(string first, int second)
        {
            Console.WriteLine($"{first}, the square of your favorite number is {second}");
        }
    }
}