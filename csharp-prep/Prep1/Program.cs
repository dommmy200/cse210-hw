// This is Prep1 core assignment
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What's your Last name? ");
       
        string lastName = Console.ReadLine();

        Console.Write("What's your first name? ");
        string firstName = Console.ReadLine();

        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}