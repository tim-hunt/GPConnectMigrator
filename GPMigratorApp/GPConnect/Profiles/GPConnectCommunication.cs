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
[FhirType("Communication", "http://hl7.org/fhir/StructureDefinition/Communication", IsResource = true)]
public class GPConnectCommunication
{
    private readonly List<CommunicationDTO>? _communications;

    public GPConnectCommunication(List<Extension> extensions)
    {
        if (extensions.All(x => x.Url != "https://fhir.nhs.uk/STU3/StructureDefinition/Extension-CareConnect-GPC-NHSCommunication-1"))
            return;
        
        _communications = new List<CommunicationDTO>();
        foreach (var communication in extensions.Where(x =>
                     x.Url ==
                     "https://fhir.nhs.uk/STU3/StructureDefinition/Extension-CareConnect-GPC-NHSCommunication-1"))
        {
            var dto = new CommunicationDTO();
            var languageValue = communication?.Extension?
                .FirstOrDefault(x => x.Url == "language")?.Value as CodeableConcept;
            dto.Language = languageValue?.Text;

            var proficiencyValue = communication?.Extension
                ?.FirstOrDefault(x => x.Url == "communicationProficiency")?.Value as CodeableConcept;
            dto.CommunicationPreficiency = proficiencyValue?.Text;

                
            var modeOfCommunicationValue = communication?.Extension
                ?.FirstOrDefault(x => x.Url == "modeOfCommunication")?.Value as CodeableConcept;
            dto.PreferredMethodOfCommunication = modeOfCommunicationValue?.Text;
                
            var interpreterValue = communication?.Extension?
                .FirstOrDefault(x => x.Url == "interpreterRequired")?.Value;
            if (interpreterValue is not null)
            {
                dto.InterpreterRequired = (bool) interpreterValue.FirstOrDefault().Value;
            }
                
            var preferredLanguageValue = communication?.Extension?
                .FirstOrDefault(x => x.Url == "preferred")?.Value;
            if (preferredLanguageValue is not null)
            {
                dto.PreferredLanguage = (bool) preferredLanguageValue.FirstOrDefault().Value;
            }

            _communications?.Add(dto);
        }
    }

    public List<CommunicationDTO>? GetDTO()
    {
        return _communications;
    }
}