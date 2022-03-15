using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FinanceMobileApp.Models;

namespace FinanceMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCategory : ContentPage
    {
        public List<Category> Categories;
        public Category SelectedItem;

        public AddCategory()
        {
            InitializeComponent();
            Categories = new List<Category>();
            Expenses_Category.ItemsSource = Categories;

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

            /*  Categories.Add(new Category
              {
                  CategoryName = "Car",
                  ImageUrl = ""
              });
            */
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

           
            //Expenses_Category.ItemTemplate= new Binding("CategoryName");
        }

        private void Expenses_Category_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            SelectedItem= (Category)e.SelectedItem;
            Navigation.PopModalAsync();


        }
    }
}