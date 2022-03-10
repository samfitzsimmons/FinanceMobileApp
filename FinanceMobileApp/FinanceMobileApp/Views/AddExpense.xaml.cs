using FinanceMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddExpense : ContentPage
    {
        public IList<Models.Category> Categories { get { return CategoryData.Categories; } }

        private DateTime SelectedDate;
        public string Selected_Category;



        public AddExpense()
        {
            InitializeComponent();
            Expense_Category.ItemsSource = (System.Collections.IList)Categories;
            Expense_Category.ItemDisplayBinding = new Binding("CategoryName");


        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            SelectedDate = e.NewDate;

        }

        private void Expense_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }
    }
}