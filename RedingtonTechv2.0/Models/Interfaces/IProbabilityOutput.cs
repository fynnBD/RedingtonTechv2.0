using Microsoft.AspNetCore.SignalR;
using ReadingtonTech.Services;

namespace ReadingtonTech.Models.Interfaces;

public interface IProbabilityOutput
{
    public decimal result { get; set; }

    public bool isValid { get; set; }
    public string? errorReason { get; set; }

    public decimal[] Values { get; }

    public CalculationType CalculationType { get; set; }
}