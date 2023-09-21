using System;

class Program
{
    static void Main(string[] args)
    {
        // Use this when the user is required to supply the magic number.
        // ..........
        // Console.Write("What is the magic number? ");
        // string magicNumber = Console.ReadLine();
        // int mNumber = int.Parse(magicNumber);

        // Use this when the magic number is to be generated randomly.
        // ..........
        Random random = new();
        int  mNumber = random.Next(1, 11);

        // Declare and initialize the variable gNumber for the while-loop not 
        // to throw errors.
        int gNumber = -1;

        while (gNumber != mNumber)
        {
            Console.WriteLine("Choose integer between 1 and 10");        
            Console.Write("What is your guess? ");
            string guessedNumber = Console.ReadLine();
            gNumber = int.Parse(guessedNumber);
            
            if (gNumber < mNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (gNumber > mNumber)
            {
                Console.WriteLine("Lower");
            }
            else {
                Console.WriteLine("You guessed right!");
            }
        }

        
    }
}