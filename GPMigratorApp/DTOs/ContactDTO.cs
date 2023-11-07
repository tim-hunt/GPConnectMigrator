using Hl7.Fhir.Model;

namespace GPMigratorApp.DTOs;

public class ContactDTO
{

    public ContactDTO(Organization.ContactComponent contact)
    {
        if (contact != null)
        {
            Title = contact.Name.Prefix.ToString();
            GivenName = contact.Name.GivenElement.FirstOrDefault().Value;
            MiddleNames = contact.Name.GivenElement.Skip(1).Select(x => x.Value);
            Surname = contact.Name.Family;
            Address = new AddressDTO(contact.Address);
        }

    }
    
    public string? Title { get; }
    public string GivenName { get;}
    public IEnumerable<string>? MiddleNames { get; }
    public string Surname { get; }
    public AddressDTO? Address{ get; }
}