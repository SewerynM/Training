using System.Threading.Tasks;
using Training.GrossCalculator.StockMarket.Application.Models;

namespace Training.GrossCalculator.StockMarket.Application.Connectors
{
    public interface IItemsCosmosDBConnector
    {
        Task AddItemsToContainerAsync(CosmosItem item);

    }
}