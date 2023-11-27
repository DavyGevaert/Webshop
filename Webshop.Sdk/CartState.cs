using Webshop.Model;
using Webshop.Sdk.Abstractions;

namespace Webshop.Sdk
{
	public class CartState : ICartState
	{
		private readonly BlurayApi _blurayApi;

		public IList<Bluray> SelectedItems { get; set; } = new List<Bluray>();

		public CartState(BlurayApi blurayApi)
		{
			_blurayApi = blurayApi;
		}

		public async Task AddItemToCartAsync(int Id)
		{
			if (SelectedItems.Any(b => b.Id == Id) is false)
			{
				var cartItem = await _blurayApi.GetAsync(Id);

				SelectedItems.Add(cartItem);
			}
		}

		public IList<Bluray> GetCartItems()
		{
			return SelectedItems;
		}
	}
}
