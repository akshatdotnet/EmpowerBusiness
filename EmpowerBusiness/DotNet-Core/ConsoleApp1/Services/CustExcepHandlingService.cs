using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class CustExcepHandlingService : ICustExcepHandling
    {
        public void BankingApp()
        {
            try
            {
                // Simulate user input for a banking transaction
                Console.WriteLine("Enter your account number:");
                string accountNumber = Console.ReadLine();

                if (string.IsNullOrEmpty(accountNumber))
                {
                    throw new ArgumentNullException("Account number cannot be null or empty.");
                }

                Console.WriteLine("Enter the amount to withdraw:");
                string amountInput = Console.ReadLine();
                if (!decimal.TryParse(amountInput, out decimal withdrawalAmount))
                {
                    throw new FormatException("Invalid amount format. Please enter a numeric value.");
                }

                if (withdrawalAmount <= 0)
                {
                    throw new ArgumentOutOfRangeException("Amount must be greater than zero.");
                }

                // Simulate a withdrawal process
                Console.WriteLine($"Processing withdrawal of {withdrawalAmount:C} from account {accountNumber}...");

                // Assume something goes wrong in the banking system
                throw new InvalidOperationException("Transaction failed due to a system error.");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Thank you for using our banking system. Have a great day!");
            }
        }

        public void CustomException()
        {
            try
            {
                // Step 3: Simulate user input
                Console.WriteLine("Enter your age:");
                int userAge = int.Parse(Console.ReadLine());

                // Step 4: Call the validation method
                ValidateAge(userAge);
            }
            catch (AgeValidationException ex)
            {
                // Handle custom exception
                Console.WriteLine($"Validation Error: {ex.Message}");
            }
            catch (FormatException ex)
            {
                // Handle input format exceptions
                Console.WriteLine("Invalid input. Please enter a numeric value for age.");
            }
            catch (Exception ex)
            {
                // Handle any other general exceptions
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Age validation completed.");
            }
        }

        // Step 1: Define a custom exception class
        public class AgeValidationException : Exception
        {
            public AgeValidationException(string message) : base(message) { }
        }

        // Step 2: Create a method to validate age
        public static void ValidateAge(int age)
        {
            if (age < 18)
            {
                throw new AgeValidationException("Age must be 18 or older.");
            }
            Console.WriteLine("Age validation passed.");
        }


    }

}
