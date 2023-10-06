using System.IO;
using System.Collections.Generic;
using MyMainProgram.Choice1;
using System.Transactions;
using System.Collections;

namespace MyMainProgram.Journal01
{
    public class JournalFiling
    {
        // Display journal contents
        public static void DisplayJournal()
        {
            string fileName = "journal.txt";
            string[] lines = System.IO.File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                // string[] parts = line.Split(",");
                // string date = parts[0];
                // string prompt = parts[1];
                // string response = parts[2];
                // Console.WriteLine($"{date}\n{prompt}\n{response}\n");

                Console.WriteLine($"{line}");
            }
        }
        // Add journal entries from list to text file
        public static void SaveJournal()
        {
            // // Specify the path for the file
            // string strPath = "/Users/Dommmy/cse210/cse210-hw/prove/Develop02";

            // // Get file name from user
            // Console.WriteLine("Enter the file name");
            // string journalName = Console.ReadLine();

            // // Concatenate path and file name
            // string fullPath = $"{strPath}/{journalName}";

            string fullPath = pathPlusFilename();

            // Copy entries from list to file in memory
            using (StreamWriter outputFile = new(fullPath))
            {
                foreach (string items in Choice.DataList)
                {
                    outputFile.WriteLine(items);
                }
            }
        }
        
        // Load journal from file in memory to list
        public static void LoadFile()
        {
            // string path = "/Users/Dommmy/cse210/cse210-hw/prove/Develop02/";
            // string[] load = Directory.GetFiles(path);


            // Console.WriteLine("Enter File Name: ");
            // string loadJournal = Console.ReadLine(); // No longer needed

            string[] files = Directory.GetFiles(@"/Users/Dommmy/cse210/cse210-hw/prove/Develop02/", "*.txt");
            string fullPath = pathPlusFilename();
            foreach (string file in files)
            {
                if (file == fullPath)
                {
                    string[] newLines = File.ReadAllLines(fullPath);
                    foreach (string line in newLines)
                    {
                        Choice.DataList.Add(line);
                    }
                } else {
                    Console.WriteLine("No such file exit.\nWrite a new journal.");
                }
            }


            // List<Choice> entries = new();
            // string[] lines = File.ReadAllLines(loadJournal);

            // foreach (string line in lines)
            // {
            //     string[] parts = line.Split(",");
            //     Choice choice = new();
            //     choice.JournalDate = DateTime.Parse(parts[0]);
            //     choice.Prompt = parts[1];
            //     choice.Response = parts[2];

            //     entries.Add(choice);
            // }

            // return entries;

        }

        // Function to handle user entries to the journal
        public static void WriteJournal()
        {
            // Create an instance of Choice to format date object to string
            Choice dt = new();
            string myDate = dt.DateToString();

            // Create an instance of Choice to generate the prompts defined in the Choice class
            Choice prompt = new();
            string promptString = prompt.PromptGenerator();
            
            // Get user response to the generated prompt
            Console.WriteLine($"Prompt: {promptString}");
            string response = Console.ReadLine();

            // Add data to the list
            AddData(myDate);
            AddData(promptString);
            AddData(response);
        }

        // Private function used to add data to the list defined in Choice Class
        private static void AddData(string dataToAdd)
        {
           Choice.DataList.Add(dataToAdd);
        }
        public static string pathPlusFilename()
        {
            // Specify the path for the file
            string strPath = "/Users/Dommmy/cse210/cse210-hw/prove/Develop02";

            // Get file name from user
            Console.WriteLine("Enter the file name");
            string journalName = Console.ReadLine();

            // Concatenate path and file name
            string fullPath = $"{strPath}/{journalName}";

            return fullPath;
        }
    }
}