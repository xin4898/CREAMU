using CreamMUProduct.Models;
using CreamMUProduct.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CreamMUProduct.Controllers
{
    public class ShoppingController : Controller
    {
        public IActionResult CartView()
        {
            if (!HttpContext.Session.Keys.Contains(CDictionary.SK_PURCHASED_PRODUCTS_LIST))
                return RedirectToAction("List");

            string json = HttpContext.Session.GetString(CDictionary.SK_PURCHASED_PRODUCTS_LIST);
            List<CShoppingCartItem> cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);
            if (cart == null)
                return RedirectToAction("List");
            return View(cart);
        }
        public IActionResult List()
        {
            CreamMUTestDBContext db = new CreamMUTestDBContext();
            var datas = from c in db.TProducts
                        select c;
            return View(datas);
        }
        public ActionResult AddToCart(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            ViewBag.FId = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddToCart(CAddToCartViewModel vm)
        {
            CreamMUTestDBContext db = new CreamMUTestDBContext();
            TProduct prod = db.TProducts.FirstOrDefault(t => t.ProductId == vm.txtFId);
            if (prod != null)
            {
                string json = "";
                List<CShoppingCartItem> cart = null;
                if (HttpContext.Session.Keys.Contains(CDictionary.SK_PURCHASED_PRODUCTS_LIST))
                {
                    json = HttpContext.Session.GetString(CDictionary.SK_PURCHASED_PRODUCTS_LIST);
                    cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);
                }
                else
                    cart = new List<CShoppingCartItem>();
                CShoppingCartItem item = new CShoppingCartItem();
                item.price = (decimal)prod.PPrice;
                item.productId = vm.txtFId;
                item.count = vm.txtCount;
                item.product = prod;
                cart.Add(item);
                json = JsonSerializer.Serialize(cart);
                HttpContext.Session.SetString(CDictionary.SK_PURCHASED_PRODUCTS_LIST, json);
            }
            return RedirectToAction("List");
        }
    }
}
