using GPConnect.Provider.AcceptanceTests.Http;
using Hl7.Fhir.Model;

namespace GPMigratorApp.GPConnect;

public interface IGPConnectService
{
    Task<FhirResponse> GetLocalFile();
    Task<FhirResponse> SendRequestAsync(HttpMethod method, string requestUrl, string traceId, string sspFrom, string sspTo,
        JsonContent? json = null);
}