using Hl7.Fhir.Model;

namespace GPMigratorApp.DTOs;

public class ParticipantDTO
{
    public Guid Id { get; set; }
    public string? Type { get; set; }
    public OutboundRelationship? Actor { get; set; }
    public string? Required { get; set; }
    public string? Status { get; set; }
}