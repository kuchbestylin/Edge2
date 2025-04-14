using Edge.Models;
using Edge.Services;
using Microsoft.AspNetCore.Mvc;


namespace Edge.Controllers
{
    [Route("[controller]")]
    public class PaymentController : Controller
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService payGateService)
        {
            _paymentService = payGateService;
        }

        [HttpGet]
        [Route("Checkout")]
        public IActionResult Checkout()
        {
            return View(new PaymentModel());
        }

        [HttpGet]
        [Route("Success")]
        public IActionResult Success()
        {
            return View();
        }

        [HttpPost]
        [Route("InitiatePaymentAsync")]
        public IActionResult InitiatePaymentAsync(PaymentModel model, string paymentMethod)
        {
            try
            {
                string orderId = Guid.NewGuid().ToString();
                if (!ModelState.IsValid)
                {
                    ViewBag.Response = "Invalid input data.";
                    return View("Checkout");
                }

                if (_paymentService == null)
                    throw new InvalidOperationException("Payment service is not initialized.");

                var transactionResponse = _paymentService.MakePayment(model, orderId);

                ViewBag.Success = transactionResponse.ResultCode == 990017 ? true : false;
                ViewBag.Status = transactionResponse.StatusName;
                ViewBag.Description = transactionResponse.ResultDescription;

                if (ViewBag.Success)
                    return View("Success", transactionResponse);

                return View("Checkout");
            }
            catch (Exception ex)
            {
                ViewBag.Response = $"Error: {ex.Message}";
                return View("Checkout");
            }
        }

    }
}