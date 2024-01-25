namespace GPMigratorApp.DTOs;

public class MedicationDTO
{
    private Guid Id { get; set; }
    public string? SnomedCode { get; set; }
    public string? MultilexCode { get; set; }
    public string? SnomedDisplayName { get; set; }
    public string? MultilexDisplayName { get; set; }
    public bool? MultilexUserSelected { get; set; }
    public OrganizationDTO Manufacturer { get; set; }
    public string? Form { get; set; }
    public decimal Quantity { get; set; }
    public string? BatchNumber { get; set; }
    public DateTime? ExpirationDate { get; set; }
    
}