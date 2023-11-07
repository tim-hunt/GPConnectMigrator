namespace GPMigratorApp.DTOs;

public class EncounterDTO
{
    public string Guid { get; set; }
    public string Identifier { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }
    
    public string? PatientGuid { get; set; }
    
    public PracticionerDTO? Performer{ get; set; }

    public PracticionerDTO? Recorder { get; set; }
    public DateTime PeriodStart { get; set; }
    public DateTime PeriodEnd { get; set; }
    public decimal? DurationValue { get; set; }
    public string DurationUnit { get; set; }
    public string DurationCode { get; set; }
    
    
  
}