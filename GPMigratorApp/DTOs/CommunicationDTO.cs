using Hl7.Fhir.Model;

namespace GPMigratorApp.DTOs;

public class CommunicationDTO
{

    public CommunicationDTO()
    {
        
    }
    
    public string? Language { get; set; }
    public bool? PreferredLanguage { get; set; }
    public string? PreferredMethodOfCommunication{ get; set; }
    public string? CommunicationPreficiency{ get; set; }
    public bool? InterpreterRequired { get; set; }
}