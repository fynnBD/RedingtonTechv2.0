using ReadingtonTech.Models.Interfaces;
using ReadingtonTech.Repositories.Interfaces;

namespace ReadingtonTech.Repositories
{
    public class ProbabilityValidator : IProbabilityValidator
    {
        public bool Validate(IProbabilityInput input, IProbabilityOutput output)
        {
            if (input.A == null || input.B == null)
            {
                UpdateOutputWithError(output, "one of the inputs was null");
                return false;
            }

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
            output.isValid = false;
            output.errorReason = errorReason;
        }
    }
}
