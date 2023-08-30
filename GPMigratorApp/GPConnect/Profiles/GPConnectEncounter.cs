using System.Reflection;
using System.Runtime.Serialization;
using DotNetGPSystem;
using GPConnect.Provider.AcceptanceTests.Http;
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