using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FutureNHS.Api.Configuration;
using GPConnect.Provider.AcceptanceTests.Constants;
using GPConnect.Provider.AcceptanceTests.Logger;
using Hl7.Fhir.Serialization;
using Microsoft.IdentityModel.Tokens;

// ReSharper disable ClassNeverInstantiated.Global

namespace GPConnect.Provider.AcceptanceTests.Helpers
{
    public interface IJwtHelper
    {
        DateTime? CreationTime { get; set; }
        DateTime? ExpiryTime { get; set; }
        string ReasonForRequest { get; set; }
        string AuthTokenURL { get; set; }
        string AuthTokenURLFoundationsAndAppmts { get; set; }
        string AuthTokenURLStructured { get; set; }
        string RequestingDevice { get; set; }
        string RequestingOrganization { get; set; }
        string RequestingIdentity { get; set; }
        string RequestingIdentityId { get; set; }
        string RequestedScope { get; set; }
        string RequestedPatientNHSNumber { get; set; }
        string RequestedOrganizationODSCode { get; set; }
        string RequestedOrganizationId { get; set; }
        string RequestingSystemUrl { get; set; }
        void SetDefaultValues();
        string GetBearerTokenWithoutEncoding();
        string GetBearerToken();
        void SetExpiryTimeInSeconds(double seconds);
        void SetCreationTimeSeconds(double seconds);
        void SetExpiryTimeInSecondsPast(double seconds);
        void SetCreationTimeSecondsPast(double seconds);
        void SetRequestingPractitioner(string practitionerId, string practitionerJson);
    }

    public class JwtHelper : IJwtHelper
    {
        private readonly AppSettings _appsettings;
        public JwtHelper(AppSettings appsettings)
        {
            AuthTokenURLFoundationsAndAppmts = appsettings.JwtAudValueFoundationsAndAppmts;
            AuthTokenURLStructured = appsettings.JwtAudValueStructured;
            _appsettings = appsettings;
        }
        private const string Bearer = "Bearer ";
        private const int MaxExpiryTimeInMinutes = 5;

        public DateTime? CreationTime { get; set; }
        public DateTime? ExpiryTime { get; set; }
        public string ReasonForRequest { get; set; }
        public string AuthTokenURL { get; set; }
        public string AuthTokenURLFoundationsAndAppmts { get; set; }
        public string AuthTokenURLStructured { get; set; }
        public string RequestingDevice { get; set; }
        public string RequestingOrganization { get; set; }
        public string RequestingIdentity { get; set; }
        public string RequestingIdentityId { get; set; }
        public string RequestedScope { get; set; }
        public string RequestedPatientNHSNumber { get; set; }
        public string RequestedOrganizationODSCode { get; set; }
        public string RequestedOrganizationId { get; set; }
        public string RequestingSystemUrl { get; set; }

        public JwtHelper()
        {
            Log.WriteLine("JwtHelper() Constructor");
            SetDefaultValues();
        }

        public void SetDefaultValues()
        {
            var serializer = new FhirJsonSerializer();
            
            CreationTime = DateTime.UtcNow;
            ExpiryTime = CreationTime.Value.AddMinutes(MaxExpiryTimeInMinutes);
            SetCreationTimeSecondsPast(2);
            SetExpiryTimeInSecondsPast(2);
            ReasonForRequest = JwtConst.Values.kDirectCare;
            AuthTokenURL = _appsettings.JwtAudValueStructured;
            RequestingDevice = serializer.SerializeToString(FhirHelper.GetDefaultDevice());
            RequestingOrganization = serializer.SerializeToString(FhirHelper.GetDefaultOrganization());
            RequestingIdentityId = FhirHelper.GetDefaultPractitioner().Id;
            RequestingIdentity = serializer.SerializeToString(FhirHelper.GetDefaultPractitioner());
            RequestedScope = JwtConst.Scope.kPatientRead;
            // TODO Check We're Using The Correct Scope For Metadata vs. GetCareRecord
            RequestedPatientNHSNumber = null;
            // TODO Move Dummy Data Out Into App.Config Or Somewhere Else
         

            RequestingSystemUrl = "https://ConsumerSystemURL";
        }

        private static string BuildEncodedHeader()
        {
            return "eyJhbGciOiJub25lIiwidHlwIjoiSldUIn0";
        }

        private string BuildEncodedPayload()
        {
            return BuildPayload().Base64UrlEncode();
        }

        private JwtPayload BuildPayload()
        {
            var claims = new List<Claim>();

            if (RequestingSystemUrl != null)
                claims.Add(new Claim(JwtConst.Claims.kRequestingSystemUrl, RequestingSystemUrl, ClaimValueTypes.String));
            if (RequestingIdentityId != null)
                claims.Add(new Claim(JwtConst.Claims.kPractitionerId, RequestingIdentityId, ClaimValueTypes.String));
            if (AuthTokenURL != null)
                claims.Add(new Claim(JwtConst.Claims.kAuthTokenURL, AuthTokenURL, ClaimValueTypes.String));
            if (ExpiryTime != null)
                claims.Add(new Claim(JwtConst.Claims.kExpiryTime, EpochTime.GetIntDate(ExpiryTime.Value).ToString(), ClaimValueTypes.Integer64));
            if (CreationTime != null)
                claims.Add(new Claim(JwtConst.Claims.kCreationTime, EpochTime.GetIntDate(CreationTime.Value).ToString(), ClaimValueTypes.Integer64));
            if (ReasonForRequest != null)
                claims.Add(new Claim(JwtConst.Claims.kReasonForRequest, ReasonForRequest, ClaimValueTypes.String));
            if (RequestingDevice != null)
                claims.Add(new Claim(JwtConst.Claims.kRequestingDevice, RequestingDevice, JsonClaimValueTypes.Json));
            if (RequestingOrganization != null)
                claims.Add(new Claim(JwtConst.Claims.kRequestingOrganization, RequestingOrganization, JsonClaimValueTypes.Json));
            if (RequestingIdentity != null)
                claims.Add(new Claim(JwtConst.Claims.kRequestingPractitioner, RequestingIdentity, JsonClaimValueTypes.Json));
            if (RequestedScope != null)
                claims.Add(new Claim(JwtConst.Claims.kRequestedScope, RequestedScope, ClaimValueTypes.String));
            
            return new JwtPayload(claims);
        }

        public string GetBearerTokenWithoutEncoding()
        {
            return Bearer + BuildBearerTokenOrgResourceWithoutEncoding();
        }

        private string BuildBearerTokenOrgResourceWithoutEncoding()
        {
            return new JwtHeader().SerializeToJson() + "." + BuildPayload().SerializeToJson() + ".";
        }

        public string GetBearerToken()
        {
            return Bearer + BuildBearerTokenOrgResource();
        }

        private string BuildBearerTokenOrgResource()
        {
            return BuildEncodedHeader() + "." + BuildEncodedPayload() + ".";
        }

        public void SetExpiryTimeInSeconds(double seconds)
        {
            Debug.Assert(CreationTime != null, "_jwtCreationTime != null");
            ExpiryTime = CreationTime.Value.AddSeconds(seconds);
        }

        public void SetCreationTimeSeconds(double seconds)
        {
            CreationTime = DateTime.UtcNow.AddSeconds(seconds);
            ExpiryTime = CreationTime.Value.AddMinutes(MaxExpiryTimeInMinutes);
        }

        public void SetExpiryTimeInSecondsPast(double seconds)
        {
            Debug.Assert(CreationTime != null, "_jwtCreationTime != null");
            ExpiryTime = CreationTime.Value.AddMinutes(MaxExpiryTimeInMinutes);
            ExpiryTime.Value.AddSeconds(-seconds);
        }

        public void SetCreationTimeSecondsPast(double seconds)
        {
            CreationTime = DateTime.UtcNow.AddSeconds(-seconds);
            ExpiryTime = CreationTime.Value.AddMinutes(MaxExpiryTimeInMinutes);
        }

        public void SetRequestingPractitioner(string practitionerId, string practitionerJson)
        {
            // TODO Make The RequestingPractitionerId Use The Business Identifier And Not The Logical Identifier 
            RequestingIdentityId = practitionerId;
            RequestingIdentity = practitionerJson;
        }
    }
}
