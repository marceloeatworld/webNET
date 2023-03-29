using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _6fingers.Data;
using _6fingers.Models;
using Microsoft.AspNetCore.Authorization;

namespace _6fingers.Pages.Admin.Products
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly _6fingers.Data.DataContext _context;

        public IndexModel(_6fingers.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
