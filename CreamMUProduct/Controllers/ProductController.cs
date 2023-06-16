using CreamMUProduct.Models;
using CreamMUProduct.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult ProductDetail(int? id)
        {
            if (id == null)
                return RedirectToAction("ProductList");
            CreamMUTestDBContext db = new CreamMUTestDBContext();
            TProduct prod = db.TProducts.FirstOrDefault(p => p.ProductId == id);
            return View(prod);

        }

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //        return RedirectToAction("ProductList");
        //    CreamMUTestDBContext db = new CreamMUTestDBContext();
        //    TProduct prod = db.TProducts.FirstOrDefault(p => p.ProductId == id);
        //    return View(prod);
        //}
        //[HttpPost]
        //public ActionResult Edit(CProductWraper x)
        //{
        //    CreamMUTestDBContext db = new CreamMUTestDBContext();
        //    TProduct prod = db.TProducts.FirstOrDefault(p => p.ProductId == x.FId);
        //    if (prod != null)
        //    {
        //        if (x.photo != null)
        //        {
        //            string photoName = Guid.NewGuid().ToString() + ".jpg";
        //            x.photo.CopyTo(new FileStream(
        //                _enviro.WebRootPath + "/images/" + photoName,
        //                FileMode.Create));
        //            prod.PImages = photoName;
        //        }
        //        prod.PName = x.FName;
        //        prod.PTypeId = x.PTypeId;
        //        prod.PPrice = x.PPrice;
        //        prod.PInstock = x.PInstock;
        //        prod.PStatus = x.PStatus;
        //        prod.PStatus = x.PStatus;
        //        prod.PReleaseDate = x.PReleaseDate;
        //        prod.EmployeeId = x.EmployeeId;
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("ProductList");
        //}
    }
}
