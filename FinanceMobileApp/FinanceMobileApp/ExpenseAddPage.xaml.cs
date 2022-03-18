using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FinanceMobileApp.Models;
using System.Collections.ObjectModel;
using System.IO;

namespace FinanceMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseAddPage : ContentPage
    {
        private DateTime SelectedDate; //The selected date by the user
        public string Selected_Category;// The selected Category from the list 
        public string ExpenseName;
        public decimal ExpenseAmount;
        public string ExpenseDescription;

        public List<Category> Categories;
        public string SelectedItem;


        public ExpenseAddPage()
        {
            InitializeComponent();
            Expense_Category.ItemsSource = Categories;
            Expense_Category.ItemDisplayBinding = new Binding("CategoryName");

            Categories = new List<Category>();


            Categories.Add(new Category
            {
                CategoryName = ExpenseCategory.Food_and_Drink,
                ImageUrl = "Assets/Icons/catering-icon.png"
            });

            Categories.Add(new Category
            {
                CategoryName = ExpenseCategory.Shopping,
                ImageUrl = "Assets/Icons/shopping-icon.png"
            });

            Categories.Add(new Category
            {
                CategoryName = ExpenseCategory.Transposrt,
                ImageUrl = ""
            });

            Categories.Add(new Category
            {
                CategoryName = ExpenseCategory.Home,
                ImageUrl = "Assets/Icons/home-icon.png"
            });

            Categories.Add(new Category
            {
                CategoryName = ExpenseCategory.Bills_and_Fees,
                ImageUrl = "Assets/Icons/calculator-icon.png"
            });
            Categories.Add(new Category
            {
                CategoryName = ExpenseCategory.Entertainment,
                ImageUrl = "Assets/Iconscalculator-icon.png"
            });
            Categories.Add(new Category
            {
                CategoryName = ExpenseCategory.Travel,
                ImageUrl = "Assets/Icons/plane-icon.png"
            });
            Categories.Add(new Category
            {
                CategoryName = ExpenseCategory.HealthCare,
                ImageUrl = "Assets/Icons/hospital-icon.png"
            });

            Categories.Add(new Category
            {
                CategoryName = ExpenseCategory.Eductaion,
                ImageUrl = "Assets/Icons/notepad-icon.png"
            });

            Categories.Add(new Category
            {
                CategoryName = ExpenseCategory.Groceries,
                ImageUrl = "Assets/Icons/cart-icon.png"
            });

            Categories.Add(new Category
            {
                CategoryName = ExpenseCategory.Family_and_Personal,
                ImageUrl = "Assets/Icons/contact-icon.png"
            });

            Categories.Add(new Category
            {
                CategoryName = ExpenseCategory.Gifts,
                ImageUrl = "Assets/Icons/gift-icon.png"
            });

            Categories.Add(new Category
            {
                CategoryName = ExpenseCategory.Sports,
                ImageUrl = "Assets/Icons/market strategy-icon.png"
            });

            Categories.Add(new Category
            {
                CategoryName = ExpenseCategory.Beauty,
                ImageUrl = "Assets/Icons/watch-icon.png"
            });

            Categories.Add(new Category
            {
                CategoryName = ExpenseCategory.Work,
                ImageUrl = "Assets/Icons/market analysis-icon.png"
            });

            Categories.Add(new Category
            {
                CategoryName = ExpenseCategory.Other,
                ImageUrl = "Assets/Icons/find-icon.png"
            });


            Expense_Category.ItemsSource = Categories;
            Expense_Category.ItemDisplayBinding = new Binding("CategoryName");


        }

        private void Expense_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                SelectedItem = picker.Items[selectedIndex];
            }
        }

        private void ExpenseDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            SelectedDate = e.NewDate;
        }


        private void Save_Clicked(object sender, EventArgs e)
        {
            ExpenseName = Expense_Name.Text;
            ExpenseDescription = Description.Text;
            ExpenseAmount = Convert.ToDecimal(Expense_Amount);

            var expense = (Expense)BindingContext;
            expense.Date = SelectedDate;
            expense.Name = ExpenseName;
            expense.Description = ExpenseDescription;
            expense.Spending = ExpenseAmount;
            string ExpenseText = expense.Name + Environment.NewLine + expense.Date + Environment.NewLine + expense.Spending + Environment.NewLine + expense.Description +
                Environment.NewLine;

            if (string.IsNullOrEmpty(expense.FileName))
            {


                expense.FileName = Path.Combine(Environment.GetFolderPath(
                                  Environment.SpecialFolder.LocalApplicationData),
                                  $"{Path.GetRandomFileName()} .expenses.txt");


                File.WriteAllText(expense.FileName, ExpenseText);

            }
            Navigation.PushModalAsync(new NavigationPage(new MainPage())); //*Change to the list of expenses 


        }

        private async void Cancel_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void Budgets_ExpenseAddPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new MainPage()));//Change to all budgets page
        }

        private void Expenses_ExpenseAddPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new MainPage()));//Change to expenses page
        }

        private void LogoToolBar_ExpenseAddPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }
    }
}