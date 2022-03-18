using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FinanceMobileApp.Models;

namespace FinanceMobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private  void AddExpense_Clicked(object sender, EventArgs e)
        {
             Navigation.PushModalAsync(new NavigationPage(new ExpenseAddPage { BindingContext = new Expense() }));
        }

        private void AddBudget_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage
                (new BudgetAddPage{ BindingContext = new Budget() })); ;
        }

        private void Budgets_Clicked(object sender, EventArgs e)
        {

        }

        private void Expenses_Clicked(object sender, EventArgs e)
        {

        }
    }
}
