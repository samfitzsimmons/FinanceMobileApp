using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using FinanceMobileApp.Models;

namespace FinanceMobileApp.Models
{
    public class Category 
    { 
        // This class is to load the expense categories to the picker in add new expense xaml page

        public ExpenseCategory CategoryName { get; set; }
        public string ImageUrl { get; set; }

    }
}
