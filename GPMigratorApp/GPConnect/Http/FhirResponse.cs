using GPMigratorApp.GPConnect.Profiles;
using Hl7.Fhir.Introspection;
using Hl7.Fhir.Serialization;


namespace GPConnect.Provider.AcceptanceTests.Http
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Hl7.Fhir.Model;
    using Hl7.Fhir.Support;
    public class FhirResponse
    {
        public Resource Resource { get; set; }

        public List<Bundle.EntryComponent> Entries => ((Bundle)Resource).Entry;

        public IEnumerable<GPConnectPatient> Patients => GetResources<Patient>(ResourceType.Patient).Select(x=> new GPConnectPatient(x));
        public List<Organization> Organizations => GetResources<Organization>(ResourceType.Organization);
        public List<Composition> Compositions => GetResources<Composition>(ResourceType.Composition);
        public List<Device> Devices => GetResources<Device>(ResourceType.Device);
        public List<Practitioner> Practitioners => GetResources<Practitioner>(ResourceType.Practitioner);
        public List<Location> Locations => GetResources<Location>(ResourceType.Location);
        public Bundle Bundle => (Bundle)Resource;
        public List<Slot> Slots => GetResources<Slot>(ResourceType.Slot);
        public List<Appointment> Appointments => GetResources<Appointment>(ResourceType.Appointment);
        public List<Schedule> Schedules => GetResources<Schedule>(ResourceType.Schedule);
        public List<CapabilityStatement> CapabilityStatements => GetResources<CapabilityStatement>(ResourceType.CapabilityStatement);
        public List<AllergyIntolerance> AllergyIntolerances => GetResources<AllergyIntolerance>(ResourceType.AllergyIntolerance);
        public List<Medication> Medications => GetResources<Medication>(ResourceType.Medication);
        public List<MedicationStatement> MedicationStatements => GetResources<MedicationStatement>(ResourceType.MedicationStatement);
        public List<MedicationRequest> MedicationRequests => GetResources<MedicationRequest>(ResourceType.MedicationRequest);
        public List<DocumentReference> Documents => GetResources<DocumentReference>(ResourceType.DocumentReference);
        public List<EpisodeOfCare> EpisodesOfCare => GetResources<EpisodeOfCare>(ResourceType.EpisodeOfCare);
        public IEnumerable<GPConnectEncounter> Encounters => GetResources<Encounter>(ResourceType.Encounter).Select(x=> new GPConnectEncounter(x, this));

        public List<List> Lists => GetResources<List>(ResourceType.List);

        private List<T> GetResources<T>(ResourceType resourceType) where T : Resource
        {
            //Need to consider cases where T isn't in ResourceTypeMap (and implementation!!)
            var type = typeof(T);

           
            return Entries
                .Where(entry => entry.Resource.TypeName == resourceType.ToString())
                .Select(entry => (T)entry.Resource)
                .ToList();

        }

        private static Dictionary<Type, ResourceType> ResourceTypeMap => new Dictionary<Type, ResourceType>
        {
            {typeof(Patient), ResourceType.Patient},
            {typeof(Organization), ResourceType.Organization},
            {typeof(Composition), ResourceType.Composition},
            {typeof(Device), ResourceType.Device},
            {typeof(Practitioner), ResourceType.Practitioner},
            {typeof(Location), ResourceType.Location},
            {typeof(Slot), ResourceType.Slot},
            {typeof(Appointment), ResourceType.Appointment},
            {typeof(Schedule), ResourceType.Schedule},
            {typeof(CapabilityStatement), ResourceType.CapabilityStatement},
            {typeof(AllergyIntolerance), ResourceType.AllergyIntolerance},
            {typeof(List), ResourceType.List},
            {typeof(Medication), ResourceType.Medication},
            {typeof(MedicationStatement), ResourceType.MedicationStatement},
            {typeof(MedicationRequest), ResourceType.MedicationRequest}
        };
    }
}
