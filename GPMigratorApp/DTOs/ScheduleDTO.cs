namespace GPMigratorApp.DTOs;

public class ScheduleDTO
{
    public Guid Id { get; set; }
    public string? PracticionerRole { get; set; }
    public IdentifierDTO Identifier { get; set; }
    public string? ServiceCategory { get; set; }
    public string? Speciality  { get; set; }
    public List<ParticipantDTO> Actors { get; set; }
    public DateTime? PlanningHorizonStart { get; set; }
    public DateTime? PlanningHorizonEnd { get; set; }
    public string? Comment { get; set; }
}