namespace GPMigratorApp.DTOs;

public class EncounterDTO
{
    public string Guid { get; set; }
    public string Identifier { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }
    
    public string? PatientGuid { get; set; }
    public string PerformerGuid { get; set; }
    public string PerformerCode { get; set; }
    public string PerformerDisplay { get; set; }
    public string RecorderGuid { get; set; }
    public string RecorderCode { get; set; }
    public string RecorderDisplay { get; set; }
    public DateTime PeriodStart { get; set; }
    public DateTime PeriodEnd { get; set; }
    public decimal? DurationValue { get; set; }
    public string DurationUnit { get; set; }
    public string DurationCode { get; set; }
    
    
  
}