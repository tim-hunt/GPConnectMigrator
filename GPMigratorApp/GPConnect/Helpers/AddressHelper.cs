using Hl7.Fhir.Model;
using Hl7.Fhir.ElementModel;

namespace GPMigratorApp.GPConnect.Helpers
{
    public static class AddressHelper
    {
        public static string GenerateDisplayText(Address address)
        {
            List<string> displayTextLines = new List<string>();

            if (address.Line.Any())
            {
                foreach (var line in address.Line)
                {
                    displayTextLines.Add(line);
                }
            }

            if (!string.IsNullOrWhiteSpace(address.City))
            {
                displayTextLines.Add(address.City);
            }

            if (!string.IsNullOrWhiteSpace(address.District))
            {
                displayTextLines.Add(address.District);
            }

            if (!string.IsNullOrWhiteSpace(address.PostalCode))
            {
                displayTextLines.Add(address.PostalCode);
            }

            return string.Join(", ", displayTextLines);
        }

        public static Address? FindHomeAddress(Patient fhirPatient)
        {
            if (!fhirPatient.Address.Any())
            {
                return null;
            }

            List<Address> homeAddresses = fhirPatient.Address
                .Where(fhirAddress => fhirAddress.Use == null || fhirAddress.Use == Address.AddressUse.Home)
                .ToList();

            if (!homeAddresses.Any())
            {
                return null;
            }

            homeAddresses.Sort(CompareAddresses);

            return homeAddresses.Last();
        }
        
        public static IEnumerable<Address?>? OtherAddresses(Patient fhirPatient)
        {
            if (!fhirPatient.Address.Any())
            {
                return null;
            }

            var homeAddresses = fhirPatient.Address.Where(x => !x.Matches(FindHomeAddress(fhirPatient)));

            return homeAddresses;
        }

        private static int CompareAddresses(Address addr1, Address addr2)
        {
            // Ones without end dates are always later than ones with end dates
            var end1 = addr1.End();

            var end2 = addr2.End();


            if (!end1.HasValue && !end2.HasValue)
            {
                // If neither has an end, then let the below sorting by start date apply
            }
            else if (end1.HasValue && !end2.HasValue)
            {
                // If 1 is ended but 2 is not, then 1 goes before 2 (null end counts as later)
                return -1;
            }
            else if (!end1.HasValue && end2.HasValue)
            {
                // If 1 is not ended but 2 is, then 2 goes before 1
                return 1;
            }
            else
            {
                // If both are ended, then sort by end date
                if (end1 != null && end2 != null)
                {
                    var comp = DateTime.Compare(end1.Value, end2.Value);
                    if (comp != 0)
                    {
                        return comp;
                    }
                }
            }

            var start1 = addr1.Start();
 
            var start2 = addr2.Start();

            if (!start1.HasValue && !start2.HasValue)
            {
                // If neither has a start date, then we can't sort any more
                return 0;
            }
            else if (start1.HasValue && !start2.HasValue)
            {
                // If 1 has a date and 2 doesn't, then place 2 first (null start counts as earlier)
                return 1;
            }
            else if (!start1.HasValue && start2.HasValue)
            {
                // If 1 doesn't have a start, but 2 does, then place 1 first
                return -1;
            }
            else
            {
                // If both have starts, then it's a straight date comparison
                return DateTime.Compare(start1.Value, start2.Value);
            }
        }

        public static bool HasStart(this Address address)
        {
            return address.Period?.StartElement != null;
        }
        
        public static bool HasEnd(this Address address)
        {
            return address.Period?.EndElement != null;
        }
        
        public static DateTime? Start(this Address? address)
        {
            var success = DateTime.TryParse(address.Period?.StartElement.Value, out var result);
            if (success)
                return result;
            
            return null;
        }
        
        public static DateTime? End(this Address? address)
        {
            var success = DateTime.TryParse(address.Period?.EndElement.Value, out var result);
            if (success)
                return result;
            
            return null;
        }

        public static string? FindCity(Patient fhirPatient)
        {
            var address = FindHomeAddress(fhirPatient);
            return address?.City;
        }

        public static string? FindDistrict(Patient fhirPatient)
        {
            var address = FindHomeAddress(fhirPatient);
            return address?.District;
        }
        
        public static bool HasUse(Address toCheck, Address.AddressUse use) {

            //when an address is ended it's use is changed to OLD, so compare use normally,
            //but also let the use pass if either one of them is OLD
            return toCheck.Use != null
                   && (toCheck.Use == use
                       || toCheck.Use == Address.AddressUse.Old
                       || use == Address.AddressUse.Old);
        }
    }
}