using Hl7.Fhir.Model;

namespace GPMigratorApp.DTOs;

public class DiagnosticReportDTO
{
    public string Guid { get; set; }
    public IdentifierDTO? Identifier { get; set; }
    public string? Status { get; set; }
    public OrganizationDTO Assigner { get; set; }
    public ProcedureRequestDTO ProcedureRequest{ get; set; }
    public string? Category{ get; set; }
    public string? Code{ get; set; }
    public PatientDTO Subject { get; set; }
    public EncounterDTO? Encounter { get; set; }
    public DateTime? EffectiveFrom { get; set; }
    public DateTime? EffectiveTo { get; set; }
    public DateTime Issued { get; set; }
    public OutboundRelationship Performer{ get; set; }
    public SpecimenDTO Specimen { get; set; }
    public ObservationDTO Result { get; set; }
    public string? Conclusion { get; set; }
    public string? CodedDiagnosis { get; set; }
    public string? PresentedFrom { get; set; }
    
    
}