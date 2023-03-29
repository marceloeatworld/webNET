using _6fingers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace _6fingers.Pages
{
    public class HomeProductsModel : PageModel
    {
		private readonly Data.DataContext _context;

		public HomeProductsModel(Data.DataContext context)
		{
			_context = context;
		}

		public IList<Product> Product { get; set; }

		public async Task OnGetAsync()
		{
			Product = await _context.Products.ToListAsync();
		}
	}
}
