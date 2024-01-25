using Hl7.Fhir.Model;

namespace GPMigratorApp.DTOs;

public class EncounterDTO
{
    public string Guid { get; set; }
    public string? EncounterTransport { get; set; }
    public string? OutcomeOfAttendance { get; set; }
    public string? EmergencyCareDischargeStatus { get; set; }
    public IdentifierDTO? Identifier { get; set; }
    public string? Status { get; set; }
    public string? StatusHistory{ get; set; }
    public DateTime? StatusHistoryPeriodStart { get; set; }
    public DateTime? StatusHistoryPeriodEnd { get; set; }
    
    public string? Class{ get; set; }
    
    public string? ClassHistory{ get; set; }
    public DateTime? ClassHistoryPeriodStart { get; set; }
    public DateTime? ClassHistoryPeriodEnd { get; set; }
    public string? Type { get; set; }
    public string? Priority { get; set; }
    
    public PatientDTO Subject { get; set; }
    public EpisodeOfCareDTO EpisodeOfCare { get; set; }
    public ReferralRequest
    public PracticionerDTO? Performer{ get; set; }

    public PracticionerDTO? Recorder { get; set; }
    public DateTime PeriodStart { get; set; }
    public DateTime PeriodEnd { get; set; }
    public decimal? DurationValue { get; set; }
    public string DurationUnit { get; set; }
    public string DurationCode { get; set; }
    
    
  
}