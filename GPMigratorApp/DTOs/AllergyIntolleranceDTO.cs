using Hl7.Fhir.Model;

namespace GPMigratorApp.DTOs;

public class AllergyIntolleranceDTO
{
    public string Guid { get; set; }
    public IdentifierDTO? Identifier { get; set; }
    public string? ReasonEnded  { get; set; }
    public DateTime? OnsetDate { get; set; }
    public decimal? OnsetAge { get; set; }
    public DateTime? OnsetPeriodStart { get; set; }
    public DateTime? OnsetPeriodEnd { get; set; }
    public DateTime? AllergyEndDate { get; set; }
    public string? ClinicalStatus { get; set; }
    public string? VerificationStatus { get; set; }
    public string? Criticality { get; set; }
    public string? Code { get; set; }
    public string? Type { get; set; }
    public string? Category { get; set; }
    public PatientDTO? Subject { get; set; }
    public DateTime? AssertedDate { get; set; }
    public PracticionerDTO? AsserterPracticioner { get; set; }
    public PatientDTO? AsserterPatient { get; set; }
    public PracticionerDTO? RecorderPracticioner { get; set; }
    public PatientDTO? ecorderPatient { get; set; }
    public DateTime? LastOccurance { get; set; }
    public DateTime? NoteAuthored { get; set; }
    public PatientDTO? NoteAuthorPatient{ get; set; }
    public PracticionerDTO? NoteAuthorPracticioner { get; set; }
    public string? ReactionSubstance { get; set; }
    public string? ReactionManifestation { get; set; }
    public string? ReactionDescription { get; set; }
    public string? ReactionExposureRate { get; set; }
}