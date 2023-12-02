using System;

namespace FinancialPrudence {
    public class ExpensesStatement : Statement {

        public ExpensesStatement(string name = "name", string description = "description", float amount = 0) : base(name, description, amount){

        }
        public override Statement SetStatement(Statement statement) {
            return statement;
        }
        // Display and Filing template for ExpensesStatement objects
        public override string SaveGoal() {
            return $"{GetClassName()}, {GetName()}, {GetDescription()}, {GetAmount()}";
        }    
    }
}