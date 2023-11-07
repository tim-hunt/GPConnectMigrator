namespace GPMigratorApp.DTOs;

public class PracticionerDTO
{
    public PracticionerDTO()
    {
        Qualifications = new List<QualificationDTO>();
    }

    public string Reference{ get; set; }
    public string? SdsUserId{ get; set; }
    public string? SdsRoleProfileId{ get; set; }
    public string? Title { get; set; }
    public string GivenName { get; set; }
    public IEnumerable<string>? MiddleNames { get; set; }
    public string Surname { get; set; }
    public string? Sex { get; set; }
    public DateTime? DateOfBirthUtc { get; set; }
    public List<QualificationDTO>? Qualifications { get; set; }
    public AddressDTO Address{ get; set; }
}