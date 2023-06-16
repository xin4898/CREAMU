using Microsoft.AspNetCore.Mvc;

namespace m0611.Controllers
{
    public class sesstiontest : Controller
    {
        public IActionResult Index()
        {
            // 设置会话数据
            HttpContext.Session.SetString("KeyName", "Value");

            // 获取会话数据
            string value = HttpContext.Session.GetString("KeyName");

            //// 删除会话数据
            //HttpContext.Session.Remove("KeyName");

            //// 清除所有会话数据
            //HttpContext.Session.Clear();


            return View(value);
        }
    }
}
