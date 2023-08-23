using GPMigratorApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using FutureNHS.Api.Configuration;
using GPMigratorApp.GPConnect;
using Hl7.Fhir.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace GPMigratorApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGPConnectService _gpConnectService;
        private readonly AppSettings _appSettings;

        
        public HomeController(ILogger<HomeController> logger, IOptionsSnapshot<AppSettings> appSettings, IGPConnectService gpConnectService)
        {
            _logger = logger;
            _gpConnectService = gpConnectService;
            _appSettings = appSettings.Value;
        }

        public IActionResult Index()
        {
            var search = new Search();
            return View(search);
        }

        [HttpPost]
        public async Task<IActionResult> IndexPost(Search search)
        {
            var request = CreateRequest(search.NhsNumber.Trim());

            var options = new JsonSerializerOptions();
            options.WriteIndented = true;
            
            string jsonString = JsonSerializer.Serialize(request);
            
            var result = await _gpConnectService.SendRequestAsync(HttpMethod.Post,
                "/Patient/$gpc.getstructuredrecord", Guid.NewGuid().ToString(), _appSettings.ConsumerASID,
                _appSettings.ProviderASID,JsonContent.Create(request));

            search.Request = request;

            var patients = result.Patients;

            search.Response = result;
            
            return View("Index",search);
        }

        private StructuredRecordRequest CreateRequest(string nhsNumber)
        {
            var data = new StructuredRecordRequest
            {
                resourceType = "Parameters",
                parameter = new List<Parameter>
                {
                    new()
                    {
                        name = "patientNHSNumber",
                        valueIdentifier = new ValueIdentifier
                        {
                            system = "https://fhir.nhs.uk/Id/nhs-number",
                            value = nhsNumber
                        }
                    },
                    new()
                    {
                        name = "includeAllergies",
                        part = new List<Part>
                        {
                            new Part
                            {
                                name = "includeResolvedAllergies",
                                valueBoolean = true
                            }
                        }
                    },
                    new Parameter
                    {
                        name = "includeMedication"
                    },
                    new Parameter
                    {
                        name = "includeConsultations",
                        part = new List<Part>
                        {
                            new Part
                            {
                                name = "includeNumberOfMostRecent",
                                valueInteger = 999
                            }
                        }
                    },
                    new Parameter
                    {
                        name = "includeProblems"
                    },
                    new Parameter
                    {
                        name = "includeImmunisations"
                    },
                    new Parameter
                    {
                        name = "includeUncategorisedData"
                    },
                    new Parameter
                    {
                        name = "includeInvestigations"
                    },
                    new Parameter
                    {
                        name = "includeReferrals"
                    }
                }
            };
            return data;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}