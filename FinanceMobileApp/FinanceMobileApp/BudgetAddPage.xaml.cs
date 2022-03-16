using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FinanceMobileApp.Models.Budget;

namespace FinanceMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BudgetAddPage : ContentPage
    {
        public List<string> BudgetMonths { get; set; }
        public BudgetAddPage()
        {
            InitializeComponent();

            BudgetMonths = new List<string>();
            BudgetMonths.Add(Months.January.ToString());
            BudgetMonths.Add(Months.February.ToString());
            BudgetMonths.Add(Months.March.ToString());
            BudgetMonths.Add(Months.April.ToString());
            BudgetMonths.Add(Months.May.ToString());
            BudgetMonths.Add(Months.June.ToString());
            BudgetMonths.Add(Months.July.ToString());
            BudgetMonths.Add(Months.August.ToString());
            BudgetMonths.Add(Months.September.ToString());
            BudgetMonths.Add(Months.October.ToString());
            BudgetMonths.Add(Months.November.ToString());
            BudgetMonths.Add(Months.December.ToString());

            ChooseBudgetMonth.ItemsSource = BudgetMonths;
        }

        private void SaveBudget_Clicked(object sender, EventArgs e)
        {

        }

        private void CancelBudget_Clicked(object sender, EventArgs e)
        {

        }

        private void Budgets_BudgetAddPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new MainPage()));//change to all budgets
        }

        private void Expenses_BudgetAddPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new MainPage()));//Change to expenses
        }

        private void LogoToolBar_BudgetAddPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }
    }
}