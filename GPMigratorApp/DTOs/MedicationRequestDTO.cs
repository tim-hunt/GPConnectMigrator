namespace GPMigratorApp.DTOs;

public class MedicationRequestDTO
{
    public string Guid { get; set; }
    public int? NumberOfRepeatPrescriptionsAllowed { get; set; }
    public int? NumberOfRepeatPrescriptionsIssued { get; set; }
    public string? PrescriptionTypeCode { get; set; }
    public string? PrescriptionTypeDisplay { get; set; }
    public string? CrossCareIdentifier { get; set; }
    public string? GroupIdentifier { get; set; }
    public string? Status { get; set; }
    public string? Intent { get; set; }
    public MedicationDTO Medication { get; set; }
    public string? PatientGuid { get; set; }
    public DateTime? AuthoredOnUTC { get; set; }
    public PracticionerDTO? Recorder { get; set; }
    public string DosageInstructionText { get; set; }
    public string DosageInstructionPatientInstruction { get; set; }
    public MedicationDispenseRequest MedicationDispenseRequest { get; set; }
}

public class MedicationDispenseRequest
{
    public DateTime? ValidityPeriodStart { get; set; }
    public DateTime? ValidityPeriodEnd { get; set; }
    public string? Quantity { get; set; }
    public decimal? ExpectedSupplyDurationValue { get; set; }
    public string? ExpectedSupplyDurationUnit { get; set; }
    public string? ExpectedSupplyDurationCode{ get; set; }
    public string? PerformerGuid { get; set; }
}