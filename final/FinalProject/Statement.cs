using System;

namespace FinancialPrudence {
    public abstract class Statement {
        private string _name;
        private string _description;
        private float _amount;
        private float _totalAmount;
        private List<Statement> _objectList;
        // private Savings _savings = new Savings();
        // FilesHandler _filesHandler = new FilesHandler();
        public Statement(string name = "name", string description = "description", float amount = 0) {
            _name = name;
            _description = description;
            _amount = amount;
        }
        private static bool ReferenceEquals(Savings _savings)
        {
            throw new NotImplementedException();
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
        public void AddToObjectList(Statement obj){
            _objectList.Add(obj);
        }
        public void ResetObjectList() {
            _objectList = null;
        }
        public List<Statement> GetObjectList() {
            return _objectList;
        }
        public string GetClassName() {
            var className = GetType().Name;
            return className;
        }
        public void GetStatement() {
            
            bool quit = true;
            while (quit) {
                // Display a message
                Information.DisplayIncomeInfo();
                Console.Write("Enter name of income, expenses or goal: ");
                string name = Console.ReadLine();
                SetName(name);
                Console.Write("Enter description of income, expenses or goal: ");
                string description = Console.ReadLine();
                SetDescription(description);
                Console.Write("Enter the amount of income, expenses or goal: ");
                float incomeEarned = float.Parse(Console.ReadLine());
                // Convert annual income to monthly income
                float income = Helper.GetMonthlyIncome(incomeEarned);
                SetAmount(income);
                // If the object refers to an instance of the Savings class
                // compute and set points
                
                // if (Statement.ReferenceEquals(_savings)) {
                //     _savings.SetPoints(Savings.ComputePoints(income));
                // }
                // // User quits (or continue) the loop
                // var objList = GetObjectList();
                // objList.Add(this);
                quit = Helper.QuitOrContinue();
            }
        }
        public abstract string SaveGoal();
        public abstract Statement SetStatement(Statement statement);
    }
}