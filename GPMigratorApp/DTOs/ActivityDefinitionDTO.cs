namespace GPMigratorApp.DTOs;

    public class ActivityDefinitionDTO
    {
        public Guid id { get; set; } 
        public IdentifierDTO Identifier { get; set; } 
        public string? Version { get; set; } 
        public string? Name { get; set; } 
        public string? Title { get; set; } 
        public string Status { get; set; } 
        public bool? Experimental { get; set; }
        public DateTime? Date { get; set; } 
        public string? Publisher { get; set; } 
        public string? Description { get; set; } 
        public string? Purpose { get; set; } 
        public string? Usage { get; set; } 
        public DateTime? ApprovalDate { get; set; } 
        public DateTime? LastReviewDate { get; set; } 
        public DateTime? EffectiveStart { get; set; } 
        public DateTime? EffectiveEnd { get; set; } 
        public string? UsageContextCode { get; set; } 
        public decimal? UsageContextQuantity { get; set; } 
        public int? UsageContextRangeLow { get; set; } 
        public int? UsageContextRangeHigh { get; set; } 
        public string? Jurisdiction { get; set; } 
        public string? Topic { get; set; } 
        public string? Contributor { get; set; } 
        public string? Contact { get; set; } 
        public string? Copyright { get; set; } 
        public OutboundRelationship RelatedArtifact { get; set; } 
        public string? Library { get; set; } 
        public string? Code { get; set; } 
        public DateTime? TimingDate { get; set; } 
        public DateTime? TimingPeriodStart { get; set; } 
        public DateTime? TimingPeriodEnd { get; set; } 
        public int? TimingRangeLow { get; set; } 
        public int? TimingRangeHigh { get; set; } 
        public LocationDTO Location { get; set; } 
        public string? ParticipantType { get; set; } 
        public string? ParticipantRole { get; set; } 
        public MedicationDTO Product { get; set; }
        public int? Quantity { get; set; }
        public DosageDTO? Dosage { get; set; }
        public string? BodySite { get; set; }
        public StructureMapDTO Transform { get; set; }
    }