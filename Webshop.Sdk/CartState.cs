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

		public async Task AddItemToBasketAsync(int Id)
		{
			if (Basket.Any(b => b.Id == Id) is false)
			{
				var cartItem = await _itemApi.GetAsync(Id);

				Basket.Add(cartItem);
			}
		}

		public IList<Item> GetBasket()
		{
			return Basket;
		}

		public void Checkout()
		{
			throw new NotImplementedException();
		}

		public int UpdateStock(int minusQuantity)
		{
			throw new NotImplementedException();
		}
	}
}
