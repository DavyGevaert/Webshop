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

		public async Task Increment(Item item)
		{
			if (item.Quantity == item.CurrentInStock)
			{
				// do nothing, the customer sees that the item cannot be bought when the current stock supply reaches it's limit
			}
			else
			{
				item.Quantity += 1;
				await _itemApi.SaveItemAsync(item);
			}

			TotalPrice();
		}

		public async Task Decrement(Item item)
		{
			if (item.Quantity <= 0)
			{
				RemoveItemFromBasket_If_Customer_Decrement_Quantity_Below_0(item);
				TotalPrice();
				await _itemApi.SaveItemAsync(item);
			}
			else
			{
				item.Quantity -= 1;
				item.ButtonText = "Buy";
				item.OutOfStock = false;
				TotalPrice();
				await _itemApi.SaveItemAsync(item);
			}
		}

		public void RemoveItemFromBasket_If_Customer_Decrement_Quantity_Below_0(Item item)
		{
			Basket.Remove(item);
		}

		public string TotalPrice()
		{
			var totalPrice = 0;

			foreach (var item in Basket)
			{
				totalPrice += (item.Price * item.Quantity);
			}

			return totalPrice.ToString("c");
		}
	}
}
