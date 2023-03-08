using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using webapi.Dtos;
//Mercadopago deps
using System;
using System.Threading.Tasks;
using MercadoPago.Client.Payment;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using MercadoPago.Client.Preference;
using MercadoPago.Resource.Preference;

namespace webapi.Controllers;

[EnableCors("CorsPolicy")]
[ApiController]
[Route("/")]
public class MercadopagoController : ControllerBase
{
    /*private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }*/

    [HttpPost]
    [Route("process-payment")]
    public async Task<ProcessPaymentResponse> ProcessPayment(ProcessPaymentRequest paymentRequest)
    {
        ProcessPaymentResponse processPaymentResponse = new ProcessPaymentResponse();

        Console.WriteLine($"Payment Request: {Newtonsoft.Json.JsonConvert.SerializeObject(paymentRequest)}");

        MercadoPagoConfig.AccessToken = "TEST-7654402655586663-070214-f14ed0c6b6cbaeb3a241b1d99a16318f-23630182";


        // Cria o objeto de request da preferência
        var request = new PreferenceRequest
        {
            Items = new List<PreferenceItemRequest>
        {
            new PreferenceItemRequest
            {
                Title = "Meu produto",
                Quantity = 1,
                CurrencyId = "BRL",
                UnitPrice = 75.56m,
            },
        },
            };

        // Cria a preferência usando o client
        var client = new PreferenceClient();
        Preference preference = await client.CreateAsync(request);
        processPaymentResponse.UrlCheckout = preference.SandboxInitPoint;

        return processPaymentResponse;
    }
}
