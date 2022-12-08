using System;
using System.Globalization;

namespace ProgChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the Checking Account with initial balance
            CheckingAcct checking = new CheckingAcct("John", "Doe", 2500.0m);
            Console.WriteLine($"\nChecking owner: {checking.AccountOwner}");
            Console.WriteLine($"Checking balance is {checking.Balance:C2}");
            Console.WriteLine("Next, deposit 200");
            checking.Deposit(200.0m);

            // Expected checking bal should be 2700
            Console.WriteLine($"Checking balance is {checking.Balance:C2}");
            Console.WriteLine("Next, withdraw 50");
            checking.Withdraw(50.0m);
            // Expected checking bal should be 2650
            Console.WriteLine($"Checking balance is {checking.Balance:C2}");

            // try to overdraw checking - should result in extra charge
            Console.WriteLine("Next, withdraw 3000");
            checking.Withdraw(3000.0m);
            Console.WriteLine($"Checking balance is {checking.Balance:C2}");

            // Practice displaying a negative sign instead of parenthesis
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            culture.NumberFormat.CurrencyNegativePattern = 1;
            String strBal = String.Format(culture, "{0:C2}", checking.Balance);
            Console.WriteLine($"Checking balance is {strBal}");

            // Create the Savings Account with interest and initial balance
            SavingsAcct saving = new SavingsAcct("Jane", "Doe", 0.025m, 1000.0m);
            Console.WriteLine($"\nSavings owner: {saving.AccountOwner}");
            Console.WriteLine($"Savings balance is {saving.Balance:C2}");
            Console.WriteLine("Next, deposit 150");
            saving.Deposit(150.0m);
            // Expected savings bal should be 1150
            Console.WriteLine($"Savings balance is {saving.Balance:C2}");
            Console.WriteLine("Next, withdraw 125");
            saving.Withdraw(125.0m);
            // Expected savings bal should be 1000
            Console.WriteLine($"Savings balance is {saving.Balance:C2}");

            // Apply the Savings interest
            Console.WriteLine("\nNext, apply savings interest");
            saving.ApplyInterest();
            // Savings balance should now be 1050.63 
            Console.WriteLine($"Savings balance is {saving.Balance:C2}");

            // More than 3 Savings withdrawals should result in 2.00 charge
            Console.WriteLine("Next, test 3 consec withdrawls");
            saving.Withdraw(10.0m);
            saving.Withdraw(20.0m);
            saving.Withdraw(30.0m);
            // Savings balance should now be 988.63
            Console.WriteLine($"Savings balance is {saving.Balance:C2}");

            // try to overdraw savings - this should be denied and print message
            saving.Withdraw(2000.0m);
            Console.WriteLine($"Savings balance is {saving.Balance:C2}");

            // Expected final values should be -385 and 988.63
        }
    }
}
