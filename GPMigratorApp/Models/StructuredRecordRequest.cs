using System.Text.Json.Serialization;

namespace GPMigratorApp.Models;

public class StructuredRecordRequest
{
    public string resourceType { get; set; }
    public List<Parameter> parameter { get; set; }
}

public class ValueIdentifier
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? system { get; set; }
        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? value { get; set; }
    }

    public class Part
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string name { get; set; }
        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? valueBoolean { get; set; }
        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int? valueInteger { get; set; }
    }

    public class Parameter
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? name { get; set; }
        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ValueIdentifier? valueIdentifier { get; set; }
        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public List<Part>? part { get; set; }
    }
