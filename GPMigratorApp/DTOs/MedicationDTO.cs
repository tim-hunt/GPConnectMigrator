namespace GPMigratorApp.DTOs;

public class MedicationDTO
{
    private long Guid { get; set; }
    public string? SnomedCode { get; set; }
    public string? MultilexCode { get; set; }
    public string? SnomedDisplayName { get; set; }
    public string? MultilexDisplayName { get; set; }
    public bool? MultilexUserSelected { get; set; }
}