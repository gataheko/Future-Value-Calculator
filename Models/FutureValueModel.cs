// Author: Jakari Spann
// FutureValueModel.cs - Defines the data model and business logic for the Future Value Calculator

using System.ComponentModel.DataAnnotations;

namespace FutureValue.Models
{
    // This class represents the data model for the Future Value Calculator form
    public class FutureValueModel
    {
        // Required attribute ensures the field is not empty; Range restricts valid input to $1-$500/month
        [Required(ErrorMessage = "Please enter a monthly investment.")]
        [Range(1, 500, ErrorMessage =
               "Monthly investment amount must be between 1 and 500.")]
        public decimal? MonthlyInvestment { get; set; }

        // Yearly interest rate must be provided and fall within a realistic range of 0.1% to 10%
        [Required(ErrorMessage = "Please enter a yearly interest rate.")]
        [Range(0.1, 10.0, ErrorMessage =
               "Yearly interest rate must be between 0.1 and 10.0.")]
        public decimal? YearlyInterestRate { get; set; }

        // Number of years to invest must be between 1 and 50 to keep projections reasonable
        [Required(ErrorMessage = "Please enter a number of years.")]
        [Range(1, 50, ErrorMessage =
               "Number of years must be between 1 and 50.")]
        public int? Years { get; set; }

        // This method calculates the future value of monthly investments with compound interest
        public decimal? CalculateFutureValue()
        {
            // Convert years to months since investments are made on a monthly basis
            int? months = Years * 12;

            // Divide the yearly rate by 12 months and 100 to convert percentage to a decimal monthly rate
            decimal? monthlyInterestRate = YearlyInterestRate / 12 / 100;

            // Start with a future value of zero before any contributions are added
            decimal? futureValue = 0;

            // Loop once per month: add the monthly investment then apply compound interest for that month
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + MonthlyInvestment) *
                                (1 + monthlyInterestRate);
            }

            // Return the total accumulated value after all months of investment
            return futureValue;
        }
    }
}
