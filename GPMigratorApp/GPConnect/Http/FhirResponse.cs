using GPMigratorApp.DTOs;
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

        public IEnumerable<PatientDTO> Patients => GetResources<Patient>(ResourceType.Patient).Select(x=> new GPConnectPatient(x).GetDTO());
        public List<Composition> Compositions => GetResources<Composition>(ResourceType.Composition);
        public List<Device> Devices => GetResources<Device>(ResourceType.Device);

        public List<Location> Locations => GetResources<Location>(ResourceType.Location);
        public Bundle Bundle => (Bundle)Resource;
        public List<Slot> Slots => GetResources<Slot>(ResourceType.Slot);
        public List<Appointment> Appointments => GetResources<Appointment>(ResourceType.Appointment);
        public List<Schedule> Schedules => GetResources<Schedule>(ResourceType.Schedule);
        public List<CapabilityStatement> CapabilityStatements => GetResources<CapabilityStatement>(ResourceType.CapabilityStatement);
        public IEnumerable<GpConnectAllergyIntolerance> AllergyIntolerances => GetResources<AllergyIntolerance>(ResourceType.AllergyIntolerance).Select(x => new GpConnectAllergyIntolerance(x, this));
        public IEnumerable<GPConnectMedication> Medications => GetResources<Medication>(ResourceType.Medication).Select(x => new GPConnectMedication(x, this));
        public IEnumerable<MedicationStatementDTO> MedicationStatements => GetResources<MedicationStatement>(ResourceType.MedicationStatement).Select(x => new GPConnectMedicationStatement(x, this).GetDTO());
        public IEnumerable<GPConnectMedicationRequest> MedicationRequests => GetResources<MedicationRequest>(ResourceType.MedicationRequest).Select(x => new GPConnectMedicationRequest(x, this));
        public List<DocumentReference> Documents => GetResources<DocumentReference>(ResourceType.DocumentReference);
        public List<EpisodeOfCare> EpisodesOfCare => GetResources<EpisodeOfCare>(ResourceType.EpisodeOfCare);
        public IEnumerable<EncounterDTO> Encounters => GetResources<Encounter>(ResourceType.Encounter).Select(x=> new GPConnectEncounter(x, this).GetDTO());
        public IEnumerable<OrganizationDTO> Organizations => GetResources<Organization>(ResourceType.Organization).Select(x=> new GPConnectOrganization(x).GetDTO());
        public List<List> Lists => GetResources<List>(ResourceType.List);
        public IEnumerable<PracticionerDTO> Practitioners => GetResources<Practitioner>(ResourceType.Practitioner).Select(x=> new GPConnectPracticioner(x,Organizations).GetDTO());

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
