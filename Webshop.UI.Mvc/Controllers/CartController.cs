using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Webshop.Model;
using Webshop.Sdk;
using Webshop.Sdk.Abstractions;

namespace Webshop.UI.Mvc.Controllers
{
	public class CartController : Controller
	{
		private readonly CartState _cartState;
		private readonly ItemApi _itemApi;

		public CartController(CartState cartState, ItemApi itemApi)
		{
			_cartState = cartState;
			_itemApi = itemApi;
		}

		public IActionResult Index()
		{
			var items = _cartState.Basket;

			ViewBag.TotalPrice = _cartState.TotalPrice();

			return View(items);
		}

		public async Task<IActionResult> Details(int id)
		{
			var item = await _itemApi.GetAsync(id);

			// item.TrailerURL = item.TrailerURL.Replace("https://www.youtube.com/watch?v=", "https://www.youtube.com/embed/");

			return RedirectToAction("Details", "Home", item);
		}

		public async Task<IActionResult> Increment(Item item)
		{
			foreach (var b in _cartState.Basket.Where(b => b.Id == item.Id))
			{
				await _cartState.Increment(b);
			}

			return RedirectToAction("Index", "Cart");
		}

		public async Task<IActionResult> Decrement(Item item)
		{
			foreach(var b in _cartState.Basket.ToList().Where(b => b.Id == item.Id))
			{
				await _cartState.Decrement(b);
			}

			return RedirectToAction("Index", "Cart");
		}

		public async Task<ActionResult> Checkout() 
		{

			// update stock in Web Api
			await _cartState.UpdateStock();

			// start with a new List<Item> for a new basket
			_cartState.Basket = new List<Item>();

			return RedirectToAction("Index", "Cart");
		}
	}
}

