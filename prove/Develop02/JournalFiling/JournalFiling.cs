
using MyMainProgram.Choice1;

namespace MyMainProgram.Journal01
{
    public class JournalFiling
    {
        // Display journal contents
        public static void DisplayJournal()
        {
            // string fileName = "journal.txt";
            // string[] lines = System.IO.File.ReadAllLines(fileName);
            foreach (string line in Choice.DataList)
            {
                Console.WriteLine($"{line}");
            }
        }
        // Add journal entries from list to text file
        public static void SaveJournal()
        {

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
            // Search and populate all .txt files in the program directory
            string[] files = Directory.GetFiles(@"/Users/Dommmy/cse210/cse210-hw/prove/Develop02/", "*.txt");
            
            // Get the user requested file
            string fullPath = pathPlusFilename();
            
            // Select the named file and empty content to the list for other processes
            foreach (string file in files)
            {
                // If user request file is found, copy content
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