namespace GPMigratorApp.DTOs;
 
 public class TimingDTO
 {
         public Guid Id { get; set; }
         public DateTime? Event { get; set; }
         public decimal? BoundsDuration { get; set; }
         public decimal? BoundsDurationMax { get; set; }
         public string? BoundsDurationUnit { get; set; }
         public int? Count { get; set; }
         public int? CountMax { get; set; }
         public decimal? Duration { get; set; }
         public decimal? DurationMax { get; set; }
         public string? DurationUnit { get; set; }
         public int? Frequency { get; set; }
         public int? FrequencyMax { get; set; }
         public decimal? Period { get; set; }
         public decimal? PeriodMax { get; set; }
         public string? PeriodUnit { get; set; }
         public string? DayOfWeek { get; set; }
         public int? TimeOfDay { get; set; }
         public string? When { get; set; }
         public uint? Offset { get; set; }
         public string Code { get; set; }
 }