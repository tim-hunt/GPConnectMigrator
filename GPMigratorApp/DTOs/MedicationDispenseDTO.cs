namespace GPMigratorApp.DTOs;

public class MedicationDispenseDTO
{
    public string ResourceId { get; set; }
    public string ResourceType { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }
    public string Category { get; set; }
    public MedicationDTO Medication { get; set; }
    public PatientDTO Subject { get; set; }
    public MedicationRequestDTO AuthorizingPrescription { get; set; }
    public OutboundRelationship Dispenser { get; set; }
    public string DispenseType { get; set; }
    
    public DateTime? WhenPrepared { get; set; }
    public DateTime? WhenHandedOver { get; set; }
    public LocationDTO? Destination { get; set; }
    public OutboundRelationship? Receiver { get; set; }
    public EncounterDTO? Encounter { get; set; }
    public decimal? Quantity { get; set; }
    public string? QantityUnit { get; set; }
    public decimal? DaysSupply { get; set; }
    public string? Note { get; set; }
    public string DosageInstruction { get; set; }
    public bool? MedicationSubstituted{ get; set; }
    public string? MedicationSubstitutedType { get; set; }
    public string? MedicationSubstitutedReason { get; set; }
    public PracticionerDTO? MedicationSubstitutedResponsibleParty { get; set; }
}