using System;

namespace FinancialPrudence {
    public abstract class Statement {
        private string _name;
        private string _description;
        private float _amount;
        private float _totalAmount;
        private Information _info = new();
        private Helper _helper1 = new();
        private List<Statement> _objectList;
        public Statement(string name = "name", string description = "description", float amount = 0) {
            _name = name;
            _description = description;
            _amount = amount;
        }
        // public string Name {get; set;}
        // public string Description {get; set;}
        // public float Amount {get; set;}
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
                _info.DisplayIncomeInfo();
                Console.WriteLine("Enter name of income, expenses or goal: ");
                string name = Console.ReadLine();
                SetName(name);
                Console.WriteLine("Enter description of income, expenses or goal: ");
                string description = Console.ReadLine();
                SetDescription(description);
                Console.WriteLine("Enter the amount of income, expenses or goal: ");
                float incomeEarned = float.Parse(Console.ReadLine());
                // Convert annual income to monthly income
                float income = _helper1.GetMonthlyIncome(incomeEarned);
                SetAmount(income);
                //Append variables to list object
                // _helper1.AddToIncomeList(incomeName, description, income);
                // User quits (or continue) the loop
                var objList = GetObjectList();
                objList.Add(this);
                quit = _helper1.QuitOrContinue();
            }
        }
        public abstract string SaveGoal();
        public abstract Statement SetStatement(Statement statement);
        // consider renaming this method if not returning value: UserStatement()
        // public abstract void GetStatement();
        // public abstract void SetStatementTotal(float amount);
        // public abstract float GetTotal();
    }
}