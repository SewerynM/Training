using System;
using System.IO;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
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
        private readonly IValidator<AddItemRequest> _validatorItem;
        private readonly IValidator<AddItemRequest> _validatorRequest;
        private readonly IExecutable<AddItemRequest, AddItemResponse> _executable;

        public AddItem(IValidator<AddItemRequest> validatorItem, IValidator<AddItemRequest> validatorRequest, IExecutable<AddItemRequest, AddItemResponse> executable)
        {
            _validatorItem = validatorItem;
            _validatorRequest = validatorRequest;
            _executable = executable;
        }

        [FunctionName(nameof(AddItem))]
        public async Task<IActionResult> Run( 
            [HttpTrigger(AuthorizationLevel.Anonymous,  "post", Route = "v1/items")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            AddItemRequest data = JsonConvert.DeserializeObject<AddItemRequest>(requestBody);

            var requestValidationResult = _validatorRequest.Validate(data);
            if(requestValidationResult.IsValid)
            {
                var itemValidationResult = _validatorItem.Validate(data);
                if(itemValidationResult.IsValid)
                {
                    return new OkObjectResult(await _executable.ExecuteAsync(data));
                }
                return new OkObjectResult(itemValidationResult.Errors);
            }
            return new OkObjectResult(requestValidationResult.Errors);
        }
    }
}
