using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Webshop.Model;
using Webshop.Sdk;
using Webshop.UI.Mvc.Models;

namespace Webshop.UI.Mvc.Controllers
{
	public class HomeController : Controller
	{
		private readonly ItemApi _itemApi;
		private readonly CartState _cartState;

		public HomeController(ItemApi itemApi, CartState cartState)
		{
			_itemApi = itemApi;
			_cartState = cartState;
		}

		public async Task<IActionResult> Index()
		{
			var items = await _itemApi.FindAsync();

			return View(items);
		}

		public async Task<IActionResult> Details(int id)
		{
			var item = await _itemApi.GetAsync(id);

			item.TrailerURL = item.TrailerURL.Replace("https://www.youtube.com/watch?v=", "https://www.youtube.com/embed/");

			return View(item);
		}

		[HttpPost]
		public async Task<IActionResult> Buy(Item item)
		{
			await _cartState.AddItemToBasket(item);

			return RedirectToAction("Index");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
