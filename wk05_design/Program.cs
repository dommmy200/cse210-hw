using System;
using MyWk05Design.Reference1;
using MyWk05Design.Scripture1;
using MyWk05Design.Word1;

namespace MyWk05Design
{
    class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Scripture Memorizer!");

        condition = true;
        while (condition)
        {
            Console.WriteLine("Please enter to continue or type 'quit' to finish: ");
                int selected = int.Parse(Console.ReadLine());
                if (selected == 'quit'){
                    // Quit the loop and exit the program
                    System.Environment.Exit(0);
                }
        }
    }
}
}