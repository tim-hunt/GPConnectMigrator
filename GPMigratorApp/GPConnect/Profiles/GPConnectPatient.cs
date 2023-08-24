using System.Reflection;
using System.Runtime.Serialization;
using GPMigratorApp.GPConnect.Helpers;
using Hl7.Fhir.Introspection;
using Hl7.Fhir.Model;

namespace GPMigratorApp.GPConnect.Profiles;

[Serializable]
[DataContract]
[FhirType("Patient","http://hl7.org/fhir/StructureDefinition/Patient", IsResource=true)]
public class GPConnectPatient : Patient
{
    public GPConnectPatient(Patient patient)
    {
        InitInhertedProperties(patient);
        
        
    }
    public DateTime FirstRegistered
    {
        get
        {
            var registration = this.Extension.FirstOrDefault(x => x.Url == "https://fhir.nhs.uk/STU3/StructureDefinition/Extension-CareConnect-GPC-RegistrationDetails-1");
            var ext1 = registration?.Extension.FirstOrDefault(x => x.Url == "registrationPeriod");
            var registered = (Period) ext1?.Value;
            return DateTime.Parse(registered?.Start);
        }
    }

    public Identifier? NHSNumber
    {
        get
        {
            var nhsNumber = Identifier.FirstOrDefault(x => x.System == "https://fhir.nhs.uk/Id/nhs-number");
            return nhsNumber;
        }
    }
    
    public Coding? NHSNumberVerified
    {
        get
        {
            var verified = NHSNumber?.Extension.FirstOrDefault(x => x.Url == "https://fhir.nhs.uk/STU3/StructureDefinition/Extension-CareConnect-GPC-NHSNumberVerificationStatus-1");
            var value = (CodeableConcept) verified?.Value;
            return value?.Coding.FirstOrDefault();
          
        }
    }

    public Address? HomeAddress => AddressHelper.FindHomeAddress(this);
    
    public IEnumerable<Address>? OtherAddresses => AddressHelper.OtherAddresses(this);


    private void InitInhertedProperties (object patient)
    {
        foreach (var propertyInfo in patient.GetType().GetProperties())
        {
            var props = typeof(Patient).GetProperties().Where(p => !p.GetIndexParameters().Any());
            foreach (var prop in props)
            {
                if (prop.CanWrite)
                    prop.SetValue(this, prop.GetValue(patient));
            }
        }
    }
}