using System;
using System.Collections.ObjectModel;
using XamarinFormsExpensesApp.Models;
using System.Linq;

namespace XamarinFormsExpensesApp.ViewModels
{
    public class CategoriesVM
    {
        public ObservableCollection<string> Categories { get; set; }
        public ObservableCollection<CategoryExpenses> CategoriesExpensesCollection { get; set; }

        public CategoriesVM()
        {
            Categories = new ObservableCollection<string>();
            CategoriesExpensesCollection = new ObservableCollection<CategoryExpenses>();

            GetCategories();
            GetExpensesPerCategory();
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

        public void GetExpensesPerCategory()
        {
            CategoriesExpensesCollection.Clear();
            float totalExpensesAmount = Expense.TotalExpensesAmount();
            foreach (string c in Categories)
            {
                var expenses = Expense.GetExpenses(c);
                float expensesAmountInCategory = expenses.Sum(e => e.Amount);

                CategoryExpenses categoryExpenses = new CategoryExpenses
                {
                    Category = c,
                    ExpensesPercentage = expensesAmountInCategory / totalExpensesAmount
                };
                CategoriesExpensesCollection.Add(categoryExpenses);
            }
        }

        public class CategoryExpenses
        {
            public string Category { get; set; }
            public float ExpensesPercentage { get; set; }
        }
    }
}
