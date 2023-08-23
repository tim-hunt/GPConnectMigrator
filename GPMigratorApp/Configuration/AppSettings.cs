namespace FutureNHS.Api.Configuration
{
    public sealed class AppSettings
    {
        public bool TraceAllScenarios { get; set; }
        public string TraceBaseDirectory { get; set; }
        public bool TraceOutputJSONResponse { get; set; }
        public bool TraceOutputJWT { get; set; }
        public bool TraceOutputJSONRequestBody { get; set; }
        public bool TraceOutputConsoleLog { get; set; }
        public  string ConsumerASID { get; set; }
        public  string ProviderASID { get; set; }
        public  string JwtAudValueFoundationsAndAppmts { get; set; }
        public  string JwtAudValueStructured { get; set; }

        // Data Settings
        public string DataDirectory { get; set; }

        // FHIR Settings
        public string GPConnectSpecVersion { get; set; }
        public string FhirDirectory { get; set; }
        public string FhirWebDirectory { get; set; }
        public bool FhirCheckWeb { get; set; }
        public bool FhirCheckDisk { get; set; }
        public bool FhirCheckWebFirst { get; set; }

        // Security Settings
        public bool UseTLSFoundationsAndAppmts { get; set; }
        public bool UseTLSStructured { get; set; }

        // Server Settings
        public string ServerUrlFoundationsAndAppmts { get; set; }
        public string ServerHttpsPortFoundationsAndAppmts { get; set; }
        public string ServerHttpPortFoundationsAndAppmts { get; set; }
        public string ServerBaseFoundationsAndAppmts { get; set; }

        public string ServerUrlStructured { get; set; }
        public string ServerHttpsPortStructured { get; set; }
        public string ServerHttpPortStructured { get; set; }
        public string ServerBaseStructured { get; set; }

        // Web Proxy Settings
        public bool UseWebProxy { get; set; }
        public string WebProxyUrl { get; set; }
        public string WebProxyPort { get; set; }

        // Spine Proxy Settings
        public bool UseSpineProxy { get; set; }
        public string SpineProxyUrl { get; set; }
        public string SpineProxyPort { get; set; }

        // Certificate Settings
        public bool SendClientCert { get; set; }
        public bool ValidateServerCert { get; set; }

        //Certificates to imitate the Consumer calling the SSP
        public string ThumbprintConsumerValid { get; set; }
        public string ThumbprintConsumerInvalidFqdn { get; set; }
        public string ThumbprintConsumerInvalidAuthority { get; set; }
        public string ThumbprintConsumerInvalidRevoked { get; set; }
        public string ThumbprintConsumerInvalidExpired { get; set; }

        //Certificates to imitate the SSP calling the Provider
        public string ThumbprintSspValid { get; set; }

        public string ThumbprintSspInvalidExpired { get; set; }

        public string ThumbprintSspInvalidFqdn { get; set; }

        public string ThumbprintSspInvalidAuthority { get; set; }

        public string ThumbprintSspInvalidRevoked { get; set; }

        public string CurlClientCertificate { get; set; }
        public string CurlClientKey { get; set; }
        public string CurlClientPassword { get; set; }

        public bool TeardownEnabled { get; set; }

        public bool RandomPatientEnabled { get; set; }
    }
}
