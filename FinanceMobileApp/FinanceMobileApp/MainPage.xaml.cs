using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinanceMobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void AddExpense_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new ExpenseAddPage()));
        }

        private void AddBudget_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new BudgetAddPage()));
        }

        private void Budgets_Clicked(object sender, EventArgs e)
        {

        }

        private void Expenses_Clicked(object sender, EventArgs e)
        {

        }
    }
}
