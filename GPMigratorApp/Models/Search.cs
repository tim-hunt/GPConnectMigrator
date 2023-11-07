using GPConnect.Provider.AcceptanceTests.Http;
using Hl7.Fhir.Model;

namespace GPMigratorApp.Models;

public class Search
{
    public string NhsNumber { get; set; }
    
    public StructuredRecordRequest? Request { get; set; }

    public FhirResponse? Response { get; set; }
    
    public long TimeTaken { get; set; }
}