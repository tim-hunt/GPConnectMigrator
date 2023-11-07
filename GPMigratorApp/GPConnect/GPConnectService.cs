using System.Net;
using System.Net.Http.Headers;
using System.Text;
using FutureNHS.Api.Configuration;
using GPConnect.Provider.AcceptanceTests.Constants;
using GPConnect.Provider.AcceptanceTests.Helpers;
using GPConnect.Provider.AcceptanceTests.Http;
using GPMigratorApp.GPConnect.Profiles;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace GPMigratorApp.GPConnect;

public class GPConnectService : IGPConnectService
{
    private readonly IJwtHelper _jwtHelper;

    public GPConnectService(IJwtHelper jwtHelper)
    {
        _jwtHelper = jwtHelper;
    }

    public async Task<FhirResponse> GetLocalFile()
    {
        var path = Directory.GetCurrentDirectory();
        string text = await File.ReadAllTextAsync(path + "\\example_json\\Shoshana_Daniels.json");
        var jsonParser = new FhirJsonParser();
        var fhirResponse = new FhirResponse();
        
        fhirResponse.Resource = jsonParser.Parse<Resource>(text);
        return fhirResponse;
    }

    public async Task<FhirResponse> SendRequestAsync(HttpMethod method, string requestUrl, string traceId,
        string sspFrom, string sspTo, JsonContent? json = null)
    {
        // // REMOVES SSL - FOR DEVELOPMENT ONLY
        var httpClientHandler = new HttpClientHandler();
        // httpClientHandler.ServerCertificateCustomValidationCallback = (
        //     message,
        //     cert,
        //     chain,
        //     sslPolicyErrors) =>
        // {
        //     return true;
        // };
        var baseUrl = "https://orange.testlab.nhs.uk/B82617/STU3/1/gpconnect/structured/fhir";
        var absoluteUrl = new Uri(baseUrl + requestUrl);

        _jwtHelper.SetDefaultValues();
        _jwtHelper.AuthTokenURL = absoluteUrl.AbsoluteUri;

        var jwt = _jwtHelper.GetBearerToken();

        //var serializer = new FhirJsonSerializer();
        using (var client = new HttpClient(httpClientHandler))
        {
            using var httpRequestMessage = new HttpRequestMessage(method, absoluteUrl)
            {
                Headers =
                {
                    {HttpConst.Headers.kAuthorization, jwt},
                    {HttpConst.Headers.kSspTraceId, traceId},
                    {HttpConst.Headers.kSspFrom, sspFrom},
                    {HttpConst.Headers.kSspTo, sspTo},
                    {HttpConst.Headers.kAccept, ContentType.Application.FhirJson},
                    {
                        HttpConst.Headers.kSspInteractionId,
                        "urn:nhs:names:services:gpconnect:fhir:operation:gpc.getstructuredrecord-1"
                    },
                },
                Content = json,

            };

            httpRequestMessage.Content.Headers.ContentType =
                new MediaTypeHeaderValue(ContentType.Application.FhirJson);

            var response = await client.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead);

            if (response.IsSuccessStatusCode)
            {
                var jsonParser = new FhirJsonParser();
                var fhirResponse = new FhirResponse();

                var stream = await response.Content.ReadAsStreamAsync();

                using var reader = new StreamReader(stream, Encoding.UTF8);

                //string text = await File.ReadAllTextAsync("C:\\Users\\Tim\\source\\repos\\GPMigratorApp\\GPMigratorApp\\example.json");

                var fhirstring = await reader.ReadToEndAsync();
                fhirResponse.Resource = jsonParser.Parse<Resource>(fhirstring);
                return fhirResponse;
            }

            var message = response.StatusCode switch
            {
                HttpStatusCode.BadRequest => "Patient not found",
                
                HttpStatusCode.NotFound => "Patient not found",
                _ => "Unknown error occured"
            };

            throw new BadHttpRequestException(message, (int) response.StatusCode);
        }
    }
}