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
            string fileName = "Journal.txt";
            string[] lines = System.IO.File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                string[] parts = line.Split(",");
                string date = parts[0];
                string prompt = parts[1];
                string response = parts[3];
                Console.WriteLine($"{date}\n{prompt}\n{response}\n");
            }
        }
        // Save journal to text file
        public static void SaveJournal()
        {
            string fileName = "journal.txt";
            string[]line1 = System.IO.File.ReadAllLines(fileName);
            
            Console.WriteLine("Enter the file name");
            IEnumerable newFilename = Console.ReadLine();
            File.WriteAllLines($"/Users/Dommmy/cse210/cse210-hw/prove/Develop02/{newFilename}", (IEnumerable<string>)newFilename);
        }
        // Load journal from saved file
        public static void LoadFile()
        {
            string path = "/Users/Dommmy/cse210/cse210-hw/prove/Develop02/";
            string[] load = Directory.GetFiles(path);


            List<string> fn = new();
            foreach (string p in load)
            {
                fn.Add(Path.GetFileName(p));
            }
            foreach (string file in fn)
            {
                if (file == "journal.txt")
                {
                    Console.WriteLine(file);
                    JournalFiling.DisplayJournal();
                }
            }


            // Console.WriteLine(String.Join(Environment.NewLine, load));
        }
    }
}