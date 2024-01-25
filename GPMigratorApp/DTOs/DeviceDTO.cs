namespace GPMigratorApp.DTOs;

public class DeviceDTO
{
    public IdentifierDTO Identifier { get; set; }
    public TypeDTO Type { get; set; }
    public string manufacturer { get; set; }
    public string Model { get; set; }
    public string Version { get; set; }
    public OrganizationDTO Owner { get; set; }
    public string locations { get; set; }
    public string Name { get; set; }
    public string? Telecom { get; set; }
    
    public AddressDTO? Address { get; set; }
    public OrganizationDTO? PartOf {get; set; }
    public ContactDTO? Contact {get; set; }
    
    
    
  
}