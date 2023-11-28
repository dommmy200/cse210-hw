using System;
using System.Globalization;

namespace FinancialPrudence {
    public class FilesHandler {
        private string _usersFile = @"/users/Dommmy/cse210/cse210-hw/final/FinalProject/TextFiles/Users.txt";
        private string _filesPath = @"/users/Dommmy/cse210/cse210-hw/final/FinalProject/TextFiles/";
        private Helper _helper1 = new();
        // private IncomeStatement _child1 = new();
        // private ExpensesStatement _child2 = new();
        // private Savings _child3 = new();
        public string GetUserFile() {
            return _usersFile;
        }
        public string GetFilePath() {
            return _filesPath;
        }
        public void SaveStatementAndGoal(List<Statement> statements) {
            var userFile = GetUserFile();
            using (StreamWriter outPut = new StreamWriter(userFile)) {
                foreach (Statement objects in statements) {
                    var helperList = _helper1.GetList();
                    helperList.Add(objects);
                }
            }
        }
        private string[] GetFileNames () {
            string[] xyz = null;
            var userFile = GetUserFile();
            if (userFile != null) {
                string[] lines = File.ReadAllLines(userFile);
                    return lines;
            } else {
                Console.WriteLine("\nThis file is empty.\n");
                return xyz;
            }
        }
        public void DisplayFileNames () {
            string[] lines = GetFileNames();
            int count = 1;
            foreach (string line in lines) {
                string[] parts = line.Split(",");
                string filename = parts[0].Trim();
                Console.WriteLine($"{count}. {filename}");
                count++;
            }
        }
        public void SaveToFile() {
            var path = GetFilePath();
            if (!Directory.EnumerateFileSystemEntries(path).Any()) {
                string[] files = Directory.GetFiles(path);
                int count = 1;
                foreach (string xyz in files) {
                    Console.WriteLine($"{count}. {xyz}\n");
                    count++;
                }
                int number = int.Parse(Console.ReadLine());
                string path1 = files[number];
                // Call the method and pass the filename to save as
                FileToStreamWrite(path1);
            } else {
                // Get user to input filename
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();
                string formattedFilename = FormatFileName(filename);
                var path1 = formattedFilename.Contains(".txt") ? $"{GetFilePath()}{formattedFilename}" : $"{GetFilePath()}{formattedFilename}" + ".txt";
                FileToStreamWrite(path1);
            }
        }
        // StreamWriter handles file and saving templates
        public void FileToStreamWrite(string file) {
        using(StreamWriter outPut = new StreamWriter(file)) {
                var statementAndGoalList = _helper1.GetList();
                foreach (Statement statementGoal in statementAndGoalList) {
                    var templates = statementGoal.SaveGoal();
                    outPut.WriteLine(templates);
                }
            }
        }
        // Format filename to TitleCase to accept mix cases of characters
        private string FormatFileName (string str) {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string titleCase = textInfo.ToTitleCase(str);
            return titleCase;
        }
    }
}