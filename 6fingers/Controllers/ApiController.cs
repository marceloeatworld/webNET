using _6fingers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _6fingers.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class ApiController : Controller
    {
        private readonly _6fingers.Data.DataContext _context;

        public ApiController(_6fingers.Data.DataContext context)
        {
            _context = context;
        }
        public IList<Product> Product { get; set; }


        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            Product = await _context.Products.ToListAsync();

            return Json(Product);
        }


    }
}



