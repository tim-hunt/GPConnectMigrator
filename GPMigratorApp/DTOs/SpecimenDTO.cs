using Hl7.Fhir.Model;

namespace GPMigratorApp.DTOs;

public class SpecimenDTO
{
    public string Guid { get; set; }
    public IdentifierDTO? Identifier { get; set; }
    public IdentifierDTO? AccessionIdentifier { get; set; }
    public string? Status { get; set; }
    public string? Type { get; set; }
    public PatientDTO? Subject { get; set; }
    public DateTime? ReceivedTime { get; set; }
    public SpecimenDTO? Parent { get; set; }
    public ProcedureRequest? Request { get; set; }
    public string? FastingValueCode { get; set; }
    public decimal? FastingDurationValue { get; set; }
    public PracticionerDTO? Collector { get; set; } 
    public DateTime? Collected { get; set; } 
    public int? CollectedQuantity { get; set; } 
    public string? CollectionMethod { get; set; } 
    public string? CollectionBodySite { get; set; } 
    public IdentifierDTO? ContainerIdentifier { get; set; }
    public int? SpecimenQuantity { get; set; }
    public int? ContainerCapacity { get; set; }
    public string? NoteText { get; set; }
    public DateTime? NoteAuthored { get; set; }
    public OutboundRelationship? NoteAuthor { get; set; }
}