using System.Runtime.Serialization;
using GPConnect.Provider.AcceptanceTests.Http;
using GPMigratorApp.DTOs;
using GPMigratorApp.GPConnect.Helpers;
using Hl7.Fhir.Introspection;
using Hl7.Fhir.Model;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GPMigratorApp.GPConnect.Profiles;

[Serializable]
[DataContract]
[FhirType("MedicationRequest", "http://hl7.org/fhir/StructureDefinition/MedicationRequest", IsResource = true)]
public class GPConnectMedicationRequest : MedicationRequest
{
    private List<Practitioner>? _practicioners;
    private IEnumerable<GPConnectMedication>? _medications;

    public GPConnectMedicationRequest(MedicationRequest medicationRequest, FhirResponse bundle)
    {
        InitInhertedProperties(medicationRequest);
        _practicioners = bundle.Practitioners;
        _medications = bundle.Medications;
    }

    public MedicationRequestDTO GetDTO()
    {
        var dto = new MedicationRequestDTO();
        dto.Guid = Id;
        dto.Medication = ReferencedMedication?.GetDTO();
        dto.NumberOfRepeatPrescriptionsAllowed = NumberOfRepeatPrescriptionsAllowed;
        dto.NumberOfRepeatPrescriptionsIssued = NumberOfRepeatPrescriptionsIssued;
        dto.PrescriptionTypeCode = PrescriptionType?.Code;
        dto.PrescriptionTypeDisplay = PrescriptionType?.Display;
        dto.CrossCareIdentifier = CrossCareIdentifier;
        dto.GroupIdentifier = GroupIdentifier.Value;
        dto.Status = Status.ToString();
        dto.Intent = Intent.ToString();
        dto.PatientGuid = Patient;
        dto.AuthoredOnUTC = DateTime.Parse(AuthoredOn);
        dto.RecorderGuid = ReferenceHelper.GetId(Recorder.Reference);

        var dosageInstruction = DosageInstruction.FirstOrDefault();
        if (dosageInstruction is not null)
        {
            dto.DosageInstructionText = dosageInstruction.Text;
            dto.DosageInstructionPatientInstruction = dosageInstruction.PatientInstruction;
        }
        dto.MedicationDispenseRequest = new MedicationDispenseRequest
        {
            ValidityPeriodStart = DateTime.Parse(DispenseRequest.ValidityPeriod.Start),
            ValidityPeriodEnd = DateTime.Parse(DispenseRequest.ValidityPeriod.End),
            Quantity = DispenseRequestQuantity,
            ExpectedSupplyDurationValue = DispenseRequest.ExpectedSupplyDuration.Value,
            ExpectedSupplyDurationUnit = DispenseRequest.ExpectedSupplyDuration.Unit,
            ExpectedSupplyDurationCode = DispenseRequest.ExpectedSupplyDuration.Code,
            PerformerGuid =  ReferenceHelper.GetId(DispenseRequest.Performer.Reference)
        };
        return dto;
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


    public Practitioner? GetRecorder
    {
        get { return _practicioners?.FirstOrDefault(x => x.Id == ReferenceHelper.GetId(Recorder.Reference)); }
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

    public string? DispenseRequestQuantity
    {
        get
        {
            var quantity = DispenseRequest.Quantity.Extension.FirstOrDefault(x =>
                x.Url ==
                "https://fhir.nhs.uk/STU3/StructureDefinition/Extension-CareConnect-GPC-MedicationQuantityText-1");

            if (quantity is not null)
            {
                return quantity.Value.ToString();
            }
            return null;
        }
    }
    
    public Coding? PrescriptionType
    {
        get
        {
            var prescriptionType = Extension.FirstOrDefault(x => x.Url == "https://fhir.nhs.uk/STU3/StructureDefinition/Extension-CareConnect-GPC-PrescriptionType-1");
            
           
            if (prescriptionType is not null)
            {
                var value = (CodeableConcept)prescriptionType.Value;
                return value.Coding.FirstOrDefault();
            }
            return null;
        }
    }

    public int? NumberOfRepeatPrescriptionsAllowed
    {
        get
        {
            var dispenseRequest = this.DispenseRequest;
            var repeatInformation = Extension.FirstOrDefault(x => x.Url == "https://fhir.nhs.uk/STU3/StructureDefinition/Extension-CareConnect-GPC-MedicationRepeatInformation-1");

            if (repeatInformation is not null)
            {
                var numberOfRepeatPrescriptionsAllowed = repeatInformation.Extension.FirstOrDefault(x =>
                    x.Url == "numberOfRepeatPrescriptionsAllowed");
                var value = numberOfRepeatPrescriptionsAllowed.Value.FirstOrDefault().Value;
                return (int)value;
            }
            return null;
        }
    }

    
    
    
    public int? NumberOfRepeatPrescriptionsIssued
    {
        get
        {
            var repeatInformation = Extension.FirstOrDefault(x => x.Url == "https://fhir.nhs.uk/STU3/StructureDefinition/Extension-CareConnect-GPC-MedicationRepeatInformation-1");

            if (repeatInformation is not null)
            {
                var numberOfRepeatPrescriptionsIssued = repeatInformation.Extension.FirstOrDefault(x =>
                    x.Url == "numberOfRepeatPrescriptionsIssued");
                var value = numberOfRepeatPrescriptionsIssued.Value.FirstOrDefault().Value;
                return (int)value;
            }
            return null;
        }
    }

    private void InitInhertedProperties (object medicationRequest)
    {
        foreach (var propertyInfo in medicationRequest.GetType().GetProperties())
        {
            var props = typeof(MedicationRequest).GetProperties().Where(p => !p.GetIndexParameters().Any());
            foreach (var prop in props)
            {
                if (prop.CanWrite)
                    prop.SetValue(this, prop.GetValue(medicationRequest));
            }
        }
    }
}