/*
 * Prelim Activity 01: Codac Logistics Delivery & Fuel Auditor
 * Name: Justin Louise Neypes
 * Description:
 * This console-based program tracks a delivery driver's weekly fuel expenses,
 * validates distance input, calculates fuel efficiency, and determines
 * whether the driver stayed within budget.
 * 
 * Concepts Used:
 * - Data Types: string, int, double, decimal, bool
 * - Console Input/Output
 * - Input Validation using while loop
 * - 1D Array
 * - for loop
 * - if/else statements
 */

using System;

class Program
{
    static void Main()
    {
        // ==========================
        // TASK 1: DRIVER PROFILE
        // ==========================

        // string is used for text input (driver name)
        Console.Write("Enter Driver's Full Name: ");
        string driverName = Console.ReadLine();

        // decimal is used for money to avoid floating point precision errors
        Console.Write("Enter Weekly Fuel Budget: ");
        decimal weeklyBudget = Convert.ToDecimal(Console.ReadLine());

        // double is used for distance because it may contain decimal values
        double totalDistance = 0;

        // while loop ensures the user keeps entering data until valid
        while (true)
        {
            Console.Write("Enter Total Distance Traveled This Week (1.0 - 5000.0 km): ");
            totalDistance = Convert.ToDouble(Console.ReadLine());

            // Validate range
            if (totalDistance >= 1.0 && totalDistance <= 5000.0)
            {
                break; // Exit loop if valid
            }
            else
            {
                Console.WriteLine("Invalid input! Distance must be between 1.0 and 5000.0 km.");
            }
        }

        // ==========================
        // TASK 2: FUEL EXPENSE TRACKING
        // ==========================

        // 1D array to store 5 days of fuel expenses
        decimal[] fuelExpenses = new decimal[5];

        decimal totalFuelSpent = 0;

        // for loop is used because we know the number of days (5)
        for (int i = 0; i < fuelExpenses.Length; i++)
        {
            Console.Write($"Enter fuel expense for Day {i + 1}: ");
            fuelExpenses[i] = Convert.ToDecimal(Console.ReadLine());

            // accumulate total fuel spent
            totalFuelSpent += fuelExpenses[i];
        }

        // ==========================
        // TASK 3: PERFORMANCE ANALYSIS
        // ==========================

        // Calculate average daily expense
        decimal averageDailyExpense = totalFuelSpent / fuelExpenses.Length;

        // Calculate efficiency ratio (distance per fuel cost)
        double efficiency = totalDistance / (double)totalFuelSpent;

        string efficiencyRating;

        // if/else to determine efficiency rating
        if (efficiency > 15)
        {
            efficiencyRating = "High Efficiency";
        }
        else if (efficiency >= 10)
        {
            efficiencyRating = "Standard Efficiency";
        }
        else
        {
            efficiencyRating = "Low Efficiency / Maintenance Required";
        }

        // bool to check if driver stayed under budget
        bool isUnderBudget = totalFuelSpent <= weeklyBudget;

        // ==========================
        // TASK 4: AUDIT REPORT
        // ==========================

        Console.WriteLine("\n===== CODAC LOGISTICS WEEKLY AUDIT REPORT =====");
        Console.WriteLine($"Driver Name: {driverName}");
        Console.WriteLine("\n--- Fuel Expense Breakdown ---");

        for (int i = 0; i < fuelExpenses.Length; i++)
        {
            Console.WriteLine($"Day {i + 1}: {fuelExpenses[i]:C}");
        }

        Console.WriteLine("\n--- Financial Summary ---");
        Console.WriteLine($"Total Fuel Spent: {totalFuelSpent:C}");
        Console.WriteLine($"Average Daily Expense: {averageDailyExpense:C}");
        Console.WriteLine($"Fuel Efficiency Rating: {efficiencyRating}");
        Console.WriteLine($"Stayed Under Budget: {isUnderBudget}");

        Console.WriteLine("\n===============================================");
    }
}
