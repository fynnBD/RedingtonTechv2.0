using Microsoft.AspNetCore.SignalR;
using RedingtonTechv2._0.Services;

namespace RedingtonTechv2._0.Models.Interfaces;

public interface IProbabilityOutput
{
    public decimal result { get; set; }

    public bool isValid { get; set; }
    public string? errorReason { get; set; }

    public decimal[] Values { get; }

    public CalculationType CalculationType { get; set; }
}