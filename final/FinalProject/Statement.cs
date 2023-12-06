using System;

namespace FinancialPrudence {
    public abstract class Statement {
        private string _name;
        private string _description;
        private float _amount;
        private float _totalAmount;
        private string _oldDate= "yyyy-MM-dd";
        private List<Statement> _objectList = new List<Statement>();
        // private Savings _savings = new Savings();
        // FilesHandler _filesHandler = new FilesHandler();
        public Statement(string name = "name", string description = "description", float amount = 0) {
            _name = name;
            _description = description;
            _amount = amount;
        }
        // private static bool ReferenceEquals(Savings _savings)
        // {
        //     throw new NotImplementedException();
        // }
        public void SetOldDate(string oldDate) {
            _oldDate = oldDate;
        }
        public string GetOldDate() {
            return _oldDate;
        }
        public string GetName() {
            return _name;
        }
        public string GetDescription() {
            return _description;
        }
        public float GetAmount() {
            return _amount;
        }
        public void SetName(string name) {
            _name = name;
        }
        public void SetDescription(string description) {
            _description = description;
        }
        public void SetAmount(float amount) {
            _amount = amount;
        }
        public void SetStatementTotal(float amount) {
            _totalAmount += amount;
        }
        public float GetTotal() {
            return _totalAmount;
        }
        // public void AddToObjectList(Statement obj){
        //     _objectList.Add(obj);
        // }
        // public void ResetObjectList() {
        //     _objectList = null;
        // }
        public List<Statement> GetObjectList() {
            return _objectList;
        }
        public string GetClassName() {
            var className = GetType().Name;
            return className;
        }
        public float GetMaxAmount() {
            float surplus = Helper.GetSurplusOrDeficit(); // Returns difference between income and expenses
            var maxAmountPerGoal = surplus/6; // Due to 6 savings predetermine goals
            return maxAmountPerGoal;
        }
        public int ComputePoints(float userAmount) {
            var maxAmount = GetMaxAmount();
            var points = userAmount/maxAmount * 10; // 
            return (int) Math.Floor(points);
        }
        public void GetStatement() {
            
            bool quit = true;
            while (quit) {
                // Display a message
                Information.DisplayIncomeInfo();
                Console.Write("Enter name of statement: ");
                string name = Console.ReadLine();
                SetName(name);
                Console.Write("Enter description of statement: ");
                string description = Console.ReadLine();
                SetDescription(description);
                Console.Write("Enter the amount for statement: ");
                float incomeEarned = float.Parse(Console.ReadLine());
                // Convert annual income to monthly income
                float income = Helper.GetMonthlyIncome(incomeEarned);
                SetStatementTotal(income);

                // If the object refers to an instance of the Savings class
                // compute and set points
                // if (Statement.ReferenceEquals(_savings)) {
                //     _savings.SetPoints(Savings.ComputePoints(income));
                // }

                // Add this object to its list
                var objList = GetObjectList();
                objList.Add(this);                
                // User quits (or continue) the loop
                quit = Helper.QuitOrContinue();
            }
        }
        public abstract string SaveGoal();
        public abstract Statement SetStatement(Statement statement);
    }
}