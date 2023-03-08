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
      [HttpPost]
    [Route("process-payment")]
    public async Task<ProcessPaymentResponse> ProcessPayment(ProcessPaymentRequest paymentRequest)
    {
        ProcessPaymentResponse processPaymentResponse = new ProcessPaymentResponse();

        Console.WriteLine($"Payment Request: {Newtonsoft.Json.JsonConvert.SerializeObject(paymentRequest)}");

        MercadoPagoConfig.AccessToken = "TEST-7654402655586663-070214-f14ed0c6b6cbaeb3a241b1d99a16318f-23630182";


        // Cria o objeto de request da preferÍncia
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

        // Cria a preferÍncia usando o client
        var client = new PreferenceClient();
        Preference preference = await client.CreateAsync(request);
        processPaymentResponse.UrlCheckout = preference.SandboxInitPoint;

        return processPaymentResponse;
    }
}
