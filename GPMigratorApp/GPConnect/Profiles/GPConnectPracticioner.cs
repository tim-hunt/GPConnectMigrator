using System.Reflection;
using System.Runtime.Serialization;
using DotNetGPSystem;
using GPConnect.Provider.AcceptanceTests.Http;
using GPMigratorApp.DTOs;
using GPMigratorApp.GPConnect.Helpers;
using Hl7.Fhir.Introspection;
using Hl7.Fhir.Model;

namespace GPMigratorApp.GPConnect.Profiles;

[Serializable]
[DataContract]
[FhirType("Organization","http://hl7.org/fhir/StructureDefinition/Organization", IsResource=true)]
public class GPConnectPracticioner : Practitioner
{

    private IEnumerable<OrganizationDTO> _organisations;
    
    public GPConnectPracticioner(Practitioner practitioner, IEnumerable<OrganizationDTO> organisations)
    {
        InitInhertedProperties(practitioner);
    }

    public PracticionerDTO GetDTO()
    {
        var gotDob = DateTime.TryParse(this.BirthDate, out DateTime date);
       
        var dto = new PracticionerDTO
        {
            Reference = this.Id,
            SdsUserId = this.Identifier.FirstOrDefault(x => x.System == "https://fhir.nhs.uk/Id/sds-user-id")?.Value,
            SdsRoleProfileId = this.Identifier.FirstOrDefault(x => x.System == "https://fhir.nhs.uk/Id/sds-role-profile-id")?.Value,
            Sex = Gender?.ToString(),
            Title = Name[0].Prefix.FirstOrDefault(),
            GivenName = Name[0].GivenElement.First().Value,
            MiddleNames = Name[0].GivenElement.Skip(1).Select(x => x.Value),
            Surname = Name[0].Family,
            Address = new AddressDTO(this.Address.FirstOrDefault()),
        };
        
        if (gotDob)
        {
            dto.DateOfBirthUtc = date;
        }
        
        foreach (var qualification in Qualification)
        {
            var identifier = qualification.Identifier.FirstOrDefault();
            if (identifier is not null)
            {
                var qualificationDto = new QualificationDTO
                {
                    Use = identifier.Use,
                    Type = identifier.Type.Coding.FirstOrDefault()?.Code,
                    System = identifier.System,
                    Value = identifier.Value,
                    Assigner = _organisations.FirstOrDefault(x => x.ODSCode == this.Identifier.FirstOrDefault()?.Assigner.FirstOrDefault().Value.ToString()) ?? null,
                    Issuer = _organisations.FirstOrDefault(x => x.ODSCode == qualification.Issuer.FirstOrDefault().Value)
                };
                dto.Qualifications?.Add(qualificationDto);
            }
        }

        return dto;
    }
    
    public string? ODSCode()
    {
        return this.Identifier.FirstOrDefault()?.Value;
    }
    
    private void InitInhertedProperties (object encounter)
    {
        foreach (var propertyInfo in encounter.GetType().GetProperties())
        {
            var props = typeof(Practitioner).GetProperties().Where(p => !p.GetIndexParameters().Any());
            foreach (var prop in props)
            {
                if (prop.CanWrite)
                    prop.SetValue(this, prop.GetValue(encounter));
            }
        }
    }
}