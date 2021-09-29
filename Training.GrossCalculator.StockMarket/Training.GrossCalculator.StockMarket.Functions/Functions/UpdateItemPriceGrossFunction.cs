using System;
using System.Buffers.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Training.GrossCalculator.StockMarket.Application;
using Training.GrossCalculator.StockMarket.Application.Models;

namespace Training.GrossCalculator.StockMarket.Functions.Functions
{
    public class UpdateItemPriceGrossFunction
    {
        private readonly IExecutable<CosmosItem, UpdatePriceGrossResponse> _executable;
        public UpdateItemPriceGrossFunction(IExecutable<CosmosItem, UpdatePriceGrossResponse> executable)
        {
            _executable = executable;
        }

        [FunctionName(nameof(UpdateItemPriceGrossFunction))]
        public async Task Run([QueueTrigger("updateitempricegross", Connection = "AzureWebJobsStorage")]string myQueueItem, ILogger log)
        {
            CosmosItem data = JsonConvert.DeserializeObject<CosmosItem>(myQueueItem);
            await _executable.ExecuteAsync(data);
        }
    }
}
