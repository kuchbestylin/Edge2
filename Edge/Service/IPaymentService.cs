using Edge.Models;
using Paygate.Models.Response;

namespace Edge.Services
{
    public interface IPaymentService
    {
        // Main method to initiate payment
        Task<TransactionResponse> InitiatePaymentAsync(PaymentModel model, string paymentMethod);

        // Helper methods
        string ParseSoapResponse(string responseString);

        // Additional methods if needed
        Task<TransactionResponse> ProcessPaymentRequestAsync(PaymentModel model, string paymentMethod);
        Task<TransactionResponse> ParseSoapResponseDetailed(string responseString, string transactionId);
    }
}




