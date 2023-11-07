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
public class GPConnectOrganization : Organization
{
    public GPConnectOrganization(Organization organization)
    {
        InitInhertedProperties(organization);
    }

    public OrganizationDTO GetDTO()
    {
        var dto = new OrganizationDTO
        {
            ODSCode = ODSCode(),
            Name = this.Name,
            Telecom = this.Telecom.FirstOrDefault()?.ValueElement.Value,
            Type = this.TypeName,
            Address = new AddressDTO(this.Address.FirstOrDefault()),
            Contact = new ContactDTO(this.Contact.FirstOrDefault())
        };
        if(this.PartOf is not null)
            dto.PartOf = new GPConnectOrganization((Organization) this.PartOf.FirstOrDefault().Value).GetDTO();
        
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
            var props = typeof(Organization).GetProperties().Where(p => !p.GetIndexParameters().Any());
            foreach (var prop in props)
            {
                if (prop.CanWrite)
                    prop.SetValue(this, prop.GetValue(encounter));
            }
        }
    }
}