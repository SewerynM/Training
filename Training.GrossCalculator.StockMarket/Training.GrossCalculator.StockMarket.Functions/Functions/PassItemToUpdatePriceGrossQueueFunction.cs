using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Training.GrossCalculator.StockMarket.Application.Models;

namespace Training.GrossCalculator.StockMarket.Functions.Functions
{
    public class PassItemToUpdatePriceGrossQueueFunction
    {
        private readonly QueueClient _queueClient;
        public PassItemToUpdatePriceGrossQueueFunction(QueueClient queueClient)
        {
            _queueClient = queueClient;
        }

        [StorageAccount("AzureWebJobsStorage")]
        [FunctionName(nameof(PassItemToUpdatePriceGrossQueueFunction))]
        public void Run([CosmosDBTrigger(
            databaseName: "InvoiceStorage",
            collectionName: "Items",
            ConnectionStringSetting = "CosmosDbConnectionString",
            CreateLeaseCollectionIfNotExists = true,
            LeaseCollectionName = "leases")]IReadOnlyList<Document> input,
            ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                foreach (var item in input)
                {
                    CosmosItem data = JsonConvert.DeserializeObject<CosmosItem>(item.ToString());
                    if (string.IsNullOrEmpty(data.PriceGross.ToString()))
                    {
                        string sendReadyData = JsonConvert.SerializeObject(data);
                        _queueClient.SendMessage(sendReadyData);
                    }
                }
            }
        }
    }
}