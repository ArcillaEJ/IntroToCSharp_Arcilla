/*
 * ITELEC2 Prelim Activity 01: Codac Logistics Delivery & Fuel Auditor
 * Name: EJ D. Arcilla
 * Description:
 * It is a C# program in a console, which monitors the monthly fuel costs of a delivery driver, weekly. 
 * verifies the amount of distance covered, computes fuel efficiency scores, 
 * and establishes whether the driver was operating within the weekly budgeted amount.
 *
 * Concepts Used:
 * - Data Types: string, double, decimal, bool
 * - Console Input/Output
 * - Input Validation using while loop
 * - 1D Array
 * - for loop
 * - if/else statements
 */

using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        // Enable UTF-8 output so Peso sign (₱) displays correctly
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Philippine Peso culture
        CultureInfo php = new CultureInfo("en-PH");

        // ==========================
        // TASK 1: DRIVER PROFILE
        // ==========================

        Console.Write("Enter Driver's Full Name: ");
        string? driverName = Console.ReadLine();

        // Using decimal for money to avoid floating point precision issues
        decimal weeklyBudget;
        while (true)
        {
            Console.Write("Enter Weekly Fuel Budget: ");
            if (decimal.TryParse(Console.ReadLine(), out weeklyBudget) && weeklyBudget > 0)
                break;

            Console.WriteLine("Invalid input! Please enter a valid positive number.");
        }

        // Using double for distance (can contain decimals)
        double totalDistance;
        while (true)
        {
            Console.Write("Enter Total Distance Traveled This Week (1.0 - 5000.0 km): ");
            if (double.TryParse(Console.ReadLine(), out totalDistance) &&
                totalDistance >= 1.0 && totalDistance <= 5000.0)
                break;

            Console.WriteLine("Invalid input! Distance must be between 1.0 and 5000.0 km.");
        }

        // ==========================
        // TASK 2: FUEL EXPENSE TRACKING
        // ==========================

        decimal[] fuelExpenses = new decimal[5];
        decimal totalFuelSpent = 0;

        for (int i = 0; i < fuelExpenses.Length; i++)
        {
            while (true)
            {
                Console.Write($"Enter fuel expense for Day {i + 1}: ");

                if (decimal.TryParse(Console.ReadLine(), out fuelExpenses[i]) && fuelExpenses[i] >= 0)
                {
                    totalFuelSpent += fuelExpenses[i];
                    break;
                }

                Console.WriteLine("Invalid input! Please enter a valid amount.");
            }
        }

        // ==========================
        // TASK 3: PERFORMANCE ANALYSIS
        // ==========================

        decimal averageDailyExpense = totalFuelSpent / fuelExpenses.Length;

        string efficiencyRating;
        double efficiency = 0;

        // Prevent division by zero
        if (totalFuelSpent > 0)
        {
            efficiency = totalDistance / (double)totalFuelSpent;

            if (efficiency > 15)
                efficiencyRating = "High Efficiency";
            else if (efficiency >= 10)
                efficiencyRating = "Standard Efficiency";
            else
                efficiencyRating = "Low Efficiency / Maintenance Required";
        }
        else
        {
            efficiencyRating = "No Fuel Data Available";
        }

        bool isUnderBudget = totalFuelSpent <= weeklyBudget;

        // ==========================
        // TASK 4: AUDIT REPORT
        // ==========================

        Console.WriteLine("\n===== CODAC LOGISTICS WEEKLY AUDIT REPORT =====");
        Console.WriteLine($"Driver Name: {driverName}");
        Console.WriteLine("\n--- Fuel Expense Breakdown ---");

        for (int i = 0; i < fuelExpenses.Length; i++)
        {
            Console.WriteLine($"Day {i + 1}: {fuelExpenses[i].ToString("C", php)}");
        }

        Console.WriteLine("\n--- Financial Summary ---");
        Console.WriteLine($"Total Fuel Spent: {totalFuelSpent.ToString("C", php)}");
        Console.WriteLine($"Average Daily Expense: {averageDailyExpense.ToString("C", php)}");
        Console.WriteLine($"Fuel Efficiency Rating: {efficiencyRating}");
        Console.WriteLine($"Stayed Under Budget: {isUnderBudget}");

        Console.WriteLine("\n===============================================");
    }
}
