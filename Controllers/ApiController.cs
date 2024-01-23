using Fuen31Site.Models;
using Microsoft.AspNetCore.Mvc;

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
            //return Content("Hello, world");
            //return Content("<h2>Hello, content</h2>", "text/html");
            return Content("<h2>你好, content</h2>", "text/plain", System.Text.Encoding.UTF8);
        }
        public IActionResult Cities()
        {
            var cities = _dbContext.Addresses.Select(a => a.City).Distinct();
            return Json(cities);
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
    }
}
