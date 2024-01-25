namespace GPMigratorApp.DTOs;

public class Appointment
{
    public Guid Id { get; set; }
    public string? AppointmentCancellationReason { get; set; }
    public OrganizationDTO BookingOrganization { get; set; }
    public string? PracticionerRole { get; set; }
    public string? DeliveryChannel { get; set; }
    public IdentifierDTO Identifier { get; set; }
    public string Status { get; set; }
    public string? ServiceCategory { get; set; }
    public string? ServiceType { get; set; }
    public string? Speciality { get; set; }
    public string? Reason { get; set; }
    public uint? Priority { get; set; }
    public string? Description { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public uint? MinutesDuration { get; set; }
    public SlotDTO Slot { get; set; }
    public DateTime? Created { get; set; }
    public string? Comment { get; set; }
    public List<ParticipantDTO> Participants { get; set; }
}