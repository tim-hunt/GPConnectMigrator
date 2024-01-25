namespace GPMigratorApp.DTOs;

public class MedicationStatementDTO
{
    public string Guid { get; set; }
    public string? Status { get; set; }
    public string? PrescribingAgencyCode{ get; set; }
    public string? PrescribingAgencyDisplay{ get; set; }

    public DateTime? LastIssueDateUTC { get; set; }
    public DateTime? DateAssertedUTC { get; set; }
    public DateTime? DosageLastChanged { get; set; }
    
    public MedicationRequestDTO MedicationRequest { get; set; }
    public string? CrossCareIdentifier { get; set; }
    public MedicationDTO Medication { get; set; }
    
    public DateTime? EffectivePeriodStart { get; set; }
    public DateTime? EffectivePeriodEnd { get; set; }
    public string? PatientId { get; set; }
    
    public string? Taken { get; set; }
    public string? DosageRoute { get; set; }
    public string? DosageMethod { get; set; }
    
    public decimal? DosageRangeLow { get; set; }
    
    public decimal? DosageRangeHigh { get; set; }
    
    public string? MaxDosePerPeriod { get; set; }
    
    public decimal? MaxDosePerAdministration { get; set; }
    
    public decimal? MaxDosePerLifeTime { get; set; }
    public string? DosageText { get; set; }
    public string? DosagePatientInstruction { get; set; }
    
    public string? DosageRateRatio { get; set; }
    public string? DosageRateRange { get; set; }
    public string? DosageRateQuantity { get; set; }
}