using FinanceMobileApp.Models;
using Newtonsoft.Json;
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
    public partial class ExpenseList : ContentPage
    {
        public ExpenseList()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            var expenses = new List<Expense>();
            var files = Directory.EnumerateFiles(Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData), "*.expenses.txt");
            foreach (var filename in files)
            {
                string expenseJson = File.ReadAllText(filename);
                var expense = JsonConvert.DeserializeObject<Expense>(expenseJson);
                expenses.Add(expense);
            }
            ExpenseListView.ItemsSource = expenses.OrderByDescending(n => n.Date);
        }

        private async void OnExpenseAddedClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ExpenseAddPage
            {
                BindingContext = new Expense()
            }));
        }

        private async void ExpenseListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ExpenseAddPage
            {
                BindingContext = (Expense)e.SelectedItem
            }));

        }

        private void Budgets_ExpenseList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new MainPage()));//*Change to all budgets
        }

        private void Expenses_ExpenseList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new ExpenseList()));
        }

        private void LogoToolBar_ExpenseList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }
    }
}