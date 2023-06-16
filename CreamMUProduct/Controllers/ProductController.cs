using CreamMUProduct.Models;
using CreamMUProduct.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CreamMUProduct.Controllers
{
    public class ProductController : Controller
    {
        //private IWebHostEnvironment _enviro = null;
        //public ProductController(IWebHostEnvironment p)
        //{
        //    _enviro = p;
        //}

        //產品選單(已組裝完成的產品)

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
            CreamMUTestDBContext db = new CreamMUTestDBContext();
            IEnumerable<TProduct> datas = null;
            if (string.IsNullOrEmpty(keyword))
            {
                datas = from p in db.TProducts
                        select p;
            }
            else
                datas = db.TProducts.Where(p => p.PName.Contains(keyword));
            return View(datas);
        }
        //產品細節頁面
        //public ActionResult ProductDetail(int? id)
        //{
        //    if (id == null)
        //        return RedirectToAction("ProductList");
        //    CreamMUTestDBContext db = new CreamMUTestDBContext();
        //    TProduct prod = db.TProducts.FirstOrDefault(p => p.ProductId == id);
        //    return View(prod);

        //}

        //加入購物車
        public ActionResult AddToCart(int? id)
        {
            //if (id == null)
            //    return RedirectToAction("ProductList");
            //ViewBag.FId = id;
            //return View();
            if (id == null)
                return RedirectToAction("ProductList");
            CreamMUTestDBContext db = new CreamMUTestDBContext();
            TProduct prod = db.TProducts.FirstOrDefault(p => p.ProductId == id);
            return View(prod);
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
            return RedirectToAction("ProductList");
        }
    }
}
