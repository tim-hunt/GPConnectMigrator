namespace GPMigratorApp.DTOs;

public class ObservationDTO
{
    private string? Guid { get; set; }
    public IdentifierDTO? Identifier { get; set; }
    public OutboundRelationship BasedOn { get; set; }
    public string? Status { get; set; }
    public string? Category { get; set; }
    public string? Code { get; set; }
    public PatientDTO Subject { get; set; }
    public EncounterDTO Context { get; set; }
    public DateTime EffectiveDate { get; set; }
    public PeriodDTO EffectivePeriod { get; set; }
    public DateTime Issued { get; set; }
    public OutboundRelationship Performer { get; set; }
}