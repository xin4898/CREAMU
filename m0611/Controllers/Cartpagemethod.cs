using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using m0611.Gvariable;
using m0611.Models;

namespace m0611.Controllers
{

    public class Cartpagemethod : Controller
    {
        private readonly endtest0611Context econtext;



        public string test_add_temp_orderdetail_to_json()
        {

            //find max id找出最大id 之後可以做加減
            PurchaseGVariable._Order_max_id = econtext.TempOrderDetails.Max(maxid => maxid.OrderDetailId);

            //輸出測試
            return PurchaseGVariable._Order_max_id.ToString();
        }

        

    }
}
