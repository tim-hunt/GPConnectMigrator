using Hl7.Fhir.Model;

namespace GPMigratorApp.DTOs;

public class ClinicalImpressionDTO
{
    public string Guid { get; set; }
    public IdentifierDTO? Identifier { get; set; }
    public string? Status { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public PatientDTO? Subject { get; set; }
    public EncounterDTO? ConextEncounter { get; set; }
    public EpisodeOfCareDTO? ContextEpisodeOfCare { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? EffectivePeriodStart { get; set; }
    public DateTime? EffectivePeriodEnd { get; set; }
    public DateTime? Date { get; set; }
    public PracticionerDTO? Asserssor { get; set; }
    public ClinicalImpressionDTO? Previous { get; set; }
    public ConditionDTO? ProblemCondition { get; set; }
    public AllergyIntolleranceDTO? ProblemAllergy { get; set; }
    public string? InvestigationCode { get; set; }
    public DiagnosticReportDTO? InvestigationReport { get; set; }
    public ObservationDTO? InvestigationObservation { get; set; }
    public string? Protocol { get; set; }
    public string? Summary { get; set; }
    public string? FindingCode { get; set; }
    public ConditionDTO FindingCondition { get; set; }
    public ObservationDTO FindingObservation { get; set; }
    public string? FindingBasis { get; set; }
    public string? Prognosis { get; set; }
    
    public string? Note { get; set; }
}