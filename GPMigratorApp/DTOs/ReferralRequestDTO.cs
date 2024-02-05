using Hl7.Fhir.Model;

namespace GPMigratorApp.DTOs;

public class ReferralRequestDTO
{
    public string Guid { get; set; }
    public IdentifierDTO? Identifier { get; set; }

    public ActivityDefinitionDTO? Definition { get; set; }
    public List<OutboundRelationship>? BasedOn { get; set; }
    public List<ReferralRequestDTO>? Replaces { get; set; }
    public string Status { get; set; }
    public string Intent { get; set; }
    public string? Type { get; set; }
    public string? Priority { get; set; }
    public string ServiceRequested { get; set; }
    public PatientDTO Subject { get; set; }
    public OutboundRelationship Context { get; set; }
    public DateTime? OccurrenceDate { get; set; }
    public DateTime? OccurrenceDateStart { get; set; }
    public DateTime? OccurrenceDateEnd { get; set; }
    public DateTime? AuthoredOn { get; set; }
    public OutboundRelationship? Requester { get; set; }
    public OrganizationDTO OnBehalfOf { get; set; }
    public OutboundRelationship Recipient { get; set; }
    public List<OutboundRelationship>? ReasonReference { get; set; }
    public string? Description { get; set; }
    public List<OutboundRelationship>? SupportingInfo { get; set; }
    public OutboundRelationship NoteAuthor { get; set; }
    public List<OutboundRelationship>? RelevantHistory { get; set; }
}