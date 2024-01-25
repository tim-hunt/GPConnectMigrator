using Hl7.Fhir.Model;

namespace GPMigratorApp.DTOs;

public class ProcedureRequestDTO
{
    public string Guid { get; set; }
    public IdentifierDTO? Identifier { get; set; }
    public string? Status { get; set; }
    public OrganizationDTO? Assigner { get; set; }
    public OrganizationDTO? RequisitionAssigner { get; set; }
    public string? Category{ get; set; }
    public string? Code{ get; set; }
    public PatientDTO? Subject { get; set; }
    public EpisodeOfCareDTO? ConextEpisodeOfCare { get; set; }
    public EncounterDTO? ConextEncounter { get; set; }
    public EncounterDTO? Encounter { get; set; }
    public OrganizationDTO? RequestingOrganization { get; set; }
    public PracticionerDTO? RequestingPracticioner { get; set; }
    public OrganizationDTO? OnBehalfOf { get; set; }
    public OrganizationDTO? PerformerOrganization { get; set; }
    public PracticionerDTO? PerformerPracticioner { get; set; }
    public string? Reason { get; set; }
    public ConditionDTO? ReasonReferenceCondition { get; set; }
    public ObservationDTO? ReasonReferenceObservation { get; set; }
    public ObservationDTO? SupportingInfo { get; set; }
    public SpecimenDTO? Specimen { get; set; }
    public string? BodySite { get; set; }
    public string? NoteText { get; set; }
    public DateTime? NoteAuthored { get; set; }
    public PatientDTO? NoteAuthorPatient{ get; set; }
    public PracticionerDTO? NoteAuthorPracticioner { get; set; }

}