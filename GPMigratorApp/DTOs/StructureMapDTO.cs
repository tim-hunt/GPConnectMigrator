namespace GPMigratorApp.DTOs;

public class StructureMapDTO
{
    public Guid Id { get; set; }
    public IdentifierDTO Identifier { get; set; }
    public string? Version { get; set; }
    public string? Name { get; set; }
    public string? Title { get; set; }
    public string? Status { get; set; }
    public bool? Experimental { get; set; }
    public DateTime? Date { get; set; }
    public string Publisher { get; set; }
    public string? ContactName { get; set; }
    public string? ContactNumber { get; set; }
    public string? Description { get; set; }
    public string? UseContextCode { get; set; }
    public decimal? UseContextQuantity { get; set; }
    public int? UseContextRangeHigh { get; set; }
    public int? UseContextRangeLow { get; set; }
    public string? Jurisdiction { get; set; }
    public string? Purpose { get; set; }
    public string? Copyright { get; set; }
    public string? Structure { get; set; }
    public string? Import { get; set; }
}