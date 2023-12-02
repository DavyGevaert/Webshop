using Webshop.Model;
using Webshop.Sdk.Abstractions;

namespace Webshop.Sdk
{
	public class CartState : ICartState
	{
		private readonly ItemApi _itemApi;

        public IList<Item> Basket { get; set; } = new List<Item>();

        public CartState(ItemApi itemApi)
		{
            _itemApi = itemApi;
		}

		public async Task AddItemToBasket(Item item)
		{
				
			if (Basket.Any(b => b.Id == item.Id) is false)
			{
				// only one same item can be added to Basket
				Basket.Add(item);
			}

			// update quantity if item exists
			foreach (var b in Basket.Where(b => b.Id == item.Id))
			{
				if (b.Quantity == item.CurrentInStock)
				{
					b.ButtonText = "Sold out";
					b.OutOfStock = true;
					await _itemApi.SaveItemAsync(b);
				}
				else
				{
					b.Quantity += 1;
					await _itemApi.SaveItemAsync(b);
				}
			}
        }

		public async Task UpdateStock()
		{
			foreach (var item in Basket)
			{
				item.CurrentInStock -= item.Quantity;
				item.Quantity = 0;
				// save new stock on each item in Web Api
				await _itemApi.SaveItemAsync(item);

			}
		}
	}
}
