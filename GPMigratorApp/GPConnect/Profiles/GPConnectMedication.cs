using GPConnect.Provider.AcceptanceTests.Http;
using GPMigratorApp.DTOs;
using Hl7.Fhir.Model;

namespace GPMigratorApp.GPConnect.Profiles;

public class GPConnectMedication : Medication
{
    public GPConnectMedication(Medication medication, FhirResponse bundle)
    {
        InitInhertedProperties(medication);
       
    }

    public MedicationDTO GetDTO()
    {
        var dto = new MedicationDTO();
        if (SnomedCoding is not null)
        {
            dto.SnomedDisplayName = SnomedCoding.Display;
            dto.SnomedCode = SnomedCoding.Code;
        }
        if (MultilexCoding is not null)
        {
            dto.MultilexDisplayName = MultilexCoding.Display;
            dto.MultilexCode = MultilexCoding.Code;
            dto.MultilexUserSelected = MultilexCoding.UserSelected;
        }
        return dto;
    }


    public Coding? SnomedCoding
    {
        get
        {
            var coding = Code.Coding.FirstOrDefault(x => x.System == "http://snomed.info/sct");
            if (coding is not null)
            {
                return coding;
            }
            return null;
        }
    }
    
    public Coding? MultilexCoding
    {
        get
        {
            var coding = Code.Coding.FirstOrDefault(x => x.System == "https://fhir.hl7.org.uk/Id/multilex-drug-codes");
            if (coding is not null)
            {
                return coding;
            }
            return null;
        }
    }
    
    private void InitInhertedProperties (object medication)
    {
        foreach (var propertyInfo in medication.GetType().GetProperties())
        {
            var props = typeof(Encounter).GetProperties().Where(p => !p.GetIndexParameters().Any());
            foreach (var prop in props)
            {
                if (prop.CanWrite)
                    prop.SetValue(this, prop.GetValue(medication));
            }
        }
    }
}