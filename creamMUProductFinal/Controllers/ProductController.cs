using creamMUProductFinal.Models;
using creamMUProductFinal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace creamMUProductFinal.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult CartView()
        {
            if (!HttpContext.Session.Keys.Contains(CDictionary.SK_PURCHASED_PRODUCTS_LIST))
                return RedirectToAction("ProductList");

            string json = HttpContext.Session.GetString(CDictionary.SK_PURCHASED_PRODUCTS_LIST);
            List<CShoppingCartItem> cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);
            if (cart == null)
                return RedirectToAction("ProductList");
            return View(cart);
        }

        public IActionResult ProductList(CKeywordViewModel vm)
        {
            string keyword = vm.txtKeyword;
            CreamUDBContext db = new CreamUDBContext();
            IEnumerable<Product> datas = null;
            if (string.IsNullOrEmpty(keyword))
            {
                datas = from p in db.Products
                        select p;
            }
            else
                datas = db.Products.Where(p => p.ProductName.Contains(keyword));
            return View(datas);
        }
        

        //加入購物車
        public ActionResult AddToCart(int? id)
        {
            //if (id == null)
            //    return RedirectToAction("ProductList");

            //return View();
            if (id == null)
                return RedirectToAction("ProductList");
            CreamUDBContext db = new CreamUDBContext();
            Product prod = db.Products.FirstOrDefault(p => p.ProductId == id);
            //ViewBag.FId = id;
            return View(prod);
        }
        [HttpPost]
        public ActionResult AddToCart(CAddToCartViewModel vm)
        {
            CreamUDBContext db = new CreamUDBContext();
            Product prod = db.Products.FirstOrDefault(t => t.ProductId == vm.txtFId);
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
                item.price = (decimal)prod.Price;
                item.productId = vm.txtFId;
                item.count = vm.txtCount;
                item.product = prod;
                cart.Add(item);
                json = JsonSerializer.Serialize(cart);
                HttpContext.Session.SetString(CDictionary.SK_PURCHASED_PRODUCTS_LIST, json);
            }
            return RedirectToAction("ProductList");
        }
    }
}
