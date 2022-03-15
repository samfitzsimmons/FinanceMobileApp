using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceMobileApp.Models
{
    class Budget
    {
        public enum Months
        {
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        public Months BudgetMonth { get; set; }
        public string GoalTitle { get; set; }
        public decimal BudgetAmount { get; set; }
        public string GoalDescription { get; set; }
        public List<Expense> ExpenseList { get; set; }
        public decimal TotalExpenseAmount { get; set; }
        public string BudgetFileName { get; set; }
    }
}
