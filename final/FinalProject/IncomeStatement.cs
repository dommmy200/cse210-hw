using System;

namespace FinancialPrudence {
   
    public class IncomeStatement : Statement {

        public IncomeStatement(string name = "name", string description = "description", float amount = 0) : base(name, description, amount){

        }

        // consider renaming this method if not returning value: PassStatement()
        public override Statement SetStatement(Statement statement) {
            return statement;
        }
        // Display and Filing template for IncomeStatement objects
        public override string SaveGoal() {
            return $"{GetClassName()}, {GetName()}, {GetDescription()}, {GetAmount()}";
        }
    }
}