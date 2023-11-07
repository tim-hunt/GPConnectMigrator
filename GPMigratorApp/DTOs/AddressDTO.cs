using GPMigratorApp.GPConnect.Helpers;
using Hl7.Fhir.Model;

namespace GPMigratorApp.DTOs;

public class AddressDTO
{

    public AddressDTO(Address? address)
    {
        if (address is not null)
        {
            Use = address.Use;
            NumberAndStreet = address?.Line.FirstOrDefault();
            Village = address?.Line.Skip(1).FirstOrDefault();
            Town = address?.Line.Skip(2).FirstOrDefault();
            County = address?.District;
            County = address?.City;
            Postcode = address?.PostalCode;
            From = address.Start();
            To = address.End();
        }
    }
    public Hl7.Fhir.Model.Address.AddressUse? Use{ get; set; }
    public string? HouseNameFlatNumber { get; set; }
    public string? NumberAndStreet { get; set; }
    public string? Village { get; set; }
    public string? Town { get; set; }
    public string? County { get; set; }
    public string? Postcode { get; set; }
    
    public DateTime? From{ get; set; }
    
    public DateTime? To{ get; set; }

}