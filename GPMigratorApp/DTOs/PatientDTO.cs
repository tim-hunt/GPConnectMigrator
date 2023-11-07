using System.Net.Mail;

namespace GPMigratorApp.DTOs;

public class PatientDTO
{
    public string PatientGuid { get; set; }
    public string OrganisationGuid { get; set; }
    public string UsualGpUserInRoleGuid { get; set; }
    public string? Sex { get; set; }
    public DateTime DateOfBirthUTC { get; set; }
    public DateTime? DateOfDeathUTC { get; set; }
    public string? Title { get; set; }
    public string GivenName { get; set; }
    public IEnumerable<string>? MiddleNames { get; set; }
    public string Surname { get; set; }
    public DateTime? DateOfRegistrationUTC { get; set; }
    public string? NhsNumber { get; set; }
    public string? PatientNumber { get; set; }
    public string PatientTypeDescription { get; set; }
    public string? DummyType { get; set; }
    public AddressDTO? HomeAddress { get; set; }
    public IEnumerable<AddressDTO>? OtherAddresses { get; set; }
    public string ResidentialInstituteCode { get; set; }
    public string? NHSNumberStatus { get; set; }
    public string? CarerName { get; set; }
    public string? CarerRelation { get; set; }
    public string? PersonGuid { get; set; }
    public DateTime? DateOfDeactivation { get; set; }
    public bool? Deleted { get; set; }
    public bool? Active{ get; set; }
    public bool? SpineSensitive { get; set; }
    public bool? IsConfidential { get; set; }
    public MailAddress? EmailAddress { get; set; }
    public string? HomePhone { get; set; }
    public string? MobilePhone { get; set; }
    public string? ExternalUsualGPGuid { get; set; }
    public string? ExternalUsualGP { get; set; }
    public string? ExternalUsualGPOrganisation { get; set; }
    public string? ProcessingId { get; set; }
    public string? Ethnicity { get; set; }
    public string? Religion { get; set; }
    
    public List<CommunicationDTO>? Communication{ get; set; }

}