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
using Newtonsoft.Json;

namespace FinanceMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseAddPage : ContentPage
    {
        private DateTime SelectedDate = DateTime.Now; //The selected date by the user
        private string Selected_Category;// The selected Category from the list 
        private decimal ExpenseAmount;
        private string ExpenseDescription;
        public List<Category> Categories;
        public Category SelectedItem;

        public ExpenseAddPage()
        {
            InitializeComponent();

             Categories = new List<Category>();


             Categories.Add(new Category
             {
                 CategoryName = ExpenseCategory.Food_and_Drink,
                 ImageUrl = "Assets/catering.png"
             });

             Categories.Add(new Category
             {
                 CategoryName = ExpenseCategory.Shopping,
                 ImageUrl = "Assets/shopping.png"
             });

             Categories.Add(new Category
             {
                 CategoryName = ExpenseCategory.Home,
                 ImageUrl = "Assets/home.png"
             });

             Categories.Add(new Category
             {
                 CategoryName = ExpenseCategory.Bills_and_Fees,
                 ImageUrl = "Assets/calculator.png"
             });
             Categories.Add(new Category
             {
                 CategoryName = ExpenseCategory.Entertainment,
                 ImageUrl = "Assets/game.png"
             });
             Categories.Add(new Category
             {
                 CategoryName = ExpenseCategory.Travel,
                 ImageUrl = "Assets/plane.png"
             });
             Categories.Add(new Category
             {
                 CategoryName = ExpenseCategory.HealthCare,
                 ImageUrl = "Assets/hospital.png"
             });

             Categories.Add(new Category
             {
                 CategoryName = ExpenseCategory.Eductaion,
                 ImageUrl = "Assets/notepad.png"
             });

             Categories.Add(new Category
             {
                 CategoryName = ExpenseCategory.Groceries,
                 ImageUrl = "Assets/cart.png"
             });

             Categories.Add(new Category
             {
                 CategoryName = ExpenseCategory.Family_and_Personal,
                 ImageUrl = "Assets/contact.png"
             });

             Categories.Add(new Category
             {
                 CategoryName = ExpenseCategory.Gifts,
                 ImageUrl = "Assets/gift.png"
             });

             Categories.Add(new Category
             {
                 CategoryName = ExpenseCategory.Sports,
                 ImageUrl = "Assets/marketStrategy.png"
             });

             Categories.Add(new Category
             {
                 CategoryName = ExpenseCategory.Beauty,
                 ImageUrl = "Assets/watch.png"
             });

             Categories.Add(new Category
             {
                 CategoryName = ExpenseCategory.Work,
                 ImageUrl = "Assets/marketAnalysis.png"
             });

             Categories.Add(new Category
             {
                 CategoryName = ExpenseCategory.Other,
                 ImageUrl = "Assets/find.png"
             });

            Categories_List.ItemTemplate = new DataTemplate(typeof(ImageCell));
            Categories_List.ItemTemplate.SetBinding(ImageCell.TextProperty, "CategoryName");
            Categories_List.ItemTemplate.SetBinding(ImageCell.ImageSourceProperty, "ImageUrl");
            Categories_List.ItemsSource = Categories;
      
        }

        protected override void OnAppearing()
        {
            var expense = (Expense)BindingContext;
            if (!string.IsNullOrEmpty(expense.FileName))
            {
                string expenseJson = File.ReadAllText(expense.FileName);
                Expense deserializedExpense = JsonConvert.DeserializeObject<Expense>(expenseJson);
                ExpenseDate.Date = deserializedExpense.Date;
                Expense_Name.Text = deserializedExpense.Name;
                Expense_Amount.Text = deserializedExpense.Spending.ToString();
                Description.Text = deserializedExpense.Description;
                SelectedItem = getCategory(deserializedExpense);
            }
            
        }

        private Category getCategory(Expense deserializedExpense) 
        {
            Category match = new Category();
            for (int i = 0; i < Categories.Count -1; i++) 
            {
                if (Categories[i].ImageUrl == deserializedExpense.Category)
                {
                    match.CategoryName = Categories[i].CategoryName;
                    match.ImageUrl = Categories[i].ImageUrl;
                }
            }
            return match;
        }

        private void ExpenseDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            SelectedDate = e.NewDate;
        }


        private void Save_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Expense_Name.Text))
            {
                Expense_Name.Text = string.Empty;

            }

            if (string.IsNullOrEmpty(Description.Text))
            {
                Description.Text = string.Empty;

            }

            if (string.IsNullOrEmpty(Expense_Amount.Text))
            {
                ExpenseAmount=decimal.Zero;

            }
           
            ExpenseDescription = Description.Text;
            ExpenseAmount = Convert.ToDecimal(Expense_Amount.Text);
           
            // we are creating a new expense here. 
            var expense = (Expense)BindingContext;
            expense.Date = SelectedDate;
            expense.Name = Expense_Name.Text;
            expense.Description = ExpenseDescription;
            expense.Spending = ExpenseAmount;
            expense.Category = SelectedItem.ImageUrl;
           
            if (string.IsNullOrEmpty(expense.FileName))
            {
                expense.FileName = Path.Combine(Environment.GetFolderPath(
                                  Environment.SpecialFolder.LocalApplicationData),
                                  $"{Path.GetRandomFileName()}.{expense.Name}.MyExpenses.txt");
                
            }
            var expenseJson = JsonConvert.SerializeObject(expense);
            File.WriteAllText(expense.FileName, expenseJson);
            Navigation.PushModalAsync(new NavigationPage(new ExpenseList())); 
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
            Navigation.PushModalAsync(new NavigationPage(new ExpenseList()));
        }

        private void LogoToolBar_ExpenseAddPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }

        private void Categories_List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            SelectedItem = (Category)e.SelectedItem;
        }
    }
}