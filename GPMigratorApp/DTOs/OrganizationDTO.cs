namespace GPMigratorApp.DTOs;

public class OrganizationDTO
{
    public string ODSCode { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string? Telecom { get; set; }
    
    public AddressDTO? Address { get; set; }
    public OrganizationDTO? PartOf {get; set; }
    public ContactDTO? Contact {get; set; }
    
    
    
  
}