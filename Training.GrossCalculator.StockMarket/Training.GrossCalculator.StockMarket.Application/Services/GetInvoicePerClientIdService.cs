using System.Threading.Tasks;
using Training.GrossCalculator.StockMarket.Application.Connectors;
using Training.GrossCalculator.StockMarket.Application.Models;

namespace Training.GrossCalculator.StockMarket.Application
{
    public class GetInvoicePerClientIdService : IExecutable<GetInvoiceRequest, GetInvoiceResponse>
    {
        private readonly IItemsCosmosDBConnector _itemsCosmosDbConnector;

        public GetInvoicePerClientIdService(IItemsCosmosDBConnector itemsCosmosDbConnector)
        {
            _itemsCosmosDbConnector = itemsCosmosDbConnector;
        }
        public async Task<GetInvoiceResponse> ExecuteAsync(GetInvoiceRequest request)
        {
            return await _itemsCosmosDbConnector.GetItemsPerClientId(request.ClientId);
        }
    }
}