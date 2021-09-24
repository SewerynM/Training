using Training.GrossCalculator.StockMarket.Application.Models;

namespace Training.GrossCalculator.StockMarket.Application.Mappers
{
    public class AddItemMapper
    {
        public static void Map(AddItemRequest request, dynamic data)
        {
            if (data == null)
            {
                return;
            }

            Item[] items = new Item[data.Items.Length];
            for(int i = 0; i < data.Items.Length; i++)
            {
                Item item = new Item(data.Items[i].Name, data.Items[i].Category, data.Items[i].PriceNet);
                items[i] = item;
            }


            request.ClientId = data.ClientId;
            request.Items = items;
        }
    }
}