using Webshop.Model;
using Webshop.Sdk.Abstractions;

namespace Webshop.Sdk
{
	public class CartState : ICartState
	{
		private readonly ItemApi _itemApi;

		public IList<Item> SelectedItems { get; set; } = new List<Item>();

		public CartState(ItemApi itemApi)
		{
            _itemApi = itemApi;
		}

		public async Task AddItemToCartAsync(int Id)
		{
			if (SelectedItems.Any(b => b.Id == Id) is false)
			{
				var cartItem = await _itemApi.GetAsync(Id);

				SelectedItems.Add(cartItem);
			}
		}

		public IList<Item> GetCartItems()
		{
			return SelectedItems;
		}
	}
}
