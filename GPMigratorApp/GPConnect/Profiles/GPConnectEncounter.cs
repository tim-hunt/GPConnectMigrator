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
public class GPConnectEncounter : Encounter
{
    private EpisodeOfCare? _episodeOfCare;
    private List<Practitioner>? _practicioners;
    public GPConnectEncounter(Encounter encounter, FhirResponse bundle)
    {
        InitInhertedProperties(encounter);
        _episodeOfCare = bundle.EpisodesOfCare?.FirstOrDefault(x => x.Id == encounter.EpisodeOfCare?.FirstOrDefault()?.Reference);
        _practicioners = bundle.Practitioners;
    }

    public EncounterDTO GetDTO()
    {
        var dto = new EncounterDTO
        {
            Guid = Id,
            Identifier = DataIdentifier,
            Status = Status.ToString(),
            Type = TypeText,
            PatientGuid = Patient(),
            PerformerGuid = PrimaryPerformer().Id,
            RecorderGuid = Recorder().Id,
            PeriodStart = DateTime.Parse(Period.Start),
            PeriodEnd = DateTime.Parse(Period.End),
            DurationValue = Length.Value,
            DurationUnit = Length.Unit,
            DurationCode = Length.Code
        };
        return dto;
    }

    public EpisodeOfCare? GetEpisodeOfCare => _episodeOfCare;
    
    public string? Patient()
    {
        return ReferenceHelper.GetId(this.Subject.Reference);
    }
    public Practitioner? PrimaryPerformer()
    {
        var reference = Participant
            .FirstOrDefault(x => x.Type.Any(y => y.Coding.Any(z => z.Code == "PPRF")))
            ?.Individual
            .Reference;
        return _practicioners?.FirstOrDefault(x => x.Id == ReferenceHelper.GetId(reference));
    }

    public String? DataIdentifier
    {
        get
        {
            var identifier = Identifier.FirstOrDefault(x => x.System == "https://provider.nhs.uk/data-identifier");
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
            return Type.FirstOrDefault().Text;
        }
    }
    
    public Practitioner? Recorder()
    {
        var reference = Participant
            .FirstOrDefault(x => x.Type.Any(y => y.Coding.Any(z => z.Code == "REC")))
            ?.Individual
            .Reference;
        
        return _practicioners?.FirstOrDefault(x => x.Id == ReferenceHelper.GetId(reference));
    }
    
    private void InitInhertedProperties (object encounter)
    {
        foreach (var propertyInfo in encounter.GetType().GetProperties())
        {
            var props = typeof(Encounter).GetProperties().Where(p => !p.GetIndexParameters().Any());
            foreach (var prop in props)
            {
                if (prop.CanWrite)
                    prop.SetValue(this, prop.GetValue(encounter));
            }
        }
    }
}