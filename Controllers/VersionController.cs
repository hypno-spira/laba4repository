using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using thefirst.Models;
using Serilog;

namespace thefirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get() //
        {
            Log.Information("Acquiring version info");
            Log.Warning("Some warning");
            Log.Error("Here comes an error");

            var versionInfo = new Version
            {
                Company = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyCompanyAttribute>().Company,
                Product = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyProductAttribute>().Product,
                ProductVersion = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion
            };

            Log.Information($"Current app version is: {versionInfo.ProductVersion}");
            Log.Information($"Current company is: {versionInfo.Company}");
            Log.Debug($"Full information: {@versionInfo}");

            return Ok(versionInfo);
        }
    }
}