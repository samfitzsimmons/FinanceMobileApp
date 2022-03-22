using FinanceMobileApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BudgetList : ContentPage
    {
        public BudgetList()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var budgets = new List<Budget>();
            var files = Directory.EnumerateFiles(Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData), "*.budgets.txt");
            foreach (var filename in files)
            {
                var monthString = Budget.MonthInFilename(filename);
                var month = Budget.ConvertToMonths(monthString);

                var budget = new Budget
                {
                    BudgetAmount = Convert.ToDecimal(File.ReadAllText(filename)),
                    BudgetMonth = month,
                    BudgetFileName = filename
                };
                budgets.Add(budget);
            }
            BudgetListView.ItemsSource = budgets.OrderByDescending(n => n.BudgetMonth);
        }

        private async void AddBudgetButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new BudgetAddPage())); 
        }

        private async void BudgetListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new BudgetAddPage
            {
                BindingContext = (Budget)e.SelectedItem
            }));
        }

        private void Budgets_BudgetList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new BudgetList()));
        }

        private void Expenses_BudgetList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new ExpenseList()));
        }

        private void LogoToolBar_BudgetList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }
    }
}