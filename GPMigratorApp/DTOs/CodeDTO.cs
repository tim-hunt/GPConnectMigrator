namespace GPMigratorApp.DTOs;

public class CodeDTO
{
    public Guid Id { get; set; }
    public string? System { get; set; }
    public string? Code { get; set; }
    public string? Display { get; set; }
    public bool? UserSelected  { get; set; }
    
}