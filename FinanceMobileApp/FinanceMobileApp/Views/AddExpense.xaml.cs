using FinanceMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FinanceMobileApp.Views;

namespace FinanceMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddExpense : ContentPage
    {
        //public IList<Models.Category> Categories { get { return CategoryData.Categories; } }

        private DateTime SelectedDate;
        //public string Selected_Category;



        public AddExpense()
        {
            InitializeComponent();
            //Expense_Category.ItemsSource = (System.Collections.IList)Categories;
            //Expense_Category.ItemDisplayBinding = new Binding("CategoryName");


        }

    
        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            SelectedDate = e.NewDate;

        }

        private void Category_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddCategory());
        }
    }
}