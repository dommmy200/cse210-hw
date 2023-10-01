using System;
using System.Diagnostics.Contracts;
using MyMainProgram.Choice1;
using MyMainProgram.Journal01;

namespace MyMainProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> choice = new()
            {
                "Write",
                "Display",
                "Load",
                "Save",
                "Quit"
            };
            Console.WriteLine("Welcome to the Journal Program");
            
            Choice dt = new Choice();
            List<string> dpr = new List<string>();
            string myDt = dt.DateString();
            
            // Display the 5 choices
            int count = 0;
            foreach (string ch in choice)
            {
                count++;
                Console.WriteLine($"{count}. {ch}");
            }
            
            while (true)
            {
                Console.WriteLine("Please select one of the following choices: ");
                int selected = int.Parse(Console.ReadLine());
                if (selected == 1)
                {
                    // Write
                    Choice prompt = new Choice();
                    string promptString = prompt.PromptGenerator();
                    Console.WriteLine($"Prompt: {promptString}");
                    string response = Console.ReadLine();
                    
                    dpr.Add(myDt);
                    dpr.Add(promptString);
                    dpr.Add(response);
                    Choice.Journal(dpr);
                    continue;
                } else if (selected == 2){
                    // Display
                    JournalFiling.DisplayJournal();
                    continue;
                } else if (selected == 3){
                    // Load
                    JournalFiling.LoadFile();
                    continue;
                } else if (selected == 4){
                    // Save
                    JournalFiling.SaveJournal();
                    continue;
                } else if (selected == 5){
                    // Quit
                    System.Environment.Exit(0);
                } else {
                    // Error
                }

            }
        }
    }
}
