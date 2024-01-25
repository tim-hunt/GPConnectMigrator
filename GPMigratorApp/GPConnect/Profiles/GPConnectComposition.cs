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
[FhirType("Encounter","http://hl7.org/fhir/StructureDefinition/Composition", IsResource=true)]
public class GPConnectComposition
{
    private Composition _composition;
    private IEnumerable<PatientDTO> _patients;
    private IEnumerable<EncounterDTO> _encounters;
    //private IEnumerable<ObservationDTO>
    private IEnumerable<PracticionerDTO>? _practicioners;
    public GPConnectComposition(Composition composition, FhirResponse bundle)
    {
        _composition = composition;
        _practicioners = bundle.Practitioners;
        _patients = bundle.Patients;
        _encounters = bundle.Encounters;
    }

    public CompositionDTO GetDTO()
    {
        var dto = new CompositionDTO
        {
            Guid = _composition.Id,
            Identifier = new IdentifierDTO((Identifier)_composition.Identifier.FirstOrDefault(x=> x.Key == "identifier").Value),
            CrossCareSettingIdentifier = new IdentifierDTO((Identifier)_composition.Identifier.FirstOrDefault(x=> x.Key == "crossCareSettingIdentifier").Value),
            Status = _composition.Status.ToString(),
            Type = TypeText,
            Class = _composition.Class.Text,
            Subject = _patients.FirstOrDefault(x=> x.PatientGuid == ReferenceHelper.GetId(_composition.Subject.Reference)),
            Encounter = _encounters.FirstOrDefault(x=> x.Guid == ReferenceHelper.GetId(_composition.Encounter.Reference)),
            Author = _practicioners.FirstOrDefault(x=> x.Reference == ReferenceHelper.GetId(_composition.Author.FirstOrDefault()?.Reference ?? string.Empty)),
            Observation = null,
            Problem = null,
            Title = null,
            Code = null,
            OrderedByCode = null,
            CareSettingType = null,

        };
        return dto;
    }

    

    public String? TypeText
    {
        get
        {
            return _composition.Type.Text;
        }
    }
    
   
    
}