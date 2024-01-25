using Hl7.Fhir.Model;

namespace GPMigratorApp.DTOs;

public class EpisodeOfCareDTO
{
    public string Guid { get; set; }
    public IdentifierDTO? Identifier { get; set; }
    public string? Status { get; set; }
    public string? Type { get; set; }
    public ConditionDTO DiagnosisCondition { get; set; }
    public string? DiagnosisRole { get; set; }
    public int? DiagnosisRank { get; set; }
    public PatientDTO? Subject { get; set; }
    public OrganizationDTO? ManagingOrganization { get; set; }
    public DateTime? PeriodStart { get; set; }
    public DateTime? PeriodEnd { get; set; }
    public ReferralRequest? ReferralRequest { get; set; }
    public PracticionerDTO? CareManager { get; set; }
    public List<PracticionerDTO>? CareTeam { get; set; }
    public string? Account { get; set; }
}