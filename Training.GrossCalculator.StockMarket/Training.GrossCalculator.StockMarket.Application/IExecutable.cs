using System.Threading.Tasks;

namespace Training.GrossCalculator.StockMarket.Application
{
    public interface IExecutable<in TRequest, TIActionResult>
    {
        Task<TIActionResult> ExecuteAsync(TRequest request);
    }
}