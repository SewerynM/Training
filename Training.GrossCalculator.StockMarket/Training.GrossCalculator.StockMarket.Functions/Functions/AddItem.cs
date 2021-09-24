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

namespace Training.GrossCalculator.StockMarket.Functions
{
    public class AddItem : IAddItem
    {
        private readonly IValidator<AddItem> _validator;

        public AddItem(IValidator<AddItem> validator)
        {
            this._validator = validator;
        }

        [FunctionName(nameof(AddItem))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous,  "post", Route = "v1/items")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            
            return new OkObjectResult(data[0].items[2].name);
        }
    }
}
