using System.Reflection;
using System.Runtime.Serialization;
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
            var extension1 = this.Extension.FirstOrDefault(x => x.Url == "https://fhir.nhs.uk/STU3/StructureDefinition/Extension-CareConnect-GPC-RegistrationDetails-1");
            var extension2 = (IEnumerable<Extension>) @extension1?.FirstOrDefault(x => x.Key == "extension").Value!;
            var value1 = @extension2.FirstOrDefault()?.Value;
            var value2 = (FhirDateTime)@value1?.FirstOrDefault(x => x.Key == "start").Value!;
            var value3 = @value2?.Value;
            return DateTime.Parse(@value3!);
        }
    }
    
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