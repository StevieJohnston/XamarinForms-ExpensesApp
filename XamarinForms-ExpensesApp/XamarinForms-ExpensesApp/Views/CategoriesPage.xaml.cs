using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinFormsExpensesApp.ViewModels;

namespace XamarinFormsExpensesApp.Views
{
    public partial class CategoriesPage : ContentPage
    {
        CategoriesVM ViewModel;
        public CategoriesPage()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as CategoriesVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.GetExpensesPerCategory();
        }
    }
}
