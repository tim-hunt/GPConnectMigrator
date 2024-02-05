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
[FhirType("Encounter","http://hl7.org/fhir/StructureDefinition/Encounter", IsResource=true)]
public class GPConnectEncounter
{
    private Encounter _encounter;
    private EpisodeOfCare? _episodeOfCare;
    private IEnumerable<PracticionerDTO>? _practicioners;
    private IEnumerable<PatientDTO>? _patients;
    public GPConnectEncounter(Encounter encounter, FhirResponse bundle)
    {
        _encounter = encounter;
        _episodeOfCare = bundle.EpisodesOfCare?.FirstOrDefault(x => x.Id == encounter.EpisodeOfCare?.FirstOrDefault()?.Reference);
        _practicioners = bundle.Practitioners;
    }

    public EncounterDTO GetDTO()
    {
        var dto = new EncounterDTO
        {
            Guid = _encounter.Id,
            Identifier = DataIdentifier,
            Status = _encounter.Status.ToString(),
            Type = TypeText,
            Subject = Patient(),
            Performer = PrimaryPerformer(),
            Recorder = Recorder(),
            PeriodStart = DateTime.Parse(_encounter.Period.Start),
            PeriodEnd = DateTime.Parse(_encounter.Period.End),
            DurationValue = _encounter.Length.Value,
            DurationUnit = _encounter.Length.Unit,
            DurationCode = _encounter.Length.Code
        };
        return dto;
    }

    public EpisodeOfCare? GetEpisodeOfCare => _episodeOfCare;
    
    public PatientDTO? Patient()
    {
        var patientId = ReferenceHelper.GetId(_encounter.Subject.Reference);
        var patient = _patients.FirstOrDefault(x => x.PatientId == patientId);
        return patient;
    }
    public PracticionerDTO? PrimaryPerformer()
    {
        var reference = _encounter.Participant
            .FirstOrDefault(x => x.Type.Any(y => y.Coding.Any(z => z.Code == "PPRF")))
            ?.Individual
            .Reference;
        return _practicioners?.FirstOrDefault(x => x.Reference == ReferenceHelper.GetId(reference));
    }

    public String? DataIdentifier
    {
        get
        {
            var identifier = _encounter.Identifier.FirstOrDefault(x => x.System == "https://provider.nhs.uk/data-identifier");
            if (identifier is not null)
            {
                return identifier.Value;
            }
            return null;
        }
    }

    public String? TypeText
    {
        get
        {
            return _encounter.Type.FirstOrDefault().Text;
        }
    }
    
    public PracticionerDTO? Recorder()
    {
        var reference = _encounter.Participant
            .FirstOrDefault(x => x.Type.Any(y => y.Coding.Any(z => z.Code == "REC")))
            ?.Individual
            .Reference;
        
        return _practicioners?.FirstOrDefault(x => x.Reference == ReferenceHelper.GetId(reference));
    }
    
}