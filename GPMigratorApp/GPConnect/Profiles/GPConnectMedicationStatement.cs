using GPConnect.Provider.AcceptanceTests.Http;
using GPMigratorApp.DTOs;
using GPMigratorApp.GPConnect.Helpers;
using Hl7.Fhir.Model;

namespace GPMigratorApp.GPConnect.Profiles;

public class GPConnectMedicationStatement : MedicationStatement
{
    private List<Practitioner>? _practicioners;
    private IEnumerable<GPConnectMedicationRequest>? _medicationRequests;
    private IEnumerable<GPConnectMedication>? _medications;
    
    public GPConnectMedicationStatement(MedicationStatement medicationStatement, FhirResponse bundle)
    {
        InitInhertedProperties(medicationStatement);
        _practicioners = bundle.Practitioners;
        _medicationRequests = bundle.MedicationRequests;
        _medications = bundle.Medications;
    }

    public MedicationStatementDTO GetDTO()
    {
        var dto = new MedicationStatementDTO
        {
            Guid = Id,
            Status = Status.ToString(),
            PrescribingAgencyCode = PrescribingAgency?.Code,
            PrescribingAgencyDisplay = PrescribingAgency.Display,
            LastIssueDateUTC = LastIssueDate,
            DateAssertedUTC = DateTime.Parse(DateAsserted),
            DosageLastChanged = DosageLastChanged,
            MedicationRequest = MedicationRequest.GetDTO(),
            CrossCareIdentifier = CrossCareIdentifier,
            Medication = ReferencedMedication.GetDTO(),
            EffectivePeriodStart = DateTime.Parse(EffectivePeriod.Start),
            EffectivePeriodEnd = DateTime.Parse(EffectivePeriod.End),
            PatientGuid = ReferenceHelper.GetId(this.Subject.Reference),
            Taken = Taken.ToString(),
            DosageText = DosageInstructions.Text,
            DosagePatientInstruction = DosageInstructions.PatientInstruction
        };
        return dto;
    }

    public GPConnectMedicationRequest? MedicationRequest
    {
        get
        {
            var medication = this.Medication.FirstOrDefault(x => x.Key == "url");
            var reference = BasedOn.FirstOrDefault()?.Reference;
            return _medicationRequests?.FirstOrDefault(x => x.Id == ReferenceHelper.GetId(reference));
        }
    }

    public GPConnectMedication? ReferencedMedication
    {
        get
        {
            var reference = Medication.FirstOrDefault().Value?.ToString();
            var medication = _medications?.FirstOrDefault(x => x.Id == ReferenceHelper.GetId(reference));
            return medication;

        }
    }
    
    public string? CrossCareIdentifier
    {
        get
        {
            var identifier =
                Identifier.FirstOrDefault(x => x.System == "https://fhir.nhs.uk/Id/cross-care-setting-identifier");

            if (identifier is not null)
            {
                return identifier.Value;
            }

            return null;
        }
    }

    public string? Patient
    {
        get { return ReferenceHelper.GetId(this.Subject.Reference); }
    }
    
    public Coding? PrescribingAgency
    {
        get
        {
            var prescribingAgency = Extension.FirstOrDefault(x => x.Url == "https://fhir.nhs.uk/STU3/StructureDefinition/Extension-CareConnect-GPC-PrescribingAgency-1");
            
           
            if (prescribingAgency is not null)
            {
                var value = (CodeableConcept)prescribingAgency.Value;
                return value.Coding.FirstOrDefault();
            }
            return null;
        }
    }
    
    public DateTime? DosageLastChanged
    {
        get
        {
            var lastChangedDate = Extension.FirstOrDefault(x => x.Url == "https://fhir.hl7.org.uk/STU3/StructureDefinition/Extension-CareConnect-MedicationStatementDosageLastChanged-1");
            if (lastChangedDate is not null)
            {
                return DateTime.Parse(lastChangedDate?.Value.ToString());
            }
            return null;
        }
    }

    public DateTime? LastIssueDate
    {
        get
        {
            var lastIssueDate = Extension.FirstOrDefault(x => x.Url == "https://fhir.nhs.uk/STU3/StructureDefinition/Extension-CareConnect-GPC-MedicationStatementLastIssueDate-1");
            if (lastIssueDate is not null)
            {
                return DateTime.Parse(lastIssueDate?.Value.ToString());
            }
            return null;
        }
    }

    public Period? EffectivePeriod => (Period)Effective;


    public Dosage? DosageInstructions => Dosage.FirstOrDefault();


    private void InitInhertedProperties (object medicationStatement)
    {
        foreach (var propertyInfo in medicationStatement.GetType().GetProperties())
        {
            var props = typeof(MedicationStatement).GetProperties().Where(p => !p.GetIndexParameters().Any());
            foreach (var prop in props)
            {
                if (prop.CanWrite)
                    prop.SetValue(this, prop.GetValue(medicationStatement));
            }
        }
    }
}