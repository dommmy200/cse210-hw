// using System;
// using System.Diagnostics.Contracts;
using MyMainProgram.Choice1;
using MyMainProgram.Journal01;

namespace MyMainProgram
{
    class Program
    {
        static void Main(string[] args)
        {
 
            Console.WriteLine("Welcome to the Journal Program");
            
            
            
            while (true)
            {
                // instantiate a Choice object and call the displayChoice method
                Choice ch = new();
                ch.displayChoices();

                Console.WriteLine("Please select one of the following choices: ");
                int selected = int.Parse(Console.ReadLine());
                if (selected == 1)
                {   
                    // Write entries to journal
                    JournalFiling.WriteJournal();
                    continue;

                } else if (selected == 2){
                    
                    // Display journal entries
                    JournalFiling.DisplayJournal();
                    continue;

                } else if (selected == 3){
                    
                    // Load data from file to list
                    JournalFiling.LoadFile();
                    continue;
                    
                } else if (selected == 4){
                    // Save data from list to 
                    JournalFiling.SaveJournal();
                    continue;

                } else if (selected == 5){
                    // Quit
                    System.Environment.Exit(0);

                }

            }
        }
    }
}
