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
            December,
            Unknown
        }

        public Months BudgetMonth { get; set; }
        public string GoalTitle { get; set; }
        public decimal BudgetAmount { get; set; }
        public string GoalDescription { get; set; }
        public List<Expense> ExpenseList { get; set; }
        public decimal TotalExpenseAmount { get; set; }
        public string BudgetFileName { get; set; }
        public string BudgetGoalDescriptionFilename { get; set; }

        public static Months ConvertToMonths(string month)
        {
            switch (month)
            {
                case "January":
                    Months month1 = Months.January;
                    return month1;
                case "February":
                    Months month2 = Months.February;
                    return month2;
                case "March":
                    Months month3 = Months.March;
                    return month3;
                case "April":
                    Months month4 = Months.April;
                    return month4;
                case "May":
                    Months month5 = Months.May;
                    return month5;
                case "June":
                    Months month6 = Months.June;
                    return month6;
                case "July":
                    Months month7 = Months.July;
                    return month7;
                case "August":
                    Months month8 = Months.August;
                    return month8;
                case "September":
                    Months month9 = Months.September;
                    return month9;
                case "October":
                    Months month10 = Months.October;
                    return month10;
                case "November":
                    Months month11 = Months.November;
                    return month11;
                case "December":
                    Months month12 = Months.December;
                    return month12;
                default:
                    return Months.Unknown;
            }
        }
    }
}
