using System;
using System.Globalization;

namespace FinancialPrudence {
    public class FilesHandler {
        private string _usersFile = @"Users.txt";
        private string _filesPath = @"/users/Dommmy/cse210/cse210-hw/final/FinalProject/TextFiles/";// Is a folder
        private string _autoSave;
        private string _filenameInUse;
        private Helper _helper1 = new();
        // private IncomeStatement _child1 = new();
        // private ExpensesStatement _child2 = new();
        // private Savings _child3 = new();
        public string GetUsersFile() {
            return _filesPath + _usersFile;
        }
        public string GetFilenameInUse() {
            return _filenameInUse;
        }
        public void SetFilenameInUse(string filename) {
            _filenameInUse = filename;
        }
        public string GetFilePath() {
            return _filesPath;
        }
        public string GetAutoSave() {
            return _autoSave;
        }
        public void SetAutoSave(string filename) {
            _autoSave = filename;
        }
        public void SaveStatementAndGoal(List<Statement> statements) {
            var userFile = GetUsersFile();
            using (StreamWriter outPut = new StreamWriter(userFile)) {
                foreach (Statement objects in statements) {
                    var helperList = _helper1.GetList();
                    helperList.Add(objects);
                }
            }
        }
        // Called in OpenExistingFile() to supply stored filenames
        private string[] GetFileNames () {
            string[] xyz = null;
            var userFile = GetUsersFile();
            if (userFile != null) {
                string[] lines = File.ReadAllLines(userFile);
                    return lines;
            } else {
                Console.WriteLine("\nThis file is empty.\n");
                return xyz;
            }
        }
        // Called at the beginning of the program to open a file
        public void OpenExistingFile() {
            var lines = GetFileNames();
            for (int i = 0; i < lines.Length; i++) {
                string line = lines[i];
                string filename = Path.GetFileNameWithoutExtension(line);
                Console.WriteLine($"{i + 1}. {filename}");
            }
            Console.WriteLine();
            int selected = int.Parse(Console.ReadLine());
            var selectedFile = lines[selected - 1];
            SetFilenameInUse(selectedFile);
            // After file is opened and stored globally, what next?
            // Return to file when ready to save from list
            // Note: GoTo FineTuneFPrudence()
        }
        // Called at the beginning of the program to create a new file
        public void CreateNewFile() {
            Console.Write("Enter Filename: ");
            string filename = Console.ReadLine();
            var formattedFilename = FormatFileName(filename);
            var filenameFormat = formattedFilename.Contains(".txt") ? $"{GetFilePath()}{formattedFilename}" : $"{GetFilePath()}{formattedFilename}" + ".txt";
            var filePath = GetFilePath();
            var fullPath = filePath + filenameFormat; 
            SetFilenameInUse(fullPath);
            // After file is created and stored globally, what next?
            // Return to file when ready to save
        }
        public void SaveToFile() {
            var path = GetFilePath();
            // If this directory is not empty
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
        // Note: May not be used eventually
        public void StringTemplateToFile(string template, string file) {
        using(StreamWriter outPut = new StreamWriter(file)) {
                var statementAndGoalList = _helper1.GetList();
                foreach (Statement statementGoal in statementAndGoalList) {
                    var templates = statementGoal.SaveGoal();
                    outPut.WriteLine(templates);
                }
            }
        }
        // Method to automatically save objects after user list compiling
        // My Note: If there are too make auto save in the program, prevent duplicate
        // objects from being filed
        public void AutoSave(Statement objects) {
            var file = GetFilenameInUse();
            var objectList = objects.GetObjectList();
            foreach (Statement obj in objectList) {
                var template = obj.SaveGoal();
                StringTemplateToFile(template, file);
            }
        }
        // Convert file string to object properties
        public void TemplateToObject() {
            var file = GetFilenameInUse();
            string[] lines = File.ReadAllLines(file);
            foreach ( string line in lines) {
                var parts = line.Split(",");
                var objectName = parts[0];
                if (objectName.Contains("income")) {
                    var itemName = parts[1];
                    var description = parts[2];
                    var amount = parts[3];
                    float amt = float.Parse(amount);
                    IncomeStatement income = new IncomeStatement(itemName, description, amt);
                    var incomeList = income.GetObjectList();
                    incomeList.Add(income);
                } else if (objectName.Contains("expenses")) {
                    var itemName = parts[1];
                    var description = parts[2];
                    var amount = parts[3];
                    float amt = float.Parse(amount);
                    ExpensesStatement expenses = new ExpensesStatement(itemName, description, amt);
                    var incomeList = expenses.GetObjectList();
                    incomeList.Add(expenses);
                } else {
                    var itemName = parts[1];
                    var description = parts[2];
                    var amount = parts[3];
                    float amt = float.Parse(amount);
                    var timeSpan = parts[4]; // Get more info on how to implement
                    Savings save = new Savings(itemName, description, amt);
                    var incomeList = save.GetObjectList();
                    incomeList.Add(save);
                }
            }
        } 
        // public void OpenExistingFile() {
        //     // string[] xyz = null;
        //     var userFile = GetUsersFile();
        //     if (userFile != null) {
        //         string[] lines = File.ReadAllLines(userFile);
        //     } else {
        //         Console.WriteLine("\nThis file is empty.\n");
        //         Console.Write("Enter Filename: ");
        //         string filename = Console.ReadLine();
        //         var formattedFilename = FormatFileName(filename);
        //         var filenameFormat = formattedFilename.Contains(".txt") ? $"{GetFilePath()}{formattedFilename}" : $"{GetFilePath()}{formattedFilename}" + ".txt";
        //         var filePath = GetFilePath();
        //         var fullPath = filePath + filenameFormat;
        //         SetFilenameInUse(fullPath);
        //     }
        // }
        // Format filename to TitleCase to accept mix cases of characters
        private string FormatFileName (string str) {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string titleCase = textInfo.ToTitleCase(str);
            return titleCase;
        }
    }
}