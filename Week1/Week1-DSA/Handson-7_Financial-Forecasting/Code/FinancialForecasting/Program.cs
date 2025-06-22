using System;

namespace FinancialForecasting
{
    class Program
    {
        // Recursive method to calculate future value based on varying growth rates
        public static double PredictFutureValue(double initialValue, double[] yearlyRates, int year)
        {
            // Base case: if no years left, return the initial value
            if (year == 0)
                return initialValue;

            // Recursive call: apply previous year's growth
            return PredictFutureValue(initialValue, yearlyRates, year - 1) * (1 + yearlyRates[year - 1]);
        }

        static void Main(string[] args)
        {
            double initialAmount = 10000;

            // Varying annual growth rates for each year (e.g., 5%, 7%, 4%, 6%)
            double[] growthRates = { 0.05, 0.07, 0.04, 0.06 };

            int totalYears = growthRates.Length;

            double futureValue = PredictFutureValue(initialAmount, growthRates, totalYears);

            Console.WriteLine("Financial Forecast with Varying Growth Rates");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"Initial Amount: {initialAmount}");
            Console.WriteLine("Yearly Growth Rates: " + string.Join(", ", growthRates));
            Console.WriteLine($"Forecasted Value after {totalYears} years: {futureValue}");
        }
    }
}
