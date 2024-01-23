using Fuen31Site.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Fuen31Site.Controllers
{
    public class ApiController : Controller
    {
        private readonly MyDbContext _dbContext;
        public ApiController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            Thread.Sleep(5000);
            //return Content("Hello, world");
            //return Content("<h2>Hello, content</h2>", "text/html");
            return Content("<h2>你好, content</h2>", "text/plain", System.Text.Encoding.UTF8);
        }
        public IActionResult Cities()
        {
            var cities = _dbContext.Addresses.Select(a => a.City).Distinct();
            return Json(cities);
        }
        public IActionResult Distirct(string city)
        {
            var districts = _dbContext.Addresses.Where(a => a.City == city).Select(a => a.SiteId).Distinct();
            return Json(districts);
        }
        public IActionResult Address()
        {
            return View();
        }
        public IActionResult Avatar(int id = 1) 
        {
            Member? member = _dbContext.Members.Find(id);

            if (member != null) 
            {
                byte[] img = member.FileData;
                return File(img, "image/jpeg");

            }
            return NotFound();
        }
        public IActionResult CheckAccountAction(string name)
        {
            bool isExisted = _dbContext.Members.Any(n => n.Name == name);
            if(isExisted)
            {
                return Content("帳號已存在", "text/plain", System.Text.Encoding.UTF8);
            }
            return Content("帳號可使用", "text/plain", System.Text.Encoding.UTF8);
        }
    
    

        public IActionResult Register(string name, int age = 26) 
        { 
            if(string.IsNullOrEmpty(name))
            {
                name = "Guest";
            }
            return Content($"Hello，{name}，你已經 {age} 了 ");
        }
    }
}
