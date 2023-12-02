using System;

namespace FinancialPrudence {
    public class Savings : Statement {
        // private Helper _helper1 = new();
        // private TimeManagement _time = new();
        private int _points;
        private int _totalPoints;

        public Savings(string name = "name", string description = "description", float amount = 0) : base (name, description, amount) {
        }

//         private Dictionary<string, string> _dict = new Dictionary<string, string>(6){
//             {"EmergencyFund", "Savings for emergency situation must be easily accessible"},
//             {"Cash", "Savings as cash in bank"},
//             {"Retirement", "Savings to guarantee a comfortable retirement"},
//             {"Vacation", "Short-term savings for family vacation"},
//             {"Mortgage", "Long-term savings for home and other projects"},
//             {"Insurance", "Savings for all forms of insurances:life, health, mishaps, etc"}
//         };
//         public Dictionary<string, string> GetDictionary() {
//             return _dict;
//         }
        public int GetPoints() {
            return _points;
        }
        public void SetPoints(int points) {
            _points = points;
        }
//         public int GetTotalPoints() {
//             return _totalPoints;
//         }
//         public void SetTotalPoints(int totalPoints) {
//             _totalPoints = totalPoints;
//         }
        public static int ComputePoints(float amount) {
            float surplus = Helper.GetSurplusOrDeficit();
            var y = surplus/6;
            var z = amount/y * 10;
            return (int) Math.Floor(z);
        }
//         // Using to notify user of options to select
//         public void DisplayDictionary() {
//             var dict = GetDictionary();
//             int count = 1;
//             foreach (KeyValuePair<string, string> kVP in dict) {
//                 Console.WriteLine($"{count}. {kVP.Key}: {kVP.Value}");
//                 count++;
//             }
//         }
//         public KeyValuePair<string, string> GetKeyValuePair(int index) {
//             var dict = GetDictionary();
//             return dict.ElementAt(index);
//         }
//         // Get the savings goals from user
//         public void SetStatement() {
//             bool quit = true;
//             // Only 85% of surplus is available for savings
//             // 15% set aside for sundry, miscellaneous and inflation
//             var difference = _helper1.GetSurplusOrDeficit();
//             float available = Convert.ToSingle(difference * .85);
//             SetStatementTotal(available);
//             while (quit) {
//                 // User selection of preset goals and descriptions
//                 DisplayDictionary();
//                 int opt = int.Parse(Console.ReadLine());
//                 var kVP = GetKeyValuePair(opt);
//                 var key = kVP.Key;
//                 var value = kVP.Value;
//                 float amt = float.Parse(Console.ReadLine());
//                 // Get amount available for saving, less user goal amount and reset the balance
//                 var available4Saving = GetTotal();
//                 var afterSaving = available4Saving - amt;
//                 SetStatementTotal(afterSaving);
//                 // Set the user goal and append to list
//                 Savings savings = new Savings(key, value, afterSaving);
//                 // AddToSavingsList(savings); Remove b4 submission
//                 List<Statement> myList = _helper1.GetListOfObjects();
//                 myList.Add(savings);
//                 quit = _helper1.QuitOrContinue();
//             }
//         }
        // consider renaming this method if not returning value: PassStatement()
        public override Statement SetStatement(Statement statement) {
            return statement;
        }
        // Display and Filing template for Savings objects
        public override string SaveGoal() {
            return $"{GetClassName()}, {GetName()}, {GetDescription()}, {GetAmount()}, {GetPoints()}{TimeManagement.GetToday}, {TimeManagement.GetTotalDays()}";
        }
    } 
}