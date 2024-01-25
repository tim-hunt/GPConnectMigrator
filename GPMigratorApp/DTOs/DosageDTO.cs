namespace GPMigratorApp.DTOs;

public class DosageDTO
{
    private Guid Id { get; set; }
    public int? Sequence { get; set; }
    public string? Text { get; set; }
    public string? AdditionalInstruction { get; set; }
    public string? PatientInstruction { get; set; }
    public TimingDTO? Timing  { get; set; }
    public bool? AsNeeded { get; set; }
    public string? AsNeededCode { get; set; }
    public string? Site { get; set; }
    public string? Route { get; set; }
    public string? Method { get; set; }
    public int? DoseRangeHigh { get; set; }
    public int? DoseRangeLow { get; set; }
    public int? Quantity { get; set; }
    public decimal? MaxDosePerPeriod { get; set; }
    public int? MaxDosePerAdministration { get; set; }
    public int? MaxDosePerLifetime { get; set; }
    public decimal? RateRatioNumerator { get; set; }
    public decimal? RateRatioDenominator { get; set; }
    public int? RateRangeLow { get; set; }
    public int? RateRangeHigh { get; set; }
    public int? RateQuantity { get; set; }
}