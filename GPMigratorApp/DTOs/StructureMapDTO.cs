namespace GPMigratorApp.DTOs;

public class StructureMap
{
    public Uri url { get; set; }
    public IList<Identifier> identifier { get; set; }
    public string version { get; set; }
    public string name { get; set; }
    public string title { get; set; }
    public CodeBinding status { get; set; }
    public bool experimental { get; set; }
    public DateTime date { get; set; }
    public string publisher { get; set; }
    public IList<ContactDetail> contact { get; set; }
    public string description { get; set; }
    public IList<UsageContext> useContext { get; set; }
    public IList<CodeableConceptBinding> jurisdiction { get; set; }
    public string purpose { get; set; }
    public string copyright { get; set; }
    public IList<BackboneElement> structure { get; set; }
    public IList<Uri> import { get; set; }
    public IList<BackboneElement> group  { get; set; }

    public StructureMap()
    {
        this.identifier = new List<Identifier>();
        this.contact = new List<ContactDetail>();
        this.useContext = new List<UsageContext>();
        this.jurisdiction = new List<CodeableConceptBinding>();
        this.structure = new List<BackboneElement>();
        this.import = new List<Uri>();
        this.group = new List<BackboneElement>();
    }
}