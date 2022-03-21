using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceMobileApp.Models
{
    class Expense
    {
        public decimal Spending { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }

 

    public enum ExpenseCategory
    {
        Food_and_Drink,
        Shopping,
        Transposrt,
        Home,
        Bills_and_Fees,
        Entertainment,
        Car,
        Travel,
        HealthCare,
        Eductaion,
        Groceries,
        Family_and_Personal,
        Gifts,
        Sports,
        Beauty,
        Work,
        Other
    }
}

