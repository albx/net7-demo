using Microsoft.AspNetCore.Mvc;
using Net7Demo.Mvc.Models.Net7;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Net7Demo.Mvc.Controllers;

[Route("netseven")]
[ApiController]
public class Net7Controller : Controller
{
    //public IActionResult Index()
    //{
    //    IndexViewModel? model = new() { Text = "Ciao da .NET 7"};
    //    return View(model);
    //}

    [HttpPost]
    public IActionResult Post([FromBody] MyModel model)
    {
        return Ok();
    }
}

public record MyModel
{
    [Required]
    [SaladChefValidator]
    [JsonPropertyName("mytext")]
    public string Text { get; set; }
};