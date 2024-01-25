using Hl7.Fhir.Model;

namespace GPMigratorApp.DTOs;

public class PeriodDTO
{
    public PeriodDTO(Period period)
    {
        var success = DateTime.TryParse(period.Start, out var from);
            if (success)
                From = from;
        success = DateTime.TryParse(period.Start, out var to);
            if (success)
                To = to;
    }
    
    public DateTime? From{ get; set; }
    
    public DateTime? To{ get; set; }
}