
using Microsoft.AspNetCore.Mvc;
using RedingtonTechv2._0.Models.Interfaces;
using RedingtonTechv2._0.Repositories.Interfaces;

namespace RedingtonTechv2._0.Repositories
{
    public class ProbabilityValidator : IProbabilityValidator
    {
        //validate object, then append to errorDictionary if some bad data is found
        public bool Validate(IProbabilityInput input, IProbabilityOutput output)
        {
            //check for null inputs
            if (input.A == null || input.B == null)
            {
                UpdateOutputWithError(output, "one of the inputs was null");
                return false;
            }

            //check for out of bounds
            if (input.A < 0 || input.A > 1)
            {
                UpdateOutputWithError(output, $"first value ({input.A}) was outside of range (0 <= x <= 1)");
                return false;
            }

            if (input.B < 0 || input.B > 1)
            {
                UpdateOutputWithError(output, $"second value ({input.B}) was outside of range (0 <= x <= 1)");
                return false;
            }

            return true;
        }

        private void UpdateOutputWithError(IProbabilityOutput output, string errorReason)
        {
            //do default error creation for output
            output.isValid = false;
            output.errorReason = errorReason;
        }
    }
}
