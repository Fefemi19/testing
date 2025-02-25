using System;
using System.Collections.Generic;

namespace MyExpenseTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            //used constructor to create an instance of a class to set the methods that initialize the list.
            SettingsMethods expenseTracker = new SettingsMethods();

            //declared a bool to control the program
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nMy Expense Tracker");
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. View Expenses");
                Console.WriteLine("3. Update Expense");
                Console.WriteLine("4. Remove Expense");
                Console.WriteLine("5. Total Expenses");
                Console.WriteLine("6. Exit Application");
                Console.Write("Choose an option: (1-6): ");

                //created string to accept input/option
                string option = Console.ReadLine();

                //created a switch for my the options to be accepted 
                //used expenseTracker.[theMethod] because i used public class, where i have to call the method from another class
                switch (option)
                {
                    case "1":
                        expenseTracker.addExpense();
                        break;
                    case "2":
                        expenseTracker.viewExpenses();
                        break;
                    case "3":
                        expenseTracker.updateExpense();
                        break;
                    case "4":
                        expenseTracker.removeExpense();
                        break;
                    case "5":
                        expenseTracker.totalExpenses();
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("Exiting the application...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            }
        }
    }

    //created a class to set my methods to track expense
    public class SettingsMethods
    {
        //created a constructor to initialize list of things bought
        private List<Properties> ThingsBought = new List<Properties>();

        //added a method to add expense
        public void addExpense()
        {
            Console.Write("what did you buy: ");
            string name = Console.ReadLine();

            Console.Write("How much: ");
            //declared a variable for amount using decimal data type because i expect decimal input
            //converted input to decimal using try parsing method. (a method the covert text to numbers or date).
            //used conditional statement to check if the input can b accepted or not.

            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                //applicable for date
                Console.WriteLine("Which day (mm/dd/yyyy): ");
                
                if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                {
                    ThingsBought.Add(new Properties(name, amount, date));
                    Console.WriteLine("Expense added successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid date. Please enter a valid date in MM/dd/yyyy format.");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount. Please enter a valid number.");
            }
        }
        //declared a method to view expenses
        public void viewExpenses()
        {
            //used conditional.s to check if there are expense on the list
            if (ThingsBought.Count == 0)
            {
                Console.WriteLine("No expenses recorded.");
            }
            else
            {
                Console.WriteLine("\nList of Things Bought:");
                //used for loop to count index from zero [counting in arrays start from zero(0)], continue counting as long as the index is less than the total number of expenses, move from one expense to the next.
                for (int i = 0; i < ThingsBought.Count; i++)
                {
                    Console.WriteLine($"Bought {ThingsBought[i].Name}, for {ThingsBought[i].Amount:C}, on {ThingsBought[i].Date.ToShortDateString()}");
                }
            }
        }

        public void updateExpense()
        {
            //used C.S to check if there are expense on the list or not
            if (ThingsBought.Count == 0)
            {
                Console.WriteLine("Nothing to update.");
            }
            else
            {
                Console.WriteLine("Enter the name of the expense to update: ");
                string name = Console.ReadLine();
                //declared a variable to look for that inputs name 
                var updateThingsBought = ThingsBought.Find(s => s.Name == name);
                //used C.S to check if the name is on the list (update) or not
                if (updateThingsBought != null)
                {
                    Console.Write("How much: ");
                    //covert new amount to decimal
                    if (decimal.TryParse(Console.ReadLine(), out decimal newAmount))
                    {
                        Console.WriteLine("what day: ");
                        //converted newdate to datetime
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime newDate))
                        {
                            //new amount and date to expense list
                            updateThingsBought.Amount = newAmount;
                            updateThingsBought.Date = newDate;
                            Console.WriteLine("List updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid date. Please enter a valid date in MM/dd/yyyy format.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount. Please enter a valid number.");
                    }
                }
                else
                {
                    Console.WriteLine("Expense not found.");
                }
            }
        }

        public void removeExpense()
        {
            if (ThingsBought.Count == 0)
            {
                Console.WriteLine("No expenses added.");
            }
            else
            {
                Console.Write("Enter the name of the expense to remove: ");
                string name = Console.ReadLine();

                var removeThingsBought = ThingsBought.Find(s => s.Name == name);

                if (removeThingsBought != null)
                {
                    ThingsBought.Remove(removeThingsBought);
                    Console.WriteLine("Expense removed successfully.");
                }
                else
                {
                    Console.WriteLine("Expense not found.");
                }
            }
        }

        public void totalExpenses()
        {
            decimal totalThingsBought = ThingsBought.Sum(e => e.Amount);
            Console.WriteLine($"Total expenses: {totalThingsBought}");
        }
    }
    //created a class to name all properties
    public class Properties
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        //assigned variables to the properties using parameters
        public Properties(string name, decimal amount, DateTime date)
        {
            Name = name;
            Amount = amount;
            Date = date;
        }
    }
}
