using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace HttpFunctionApp
{
    public class HelloFunction
    {
        private readonly ILogger<HelloFunction> _logger;

        public HelloFunction(ILogger<HelloFunction> logger)
        {
            _logger = logger;
        }

        [Function("Hello")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("HTTP trigger function processed a request.");

            var response = new
            {
                message = "Hello from Azure Functions!",
                timestamp = DateTime.UtcNow,
                status = "success"
            };

            return new JsonResult(response);
        }
    }
}
