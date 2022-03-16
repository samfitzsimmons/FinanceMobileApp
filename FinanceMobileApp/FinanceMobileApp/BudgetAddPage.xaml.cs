using FinanceMobileApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            var budget = (Budget)BindingContext;

            if (string.IsNullOrEmpty(budget.BudgetFileName) && BudgetAmount.Text.Length > 0)
            {
                budget.BudgetMonth = (Months) ChooseBudgetMonth.SelectedItem;
                budget.GoalTitle = GoalTitle.Text;
                budget.GoalDescription = BudgetDescription.Text;
                budget.BudgetAmount = Convert.ToDecimal(BudgetAmount.Text);
                var budgetAmountString = Convert.ToString(budget.BudgetAmount);

                budget.BudgetFileName = Path.Combine(Environment.GetFolderPath(
                                  Environment.SpecialFolder.LocalApplicationData),
                                  $"{Path.GetRandomFileName()}" +
                                  $".{budget.GoalTitle}.{budget.BudgetMonth}.budgets.txt");

                File.WriteAllText(budget.BudgetFileName, budgetAmountString);

                if (budget.GoalDescription.Length > 0)
                {
                    budget.BudgetGoalDescriptionFilename = Path.Combine(Environment.GetFolderPath(
                                      Environment.SpecialFolder.LocalApplicationData),
                                      $"{Path.GetRandomFileName()}" +
                                      $".{budget.GoalTitle}.{budget.BudgetMonth}.budgetdescription.txt");

                    File.WriteAllText(budget.BudgetGoalDescriptionFilename, budget.GoalDescription);
                }

            }

            Navigation.PushModalAsync(new NavigationPage(new MainPage())); //*Change to BudgetList page
        }


        private void DeleteBudget_Clicked(object sender, EventArgs e)
        {
            var budget = (Budget)BindingContext;

            // If there is a deck
            if (File.Exists(budget.BudgetFileName))
            {
                // Deletes budget amount
                var file = Directory.EnumerateFiles(Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                    $"*.{budget.GoalTitle}.{budget.BudgetMonth}.budgets.txt");

                File.Delete(file.ToString());
                File.Delete(budget.BudgetFileName);// Deletes budget amount filename

                // Deletes goal description
                if (budget.GoalDescription.Length > 0)
                {
                    var goalfile = Directory.EnumerateFiles(Environment.GetFolderPath(
                        Environment.SpecialFolder.LocalApplicationData),
                        $"*.{budget.GoalTitle}.{budget.BudgetMonth}.budgetdescription.txt");

                    File.Delete(goalfile.ToString());
                    File.Delete(budget.BudgetGoalDescriptionFilename);// Deletes budget amount filename
                }
            }

            Navigation.PushModalAsync(new NavigationPage(new MainPage())); //*Change to budget list page
        }

        private void Budgets_BudgetAddPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new MainPage()));//*Change to all budgets
        }

        private void Expenses_BudgetAddPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new MainPage()));//*Change to expenses
        }

        private void LogoToolBar_BudgetAddPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }
    }
}