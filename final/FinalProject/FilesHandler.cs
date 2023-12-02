using System;
using System.Globalization;
// This program aims to save automatically requiring user to only enter filename
// at the beginning
namespace FinancialPrudence {
    public static class FilesHandler {
        private static IncomeStatement _incomeStatement = new IncomeStatement(); 
        private static ExpensesStatement _expenseStatement = new ExpensesStatement();
        // private static bool quit = true;
        private static string _usersFile = @"Users.txt";
        private static string _filesPath = @"/users/Dommmy/cse210/cse210-hw/final/FinalProject/TextFiles/";// Is a folder
        // private string _autoSave;
        private static string _filenameInUse;
        private static Savings _savings = new Savings();
        public static string GetUsersFile() {
            return _filesPath + _usersFile;
        }
        public static string GetFilenameInUse() {
            return _filenameInUse;
        }
        public static void SetFilenameInUse(string filename) {
            _filenameInUse = filename;
        }
        public static string GetFilePath() {
            return _filesPath;
        }
        // public string GetAutoSave() {
        //     return _autoSave;
        // }
        // public void SetAutoSave(string filename) {
        //     _autoSave = filename;
        // }
        // public static void SaveStatementAndGoal(List<Statement> statements) {
        //     var userFile = GetUsersFile();
        //     using (StreamWriter outPut = new StreamWriter(userFile)) {
        //         foreach (Statement objects in statements) {
        //             var helperList = Helper.GetListOfObjects();
        //             helperList.Add(objects);
        //         }
        //     }
        // }
        // Called in OpenExistingFile() to supply stored filenames
        private static string[] GetFileNames () {
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
        public static void OpenExistingFile() {
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
            AutoSave();
            // After file is opened and stored globally, what next?
            // Return to file when ready to save from list
            // Note: GoTo FineTuneFPrudence()
        }
        // Called at the beginning of the program to create a new file
        public static void CreateNewFile() {
            Console.Write("Enter Filename: ");
            string filename = Console.ReadLine();
            var formattedFilename = FormatFileName(filename);
            var filenameFormat = formattedFilename.Contains(".txt") ? $"{formattedFilename}" : $"{GetFilePath()}{formattedFilename}" + ".txt";
            var filePath = GetFilePath();
            var fullPath = filePath + filenameFormat;
            SetFilenameInUse(fullPath);
            AutoSave();
            // After file is created and stored globally, what next?
            // Return to file when ready to save
        }
        // This method may not be necessary(replaced by Autosave)
        // Note: Necessary during saving of file
        // public static void SaveToFile() {
        //     var path = GetFilePath();
        //     // If this directory is not empty
        //     if (!Directory.EnumerateFileSystemEntries(path).Any()) {
        //         string[] files = Directory.GetFiles(path);
        //         int count = 1;
        //         foreach (string file in files) {
        //             Console.WriteLine($"{count}. {file}\n");
        //             count++;
        //         }
        //         int number = int.Parse(Console.ReadLine());
        //         string path1 = files[number];
        //         // Call the method and pass the filename to save as
        //         FileToStreamWrite(path1);
        //     } else {
        //         // Get user to input filename
        //         Console.Write("Enter filename: ");
        //         string filename = Console.ReadLine();
        //         string formattedFilename = FormatFileName(filename);
        //         var path1 = formattedFilename.Contains(".txt") ? $"{GetFilePath()}{formattedFilename}" : $"{GetFilePath()}{formattedFilename}" + ".txt";
        //         FileToStreamWrite(path1);
        //     }
        // }
        // StreamWriter handles file and saving templates
        // required in AutoSave()
        // public static void FileToStreamWrite(string file) {
        // using(StreamWriter outPut = new StreamWriter(file)) {
        //         var statementAndGoalList = Helper.GetListOfObjects();
        //         foreach (Statement statementGoal in statementAndGoalList) {
        //             var templates = statementGoal.SaveGoal();
        //             outPut.WriteLine(templates);
        //         }
        //     }
        // }
        // Note: May not be used eventually
        // public static void StringTemplateToFile(string template, string file) {
        // using(StreamWriter outPut = new StreamWriter(file)) {
        //         // var statementAndGoalList = Helper.GetListOfObjects();
        //         foreach (Statement statementGoal in template) {
        //             var templates = statementGoal.SaveGoal();
        //             outPut.WriteLine(templates);
        //         }
        //     }
        // }
        // Method to automatically save objects after user list compiling
        // My Note: Write a subroutine to check that duplicates objects 
        // are not created during auto save
        public static void AutoSave() { 
            var file = GetFilenameInUse();
            var motherList = ConcatenateLists();
            using(StreamWriter outPut = new StreamWriter(file)){
                var noDuplicate = RemoveDuplicates(motherList);
                foreach (Statement obj in noDuplicate) {
                    var template = obj.SaveGoal();
                    outPut.WriteLine(template);
                }
            }
        }
        // Method to remove duplicates from a list of Statement object
        public static List<Statement> RemoveDuplicates(List<Statement> withDuplicate) {
            var noDuplicate = withDuplicate.
            GroupBy(item => item.GetName()).
            Select(group => group.First()).
            ToList();
            return noDuplicate;
        }
        // Combine all lists into a mother list for filing
        public static List<Statement> ConcatenateLists() {
            var motherList = Helper.GetListOfObjects();
            var incList = _incomeStatement.GetObjectList();
            var expList = _expenseStatement.GetObjectList();
            var saveList = _savings.GetObjectList();
            motherList.AddRange(incList);
            motherList.AddRange(expList);
            motherList.AddRange(saveList);
            return motherList;
        }
        // Note: Necessary during loading of file to memory
        // Convert file string to object properties
        public static void TemplateToObject() {
            var file = GetFilenameInUse();
            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines) {
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
                    var oldDate = DateTime.ParseExact(parts[4], "yyyy-MM-dd", null); // Get more info on how to implement
                    DateTime today = TimeManagement.GetToday();
                    int elapseDays = (int) (oldDate -today).TotalDays; // Take note here to transfer to time Mgt class
                    Savings save = new Savings(itemName, description, amt);
                    var incomeList = save.GetObjectList();
                    incomeList.Add(save);
                }
            }
        } 
        // public static void OpenExistingFile() {
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
        private static string FormatFileName (string str) {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string titleCase = textInfo.ToTitleCase(str);
            return titleCase;
        }
    }
}