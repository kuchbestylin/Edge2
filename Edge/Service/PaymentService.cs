using Edge.Models;
using Paygate;
using Paygate.Models.Response;
using Paygate.Models.Shared; // Added for StatusName enum

namespace Edge.Services
{
    public class PaymentService
    {
        private readonly HttpClient _httpClient;
        private readonly IPaygateService _paygateService;

        public PaymentService(HttpClient httpClient,
            IPaygateService paygateService)
        {
            _httpClient = httpClient;
            _paygateService = paygateService;
        }

        public TransactionResponse MakePayment(PaymentModel paymentModel, string orderID)
        {
            var transaction = _paygateService.CreateTransaction(new Paygate.Models.Request.CreateTransactionModel
            {
                Card = new CardDetails
                {
                    Cvv = paymentModel.CVV,
                    ExpiryMonth = paymentModel.ExpiryMonth.ToString("D2"),
                    ExpiryYear = paymentModel.ExpiryYear.ToString(),
                    HolderName = $"{paymentModel.FirstName} {paymentModel.LastName}",
                    Number = paymentModel.CardNumber
                },
                Order = new OrderDetails
                {
                    MerchantOrderId = orderID,
                    Amount = (int)Math.Floor(paymentModel.Amount),
                    Currency = Currencies.ZAR,
                    Items = new List<OrderItems>
                    {
                        new OrderItems
                        {
                            Currency = Currencies.ZAR,
                            OrderQuantity = 1,
                            ProductCode = paymentModel.ProductCode,
                            UnitPrice = (decimal)paymentModel.Amount
                        }
                    }
                },
                Redirect = new RedirectDetails
                {
                    RedirectUrl = "https://www.google.com",
                    NotifyUrl = "https://www.google.com"
                },
                Customer = new CustomerDetails
                {
                    Email = paymentModel.Email,
                    FirstName = paymentModel.FirstName,
                    LastName = paymentModel.LastName
                }
            });

            return transaction;
        }
    }
}