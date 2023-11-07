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
    public string? PatientGuid { get; set; }
    
    public string? Taken { get; set; }
    public string? DosageText { get; set; }
    public string? DosagePatientInstruction { get; set; }
}