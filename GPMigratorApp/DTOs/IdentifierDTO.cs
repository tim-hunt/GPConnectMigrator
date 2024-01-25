using GPMigratorApp.DTOs;
using Hl7.Fhir.Model;

public class IdentifierDTO
{
    public IdentifierDTO(Identifier? identifier)
    {
        MapFromIdentifier(identifier);
    }
    
    private void MapFromIdentifier(Identifier? identifier)
    {
        if (identifier is not null)
        {
            Use = identifier.Use?.ToString();
            Type = identifier.Type.Text;
            System = identifier.System;
            Value = identifier.Value;
            Period = new PeriodDTO(identifier.Period);
            Assigner = identifier.Assigner.Reference;
        }
    }
    
    public string? Use { get; set; }
    public string? Type { get; set; }
    public string? System { get; set; }
    public string? Value { get; set; }
    public PeriodDTO? Period { get; set; }
    public string? Assigner { get; set; }
}