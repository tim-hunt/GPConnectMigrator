namespace GPMigratorApp.DTOs;

public class LocationDTO
{
    public IdentifierDTO ODSSiteCode { get; set; }
    public string? Status { get; set; }
    public string? OperationalStatus { get; set; }
    public string? Name { get; set; }
    public string? Alias { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
    public string? Telecom { get; set; }
    public AddressDTO? Address { get; set; }
    public string PhysicalType { get; set; }
    public decimal Longitude { get; set; }
    public decimal Latitude { get; set; }
    public decimal Altitude { get; set; }
    public OrganizationDTO ManagingOrganization { get; set; }
    public LocationDTO PartOf { get; set; }
}