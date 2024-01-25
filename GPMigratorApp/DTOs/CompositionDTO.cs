namespace GPMigratorApp.DTOs;

public class CompositionDTO
{
    public string Guid { get; set; }
    public IdentifierDTO? Identifier { get; set; }
    public IdentifierDTO? CrossCareSettingIdentifier { get; set; }
    public string? Status { get; set; }
    public string? Type { get; set; }
    public string? Class { get; set; }
    public PatientDTO? Subject { get; set; }
    public EncounterDTO? Encounter { get; set; }
    public PracticionerDTO? Author { get; set; }
    public string? Observation { get; set; }
    public string? Problem { get; set; }
    public string? Title { get; set; }
    public string? Code { get; set; }
    public string? OrderedByCode { get; set; }
    public string? CareSettingType { get; set; }
}