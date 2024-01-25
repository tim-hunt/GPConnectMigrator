namespace GPMigratorApp.DTOs;

public class SlotDTO
{
    public Guid Id { get; set; }
    public string? DeliveryChannel { get; set; }
    public IdentifierDTO Identifier { get; set; }
    public string? ServiceType { get; set; }
    public string? Speciality  { get; set; }
    public ScheduleDTO Schedule { get; set; }
    public string? Status { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public bool? Overbooked { get; set; }
    public string? Comment { get; set; }
}