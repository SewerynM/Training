using System;
using System.IO;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Training.GrossCalculator.StockMarket.Functions.Functions;
using Training.GrossCalculator.StockMarket.Application;
using Training.GrossCalculator.StockMarket.Application.Models;


namespace Training.GrossCalculator.StockMarket.Functions
{
    public class AddItem
    {
        private readonly IValidator<AddItem> _validator;
        private readonly IExecutable<AddItemRequest, AddItemResponse> _executable;

        public AddItem(IValidator<AddItem> validator, IExecutable<AddItemRequest, AddItemResponse> executable)
        {
            _validator = validator;
            _executable = executable;
        }

        [FunctionName(nameof(AddItem))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous,  "post", Route = "v1/items")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<AddItemRequest>(requestBody);
            var response = await _executable.ExecuteAsync(data);


            return new OkObjectResult(response);
        }
    }
}
