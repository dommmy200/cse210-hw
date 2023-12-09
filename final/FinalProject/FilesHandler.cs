using System;
using System.Globalization;
// This program aims to save automatically requiring user to only enter filename
// at the beginning
namespace FinancialPrudence {
    public class FilesHandler {
        private Helper _helper = new Helper();
        private IncomeStatement _incomeStatement = new IncomeStatement(); 
        private ExpensesStatement _expenseStatement = new ExpensesStatement();
        // private static bool quit = true;
        // private static string _usersFile = @"Users.txt";
        private string _filesPath = @"/Users/Dommmy/cse210/cse210-hw/final/FinalProject/TextFiles";// Is a folder
        private static string _fileInUse;
        private Savings _savings = new Savings();
        public static string GetFileInUse() {
            return _fileInUse;
        }
        public void SetFileInUse(string fullPath) {
            _fileInUse = fullPath;
        }
        public string GetFilePath() {
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
        // private static string[] GetFileNames () {
        //     string[] xyz = null;
        //     var userFile = GetUsersFile();
        //     if (userFile != null) {
        //         string[] lines = File.ReadAllLines(userFile);
        //             return lines;
        //     } else {
        //         Console.WriteLine("\nThis file is empty.\n");
        //         return xyz;
        //     }
        // }
        // Called at the beginning of the program to open a file
        // public static void OpenExistingFile() {
        //     var lines = GetFileNames();
        //     for (int i = 0; i < lines.Length; i++) {
        //         string line = lines[i];
        //         string filename = Path.GetFileNameWithoutExtension(line);
        //         Console.WriteLine($"{i + 1}. {filename}");
        //     }
        //     Console.WriteLine();
        //     int selected = int.Parse(Console.ReadLine());
        //     var selectedFile = lines[selected - 1];
        //     SetFilenameInUse(selectedFile);
        //     AutoSave();
        //     // After file is opened and stored globally, what next?
        //     // Return to file when ready to save from list
        //     // Note: GoTo FineTuneFPrudence()
        // }
        // Called at the beginning of the program to create a new file
        public void CreateNewFile() {
            Console.Write("Enter Filename: ");
            string filename = Console.ReadLine();
            var formattedFilename = FormatFileName(filename);
            var filenameFormat = formattedFilename.Contains(".Txt") ? $"{formattedFilename}" : $"{formattedFilename}" + ".txt";
            var filePath = GetFilePath();
            var fullPath = Path.Combine(filePath, filenameFormat); // filePath + filenameFormat;
            SetFileInUse(fullPath);
            using (FileStream fs = File.Create(fullPath))
            Console.WriteLine();
            Information.SuccessfullyCreated();
            // Information.PressToContinueInfo();
            Helper.PressToContinue();
            // _helper.GetTwoStatements();
            // Helper.ToSavingsOrDebtManagement();
            // var template = UserFileTemplate(filenameFormat);
            // SaveUserFile(fullPath, template);
            // AutoSave();
            // After file is created and stored globally, what next?
            // Return to file when ready to save
        }
        // This method may not be necessary(replaced by Autosave)
        // Note: Necessary during saving of file
        public void OpenAFileForUse() {
            var path = GetFilePath();
            // If this directory is not empty
            string[] files = Directory.GetFiles(path);

            if (files.Length > 0)
            //if (!Directory.EnumerateFileSystemEntries(path).Any()) 
                {
                // string[] files = Directory.GetFiles(path);
                int count = 1;
                foreach (string file in files) {
                    // Note: Split the file and get the filename for display
                    string fileName = Path.GetFileName(file);
                    Console.WriteLine($"{count}. {fileName}\n");
                    count++;
                }
                int number = int.Parse(Console.ReadLine());
                string path1 = files[number-1];
                // Call the method and pass the filename to save as
                SetFileInUse(path1);
                Console.Clear();
                Information.SuccessfullyOpened();
                // Now that SetFilenameInUse is opened. I think user should do something
                // like given the option to set goals or quit


            //     TemplateToObject();
            //     _helper.FineTuneFinancialPrudence();
            } else {
                Information.NoFileOpened();
                Helper.PressToContinue();
                // CreateNewFile();
            }
        }
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
        public static void SaveUserFile(string file, string template) {
            using(StreamWriter outPut = new StreamWriter(file)) {
                outPut.WriteLine(template);
            }
        }
        public static string UserFileTemplate(string filename) {
            var template = $"{filename}";
            return template;
        }
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
        // Method to automatically save objects before quitting
        public void AutoSave() { 
            var file = GetFileInUse();
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
        //Combine all lists into a mother list for filing
        public List<Statement> ConcatenateLists() {
            var motherList = Helper.GetAllObjectsList();
            var incList = _helper.GetIncomeList();
            var expList = _helper.GetExpensesList();
            var saveList = _helper.GetSavingsList();
            motherList.AddRange(incList);
            motherList.AddRange(expList);
            motherList.AddRange(saveList);
            return motherList;
        }

        // Note: Necessary during loading of file to memory
        // Convert file string to object properties
        public void TemplateToObject() {
            var file = GetFileInUse();
            FileInfo fileInfo = new FileInfo(file);
            // Check if the file exists and is not empty
            if (fileInfo.Exists && fileInfo.Length > 0) { 
                string[] lines = File.ReadAllLines(file);
                foreach (string line in lines) {
                    var parts = line.Split(",");
                    var objectName = parts[0];
                    if (objectName.Contains("IncomeStatement")) {
                        var itemName = parts[1];
                        var description = parts[2];
                        var amount = parts[3];
                        float amt = float.Parse(amount);
                        IncomeStatement income = new IncomeStatement(itemName, description, amt);
                        var incomeList = _helper.GetIncomeList();
                        incomeList.Add(income);
                    } else if (objectName.Contains("ExpensesStatement")) {
                        var itemName = parts[1];
                        var description = parts[2];
                        var amount = parts[3];
                        float amt = float.Parse(amount);
                        ExpensesStatement expenses = new ExpensesStatement(itemName, description, amt);
                        var incomeList = _helper.GetExpensesList();
                        incomeList.Add(expenses);
                    } else {
                        var itemName = parts[1];
                        var description = parts[2];
                        var amount = parts[3];
                        float amt = float.Parse(amount);
                        // var oldDate = DateTime.ParseExact(parts[4], "yyyy-MM-dd", null); // Get more info on how to implement
                        string oldDateString = parts[4];
                        Savings.SetOldDate(oldDateString);
                        // var oldDate = Savings.GetOldDate();
                        // DateTime today = TimeManagement.GetToday();
                        // int elapseDays = (int) (oldDate -today).TotalDays; // Take note here to transfer to time Mgt class

                        Savings save = new Savings(itemName, description, amt);
                        var incomeList = _helper.GetSavingsList();
                        incomeList.Add(save);
                    }
                }
            } else {
                Console.Clear();
                Console.WriteLine("This file is empty!");
            }
        }
        //     // Possibly calling the ConcatenateLists() method here
        // } 
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
        private string FormatFileName (string str) {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string titleCase = textInfo.ToTitleCase(str);
            return titleCase;
        }
        // May be discarded
        private string FormatFileNameLower (string str) {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string titleCase = textInfo.ToLower(str);
            return titleCase;
        }
        public static void GetInExStatements(Helper help) {
            bool quit = true;
            while (quit) {
                var selected = Information.SelectStatementInfo();
                try {
                    // These goal types are differentiated by x=1 & 2
                    if (selected == 1) {
                        IncomeStatement goal1 = new IncomeStatement();
                        goal1.GetStatement();
                        help.AddToIncomeList(goal1);
                    } else if (selected == 2){
                        ExpensesStatement goal2 = new ExpensesStatement();
                        goal2.GetStatement();
                        help.AddToExpensesList(goal2);
                    } else if (selected == 3){
                        quit = false;
                    }
                } catch (FormatException ex) {
                    // Handle or log the error for integer input in a more detailed manner if needed.
                    Console.WriteLine($"Error: {ex.Message} \nEnter an integer!");
                }
            }
        }
        // This is valid method(|)
        // Call this method when saved goals needs fine tuning ie
        // adjusting the goals' amount
        public void FineTuneFinancialPrudence() {
            bool quit = true;
            while (quit) {
                List<Statement> incList = _helper.GetIncomeList();
                List<Statement> expList = _helper.GetExpensesList();
                // Treats the case where income and expenses lists are empty
                if (incList.Count != 0 && expList.Count != 0) {
                    var difference =  _helper.GetSurplusOrDeficit();
                    // If true, manage the deficit by making more income
                    // or reducing expenses
                    if (difference <  0){
                        _helper.GetTwoStatements();
                    } else {
                        var list = _helper.GetSavingsList(); //Else, set goal from surplus
                        if (list.Count != 0) {
                            // Adjust the goals
                            _helper.UpdateStatementAndGoal(list);
                        } else {
                            Console.Clear();
                            Information.SavingsStatementInfo();
                            _savings.GetStatement();
                            var iList = _helper.GetSavingsList();
                            iList.Add(_savings);
                        }
                    }
                } else if (incList.Count == 0) {
                    // Treats the case where income list is empty
                    Console.Clear();
                    Information.NoIncStatementMade();
                    _incomeStatement.GetStatement();
                    var iList = _helper.GetIncomeList();
                    iList.Add(_incomeStatement);
                } else {
                    // Treats the case where expenses list is empty
                    Console.Clear();
                    Information.NoExpStatementMade();
                    _expenseStatement.GetStatement();
                    var iList = _helper.GetExpensesList();
                    iList.Add(_expenseStatement);
                }
                quit = Helper.QuitOrContinue();
            }
        
        }
    }
}