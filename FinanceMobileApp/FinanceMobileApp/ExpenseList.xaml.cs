﻿using FinanceMobileApp.Models;
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
                    Environment.SpecialFolder.LocalApplicationData), "*.notes.txt");
            foreach (var filename in files)
            {
                var expense = new Expense
                {                
                    Date = File.GetCreationTime(filename),
                    FileName = filename
                };
                expenses.Add(expense);
            }
            ExpenseListView.ItemsSource = expenses.OrderByDescending(n => n.Date);
        }

        private async void OnExpenseAddedClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ExpenseAddPage
            {
                BindingContext = new Expense()
            });
        }

        private async void ExpenseListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new ExpenseAddPage
            {
                BindingContext = (Expense)e.SelectedItem
            });

        }
    }
}