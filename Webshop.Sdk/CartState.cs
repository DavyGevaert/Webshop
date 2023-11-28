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

		public async Task AddItemToBasketAsync(Item item)
		{
			if (Basket.Any(b => b.Id == item.Id) is false)
			{
				// only one same item can be added to Basket
				Basket.Add(item);
			}

			item.Quantity += 1;
		}

		public IList<Item> GetBasket()
		{
			return Basket;
		}

		public async Task UpdateStock()
		{
			foreach (var item in Basket)
			{
				// adjust current stock minus quantity
				item.CurrentInStock -= item.Quantity;

				// save new stock on each item in Web Api
				await _itemApi.SaveItemAsync(item);

			}
		}
	}
}
