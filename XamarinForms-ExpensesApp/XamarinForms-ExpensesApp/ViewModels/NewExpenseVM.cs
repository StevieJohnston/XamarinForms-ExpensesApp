using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using XamarinFormsExpensesApp.Models;

namespace XamarinFormsExpensesApp.ViewModels
{
    public class NewExpenseVM : INotifyPropertyChanged
    {
        public ObservableCollection<string> Categories { get; set; }

        public string expenseName;
        public string ExpenseName
        {
            get { return expenseName; }
            set
            {
                expenseName = value;
                OnPropertyChanged("ExpenseName");
            }
        }

        public string expenseDescription;
        public string ExpenseDescription
        {
            get { return expenseDescription; }
            set
            {
                expenseDescription = value;
                OnPropertyChanged("ExpenseDescription");
            }
        }

        public float expenseAmount;
        public float ExpenseAmount
        {
            get { return expenseAmount; }
            set
            {
                expenseAmount = value;
                OnPropertyChanged("ExpenseAmount");
            }
        }

        public DateTime expenseDate;
        public DateTime ExpenseDate
        {
            get { return expenseDate; }
            set
            {
                expenseDate = value;
                OnPropertyChanged("ExpenseDate");
            }
        }

        public string expenseCategory;
        public string ExpenseCategory
        {
            get { return expenseCategory; }
            set
            {
                expenseCategory = value;
                OnPropertyChanged("ExpenseCategory");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public Command SaveExpenseCommand
        {
            get; set;
        }

        public NewExpenseVM()
        {
            Categories = new ObservableCollection<string>();
            GetCategories();
            ExpenseDate = DateTime.Today;
            SaveExpenseCommand = new Command(InsertExpense);
        }

        public void InsertExpense()
        {
            Expense expense = new Expense
            {
                Name = expenseName,
                Amount = expenseAmount,
                Category = expenseCategory,
                Desciption = expenseDescription,
                Date = expenseDate
            };

            int response = Expense.InsertExpense(expense);

            if (response > 0)
                Application.Current.MainPage.Navigation.PopAsync();
            else
                Application.Current.MainPage.DisplayAlert("Error", "No items were inserted", "Ok");
        }

        private void GetCategories()
        {
            Categories.Clear();
            Categories.Add("Housing");
            Categories.Add("Debt");
            Categories.Add("Health");
            Categories.Add("Food");
            Categories.Add("Personal");
            Categories.Add("Travel");
            Categories.Add("Other");
        }
    }
}
