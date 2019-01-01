using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XamarinFormsExpensesApp.Models;
using XamarinFormsExpensesApp.Views;

namespace XamarinFormsExpensesApp.ViewModels
{
    public class ExpensesVM
    {
        public Command AddExpenseCommand { get; set; }

        public ObservableCollection<Expense> Expenses { get; set; }

        public ExpensesVM()
        {
            AddExpenseCommand = new Command(AddExpense);

            Expenses = new ObservableCollection<Expense>();

            GetExpenses();
        }

        private void GetExpenses()
        {
            var expenses = Expense.GetExpenses();
            Expenses.Clear();
            foreach (var expense in expenses)
            {
                Expenses.Add(expense);
            }
        }

        public void AddExpense()
        {
            Application.Current.MainPage.Navigation.PushAsync(new NewExpensePage());
        }
    }
}
