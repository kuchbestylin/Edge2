using Edge.Controllers;
using Edge.Services;
using Edge.Models;
using Paygate;


namespace Edge.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
