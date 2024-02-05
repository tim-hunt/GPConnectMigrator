using System.Reflection;
using System.Runtime.Serialization;
using GPMigratorApp.DTOs;
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
        var dto = GetDTO();
    }

    public PatientDTO GetDTO()
    {
        var dto = new PatientDTO();
        dto.PatientId = this.Id;
        dto.OrganisationGuid = ReferenceHelper.GetId(this.ManagingOrganization.Reference);
        dto.UsualGpUserInRoleGuid = ReferenceHelper.GetId(GeneralPractitioner.FirstOrDefault().Reference);
        dto.Gender = Gender?.ToString();
        dto.Title = Name[0].Prefix.FirstOrDefault();
        dto.GivenName = Name[0].GivenElement.First().Value;
        dto.MiddleNames = Name[0].GivenElement.Skip(1).Select(x=> x.Value);
        dto.Surname = Name[0].Family;
        dto.DateOfBirthUTC = DateTime.Parse(this.BirthDate);
        var deceasedDate = (FhirDateTime?) this.Deceased;
        if (deceasedDate is not null)
        {
            dto.DateOfDeathUTC = DateTime.Parse(deceasedDate.Value);
        }
        dto.DateOfRegistrationUTC = FirstRegistered;
        dto.NhsNumber = NHSNumber?.Value;
        dto.NHSNumberStatus = NHSNumberVerified?.Code;
        dto.Ethnicity = Ethnicity?.Code;
        dto.Communication = new GPConnectCommunication(this.Extension).GetDTO();
        dto.Religion = Religion?.Code;
        dto.HomeAddress = new AddressDTO(HomeAddress);
        dto.OtherAddresses = OtherAddresses?.Select(x => new AddressDTO(x));
        dto.Active = Active;
        return dto;
    }
    
    public DateTime? FirstRegistered
    {
     
        
        get
        {
            var registration = this.Extension.FirstOrDefault(x => x.Url == "https://fhir.nhs.uk/STU3/StructureDefinition/Extension-CareConnect-GPC-RegistrationDetails-1");
            var ext1 = registration?.Extension.FirstOrDefault(x => x.Url == "registrationPeriod");
            var registered = (Period) ext1?.Value;
            if (registered is not null)
            {
                return DateTime.Parse(registered?.Start);
            }

            return null;
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
            var value = verified?.Value as CodeableConcept;
            return value?.Coding.FirstOrDefault();
        }
    }
    
    public Coding? Ethnicity
    {
        get
        {
            var ethnicity = Extension.FirstOrDefault(x => x.Url == "https://fhir.nhs.uk/STU3/CodeSystem/CareConnect-EthnicCategory-1");
            var value = ethnicity?.Value as CodeableConcept;
            return value?.Coding.FirstOrDefault();
        }
    }
    
    public Coding? Language
    {
        get
        {
            var communication = Extension.FirstOrDefault(x => x.Url == "https://fhir.nhs.uk/STU3/StructureDefinition/Extension-CareConnect-GPC-NHSCommunication-1");
            var value = communication?.Extension?.FirstOrDefault(x=> x.Url == "language")?.Value as CodeableConcept;
            return value?.Coding.FirstOrDefault();
        }
    }
    
    public Coding? PreferredMethodOfCommunication
    {
        get
        {
            var communication = Extension.FirstOrDefault(x => x.Url == "https://fhir.nhs.uk/STU3/StructureDefinition/Extension-CareConnect-GPC-NHSCommunication-1");
            var value = communication?.Extension?.FirstOrDefault(x=> x.Url == "modeOfCommunication")?.Value as CodeableConcept;
            return value?.Coding.FirstOrDefault();
        }
    }
    
    public Coding? CommunicationProficiency
    {
        get
        {
            var communication = Extension.FirstOrDefault(x => x.Url == "https://fhir.nhs.uk/STU3/StructureDefinition/Extension-CareConnect-GPC-NHSCommunication-1");
            var value = communication?.Extension?.FirstOrDefault(x=> x.Url == "communicationProficiency")?.Value as CodeableConcept;
            return value?.Coding.FirstOrDefault();
        }
    }
    
    public bool? InterpreterRequired
    {
        get
        {
            var communication = Extension.FirstOrDefault(x => x.Url == "https://fhir.nhs.uk/STU3/StructureDefinition/Extension-CareConnect-GPC-NHSCommunication-1");
            var value =  communication?.Extension?.FirstOrDefault(x=> x.Url == "interpreterRequired")?.Value;
            return (bool?) value?.FirstOrDefault().Value;
        }
    }
    
    // CANT TEST THIS BUT BEST GUESS FOR THE MOMENT
    public Coding? Religion
    {
        get
        {
            var religion = Extension.FirstOrDefault(x => x.Url == "https://fhir.nhs.uk/STU3/StructureDefinition/patient-religion");
            var child = religion?.FirstOrDefault(x=> x.Key == "valueCodeableConcept");
            var value = child?.Value as CodeableConcept;
            return value?.Coding.FirstOrDefault();
        }
    }
    

    public Address? HomeAddress => AddressHelper.FindHomeAddress(this);
    
    public IEnumerable<Address?>? OtherAddresses => AddressHelper.OtherAddresses(this);


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