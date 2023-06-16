using m0611.Gvariable;
using m0611.Models;
using m0611.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace m0611.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly endtest0611Context econtext;

        public HomeController(ILogger<HomeController> logger, endtest0611Context context)
        {
            _logger = logger;
            this.econtext = context;
        }

        //session測試失敗
        //public IActionResult s()
        //{
        //    // 设置会话数据
        //    HttpContext.Session.SetString("KeyName", "Value");

        //    // 获取会话数据
        //    string value = HttpContext.Session.GetString("KeyName");
        //    ViewBag.Value = value;

        //    return View(value);
        //}


        // cart page
        [HttpGet]
        public async Task<IActionResult> cart1()
        {
            var cartlist = await econtext.TempOrderDetails.ToListAsync();

            //TOTAL加減
            int tempt = 0;
            foreach (var cart in cartlist)
            {
                tempt += Convert.ToInt32(cart.Subtotal);
            }
            //VALUE TO VIEWBAG
            ViewBag.Cart = Convert.ToString(tempt);

            return View(cartlist);
        }

        //save order and orderdetail data
        [ValidateAntiForgeryToken]
        public string save_order_and_orderdetail_data()
        {
            //find ORDER max id找出最大id 之後可以做加減
            PurchaseGVariable._Order_max_id = econtext.Orders.Max(maxid => maxid.OrderId);
            PurchaseGVariable._Order_max_id++;
            //find ORDERDETAIL max id找出最大id 之後可以做加減
            PurchaseGVariable._OrderDetail_max_id = econtext.OrderDetails.Max(maxid => maxid.OrderDetailId);
            PurchaseGVariable._OrderDetail_max_id++;

            //檢查是否成功的變數
            var checkcartpagevariable = new int();
            //新的order class 等等要存入資料固的order temp
            Order neworder = new Order();
            neworder = new Order()
            {
                OrderId = PurchaseGVariable._Order_max_id,
                EmployeeId = 1,
                MemberId = 1,
                OrderDate = System.DateTime.Now,
                TotalAmount = 123,
                OrderStatus = "0",
                PaymentStatus = "0",
                ShippingAddressId = null,
                OrderNotes = null
            };

            //temporderdetail to orderdetail
            foreach (var classtemp in econtext.TempOrderDetails)
            {
                //把每筆TEMPORDERDETAIL站存至ORDERDETAIL
                //有些數值需轉換就轉換
                OrderDetail newtempoderdetail = new OrderDetail()
                {
                    OrderDetailId = PurchaseGVariable._OrderDetail_max_id,
                    OrderId = PurchaseGVariable._Order_max_id,
                    ProductId = classtemp.ProductId,
                    Qty = classtemp.Qty,
                    UnitPrice = classtemp.UnitPrice,
                    Discount = classtemp.Discount,
                    Subtotal = classtemp.Subtotal,
                    Notes = classtemp.Notes
                };
                //照資料庫結構DETAIL是要一直加一的
                PurchaseGVariable._OrderDetail_max_id++;
                //加入剛剛轉換完成的ORDERDETAIL
                econtext.Add(newtempoderdetail);
            }

            //SAVE DATABASE CHANGE
            if (ModelState.IsValid)
            {
                econtext.Add(neworder);
                econtext.SaveChanges();
            }

            //cookie 
            //string temps = System.Text.Json.JsonSerializer.Deserialize(
            //Response.Cookies["testaddclasscook"]);

            //if (Request.Cookies.TryGetValue("testaddclasscook", out string cookiestrtemp))
            //{
            //    TempOrderDetail todtemp = (System.Text.Json.JsonSerializer.Deserialize(cookiestrtemp);

            //}
            //TempOrderDetail todtemp = new(System.Text.Json.JsonSerializer.Deserialize(Response.Cookies[""]));

            //輸出測試
            return PurchaseGVariable._Order_max_id.ToString() + " " +
                PurchaseGVariable._OrderDetail_max_id.ToString() + " " +
                Convert.ToString(checkcartpagevariable);
        }


        //postaddress page 
        public IActionResult postaddresspage()
        {
            //ViewBag["cartpaysuccesmessage"] = tojsontest();

            //let temp orderdetail data to order and orderdetail data
            save_order_and_orderdetail_data();



            


            //var postaddress = econtext.OrderDetails.Where(
            //    temp => temp.OrderId == PurchaseGVariable._Order_max_id)
            //    .ToList();

            //var postaddress1 = econtext.OrderDetails.ToList();
            //var post

            //var postaddress3 = 

            //postaddress = from OrderDetail in econtext.OrderDetails
            //              where OrderDetail.OrderId == PurchaseGVariable._Order_max_id
            //              select OrderDetail. ;
            return View();
        }


        //postpage button method
        [HttpPost]
        public IActionResult PostAddressCreate(PostAddress papostaddress)
        {


            //load member address dat
            //判斷是否null如果沒執就設成一
            var hasData = econtext.PostAddresses.Any();
            if (hasData)
            {
                PurchaseGVariable._PostAddress_max_id = econtext.PostAddresses.Max(
                    maxid => maxid.AddressId);
                PurchaseGVariable._PostAddress_max_id++;
            }
            else
            {
                PurchaseGVariable._PostAddress_max_id = 1;
            }

            //save postaddress data
            if (ModelState.IsValid)
            {
                //maunal input data
                papostaddress.AddressId = PurchaseGVariable._PostAddress_max_id;
                econtext.Add(papostaddress);
                econtext.SaveChanges();

            }
            else {
                //maunal input data
                papostaddress.AddressId = PurchaseGVariable._PostAddress_max_id;
                papostaddress.MemberId = 1;
                papostaddress.AddressType = "2";
                papostaddress.RecipientName = "david";
                papostaddress.Address = "none";
                papostaddress.City = "k";
                papostaddress.Country = "t";
                papostaddress.PostalCode = "1";
                papostaddress.PhoneNumber = "09";
                papostaddress.IsDefault = false;
                papostaddress.Notes = null;
                econtext.Add(papostaddress);
                econtext.SaveChanges();
            }

            return RedirectToAction("paymentpage");
        }

        public IActionResult paymentpage()
        {
            ViewBag.paymentpagetest = PurchaseGVariable._PostAddress_max_id;


            return View();
        }



        /*
            public async Task<IActionResult> Create([Bind("Fid,Fname,Total")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }
        */






        //異步處理
        //預覽全部會員資料
        [HttpGet]
        public async Task<IActionResult> pp()
        {
            var person = await econtext.OrderDetails.ToListAsync();
            return View(person);
        }

        //正常處理會有體感loading
        //預覽全部會員資料
        [HttpGet]
        public IActionResult pp1()
        {
            var person = econtext.Orders.ToList();
            return View(person);
        }



        //        using (var dbContext = new YourDbContext())
        //{
        //// 新增資料
        //YourEntity entity = new YourEntity
        //{
        //    Name = "Example",
        //    // 設定其他屬性的值
        //};
        //    dbContext.YourEntities.Add(entity);

        //// 更新資料
        //entity.Name = "Updated Name";
        //dbContext.Entry(entity).State = EntityState.Modified;

        //// 刪除資料
        //dbContext.YourEntities.Remove(entity);

        //// 儲存變更到資料庫
        //dbContext.SaveChanges();
        //}


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }






    }
}