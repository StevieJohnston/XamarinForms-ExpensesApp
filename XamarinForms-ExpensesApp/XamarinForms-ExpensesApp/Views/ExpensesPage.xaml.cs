using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinFormsExpensesApp.ViewModels;

namespace XamarinFormsExpensesApp.Views
{
    public partial class ExpensesPage : ContentPage
    {
        ExpensesVM ViewModel;
        public ExpensesPage()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as ExpensesVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.GetExpenses();
        }
    }
}
