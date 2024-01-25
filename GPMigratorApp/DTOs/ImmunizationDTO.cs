namespace GPMigratorApp.DTOs;

public class ImmunizationDTO
{
    public string Guid { get; set; }
    public IdentifierDTO? Identifier { get; set; }
    public string? Status { get; set; }
    public string? Type { get; set; }
    public string? Class { get; set; }
    public PatientDTO? Subject { get; set; }
    public EncounterDTO? Encounter { get; set; }
    public PracticionerDTO? Actor { get; set; }
    public LocationDTO Location { get; set; }
    public bool? ParentPresent { get; set; }
    public DateTime? RecordedDate { get; set; }
    public DateTime? Date { get; set; }
    public bool? PrimarySource { get; set; }
    public string? LotNumber { get; set; }
    public string? Site { get; set; }
    public string? Route { get; set; }
    public string? RouteText { get; set; }
    public PracticionerDTO? NoteAuthor { get; set; }
    public string? NoteText { get; set; }
    public DateTime? NoteDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public string? VaccinationProcedure { get; set; }
    public string? VaccinationCode { get; set; }
    public decimal? DoseQuantity { get; set; }
    public bool? ReactionReported { get; set; }
    public ObservationDTO? ReactionDetail { get; set; }
    public DateTime? ReactionDate { get; set; }
    public int? DoseSequence { get; set; }
    public string? Description { get; set; }
    public OrganizationDTO? Authority { get; set; }
    public string? Series { get; set; }
    public int? SeriesDoses { get; set; }
    public string? TargetDisease { get; set; }
    public string? DoseStatus { get; set; }
    public string? DoseStatusReason { get; set; }
}