using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    /// <summary>
    /// Manages a single customer. 
    /// </summary>
    public class Customer
    {
        public int CustomerId { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       

        public decimal CalculatePercentOfGoalSteps(string goalSteps, string actualSteps)
        {
            // Try 3

            // FailFast clauses
            if(string.IsNullOrWhiteSpace(goalSteps)) throw new ArgumentException("Goal must be entered", nameof(goalSteps));
            if(string.IsNullOrWhiteSpace(actualSteps)) throw new ArgumentException("Actual steps count must be entered", nameof(goalSteps));

            if(!decimal.TryParse(goalSteps, out var goalStepCount)) throw new ArgumentException("Goal must be numeric", nameof(goalSteps));
            if(!decimal.TryParse(actualSteps, out var actualStepCount)) throw new ArgumentException("Actual steps must be numeric", nameof(actualStepCount));

            return CalculatePercentOfGoalSteps(goalStepCount, actualStepCount);
        }

        public decimal CalculatePercentOfGoalSteps(decimal goalStepCount, decimal actualStepCount)
        {
            if (goalStepCount <= 0) throw new ArgumentException("Goal must be greater than 0", nameof(goalStepCount));
            return Math.Round((actualStepCount / goalStepCount)*100,2);
        }

        public void ValidateEmail()
        {
            // -- Send an email receipt --
            // If the user requested a receipt
            // Get the customer data
            // Ensure a valid email address was provided.
            // If not, 
            // request an email address from the user. 
        }
    }
}
