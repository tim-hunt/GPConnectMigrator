using GPConnect.Provider.AcceptanceTests.Http;
using Hl7.Fhir.Model;

namespace GPMigratorApp.GPConnect.Profiles;

public class GpConnectAllergyIntolerance : AllergyIntolerance
{
    public GpConnectAllergyIntolerance(AllergyIntolerance allergy, FhirResponse bundle)
    {
        InitInhertedProperties(allergy);
    }
    
    
    private void InitInhertedProperties (object allergy)
    {
        foreach (var propertyInfo in allergy.GetType().GetProperties())
        {
            var props = typeof(AllergyIntolerance).GetProperties().Where(p => !p.GetIndexParameters().Any());
            foreach (var prop in props)
            {
                if (prop.CanWrite)
                    prop.SetValue(this, prop.GetValue(allergy));
            }
        }
    }
}