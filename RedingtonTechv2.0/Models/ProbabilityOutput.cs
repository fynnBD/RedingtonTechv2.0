using ReadingtonTech.Models.Interfaces;
using ReadingtonTech.Services;

namespace ReadingtonTech.Models;

public class ProbabilityOutput : IProbabilityOutput
{
    public decimal result { get; set ; }
    public bool isValid { get; set; }
    public string? errorReason { get; set; }
    public  decimal[] Values { get; set; }
    public CalculationType CalculationType { get; set; }

    public ProbabilityOutput()
    {
        this.isValid = true;
    }


}