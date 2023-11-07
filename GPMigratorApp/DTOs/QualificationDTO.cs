using Hl7.Fhir.Model;

namespace GPMigratorApp.DTOs;

public class QualificationDTO
{

    public QualificationDTO()
    {
        
    }
    
    public Identifier.IdentifierUse? Use { get; set; }
    public string? Type { get; set; }
    public string? System{ get; set; }
    public string? Value{ get; set; }
    public DateTime? From{ get; set; }
    public DateTime? To{ get; set; }
    public OrganizationDTO? Assigner {get; set; }
    public OrganizationDTO? Issuer { get; set; }
}