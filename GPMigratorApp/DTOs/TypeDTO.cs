using Hl7.Fhir.Model;

namespace GPMigratorApp.DTOs;

public class TypeDTO
{
    public TypeDTO(CodeableConcept? type)
    {
        if (type is not null)
        {
            var code = type.Coding.FirstOrDefault();
            Code = code?.Code;
            Display = code?.Display;
            System = code?.System;
            Version = code?.Version;
            UserSelected = code?.UserSelected;
        }
    }
    
    public string? Code { get; set; }
    public string? Display { get; set; }
    public string? System { get; set; }
    public string? Version { get; set; }
    public bool? UserSelected { get; set; }

}