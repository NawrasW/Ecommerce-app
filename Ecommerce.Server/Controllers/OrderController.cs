﻿


using Ecommerce.Server.Models.Domain;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;

using Stripe.Checkout;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
//[ApiExplorerSettings(IgnoreApi = true)]
public class OrderController : ControllerBase
{
    private readonly IConfiguration _configuration;

    private static string s_wasmClientURL = string.Empty;

    public OrderController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    [HttpPost("checkout")]
    public async Task<ActionResult> CheckoutOrder([FromBody] List<Product> products, [FromServices] IServiceProvider sp)
    {
        try
        {
            var referer = Request.Headers.Referer;
            s_wasmClientURL = referer[0];

            // Build the URL to which the customer will be redirected after paying.
            var server = sp.GetRequiredService<IServer>();

            var serverAddressesFeature = server.Features.Get<IServerAddressesFeature>();

            string? thisApiUrl = null;

            if (serverAddressesFeature is not null)
            {
                thisApiUrl = serverAddressesFeature.Addresses.FirstOrDefault();
            }

            if (thisApiUrl is not null)
            {
                var sessionId = await CheckOut(products, thisApiUrl);
                var pubKey = _configuration["Stripe:PubKey"];

                var checkoutOrderResponse = new Order()
                {
                    SessionId = sessionId,
                    PubKey = pubKey
                };

                return Ok(checkoutOrderResponse);
            }
            else
            {
                return StatusCode(500);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during checkout: {ex}");
            return StatusCode(500);
        }
    }



    [NonAction]
    public async Task<string> CheckOut(List<Product> products, string thisApiUrl)
    {
        try
        {
            // Create a payment flow from the items in the cart.
            // Gets sent to Stripe API.
            var lineItems = products.Select(product => new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = (long?)product.Price, // Price is in USD cents.
                    Currency = "USD",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = product.Name,
                        Description = product.Description,
                        Images = new List<string> { product.ImageData }
                    },
                },
                Quantity = product.Quantity,
            }).ToList();

            var options = new SessionCreateOptions
            {
                // Stripe calls the URLs below when certain checkout events happen such as success and failure.
                SuccessUrl = $"{thisApiUrl}/checkout/success?sessionId=" + "{CHECKOUT_SESSION_ID}", // Customer paid.
                CancelUrl = s_wasmClientURL + "failed",  // Checkout cancelled.
                PaymentMethodTypes = new List<string> // Only card available in test mode?
            {
                "card"
            },
                LineItems = lineItems,
                Mode = "payment" // One-time payment. Stripe supports recurring 'subscription' payments.
            };

            var service = new SessionService();
            var session = await service.CreateAsync(options);

            return session.Id;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during checkout (CheckOut method): {ex}");
            throw; // Propagate the exception for higher-level handling
        }
    }


    [HttpGet("success")]
    // Automatic query parameter handling from ASP.NET.
    // Example URL: https://localhost:7033//checkout/success?sessionId=si_123123123123
    public ActionResult CheckoutSuccess(string sessionId)
    {
        var sessionService = new SessionService();
        var session = sessionService.Get(sessionId);

        // Here you can save order and customer details to your database.
        var total = session.AmountTotal.Value;
        var customerEmail = session.CustomerDetails.Email;

        return Redirect(s_wasmClientURL + "success");
    }




}