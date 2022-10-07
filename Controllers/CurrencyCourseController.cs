using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TestAPI.Models;

namespace TestAPI.Controllers;

[ApiController]
[Route("api/v1/CurrencyCourse")]
public class CurrencyCourseController : ControllerBase
{
    private readonly ILogger<CurrencyCourseController> _logger;

    public CurrencyCourseController(ILogger<CurrencyCourseController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetCurrencyCourse")]
    #region Swagger description
    [SwaggerOperation(
       Summary = "Get Currency Course at specific date",
       OperationId = "Get.Currency.Course")]
    [SwaggerResponse(
       StatusCodes.Status200OK,
       "Currency course at specific date",
       typeof(DTO.Currency))]
    [Produces("application/json")]
    #endregion
    public async Task<IActionResult> GetCurrencyCourse([Required][FromQuery(Name = "date")][SwaggerParameter("Specific date MM.DD.YYYY")] DateTime specificDate, [FromQuery(Name = "currency")][SwaggerParameter("Currency type")] string? currencyType)
    {
        if (specificDate < DateTime.Parse("01.09.2022") || specificDate >= DateTime.Parse("29.09.2022"))
            return BadRequest("incorrect date");

        List<Currency> currencies = new List<Currency>();
        switch (currencyType.ToUpper())
        {
            case "USD":
                currencies.Add(new USD());
                break;
            case "EUR":
                currencies.Add(new EUR());
                break;
            case "GBP":
                currencies.Add(new GBP());
                break;
            default:
                currencies.Add(new USD());
                currencies.Add(new EUR());
                currencies.Add(new GBP());
                break;
        }

        DTO.Currency currency = new DTO.Currency
        {
            SpecificDate = specificDate.ToString("dd.MM.yyyy"),
            Currencies = currencies
        };

        return Ok(currency);
    }

}
