using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Training.GrossCalculator.StockMarket.Application;
using Training.GrossCalculator.StockMarket.Application.Models;

namespace Training.GrossCalculator.StockMarket.Functions.Functions
{
    public class GetInvoicePerClientIdFunction
    {
        private IExecutable<GetInvoiceRequest, GetInvoiceResponse> _executable;
        public GetInvoicePerClientIdFunction(IExecutable<GetInvoiceRequest, GetInvoiceResponse> executable)
        {
            _executable = executable;
        }

        [FunctionName(nameof(GetInvoicePerClientIdFunction))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            GetInvoiceRequest data = JsonConvert.DeserializeObject<GetInvoiceRequest>(requestBody);

            return new OkObjectResult(await _executable.ExecuteAsync(data));
        }
    }
}
