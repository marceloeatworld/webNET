using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace _6fingers.Pages.Admin
{
    public class IndexModel : PageModel
    {

	    public bool DisplayMsgError = false;
		IConfiguration configuration;
		public IndexModel(IConfiguration configuration) 
		{
			this.configuration = configuration;
		}
        public IActionResult OnGet()
        {
			if (HttpContext.User.Identity.IsAuthenticated)
			{
				return Redirect("/Admin/Products");

			}
			return Page();
        }
		public async Task<IActionResult> OnPostAsync(string username, string password, string ReturnUrl)
		{
			var authSection = configuration.GetSection("Auth");
			string adminLogin = authSection["AdminLogin"];
			string adminPassword = authSection["AdminPassword"];


			if ((username == adminLogin) && (password == adminPassword))
			{
				DisplayMsgError = false;
				var claims = new List<Claim>
				{
				new Claim(ClaimTypes.Name, username)
				};
				var claimsIdentity = new ClaimsIdentity(claims, "Login");
				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new
				ClaimsPrincipal(claimsIdentity));
				return Redirect(ReturnUrl == null ? "/Admin/Products" : ReturnUrl);
			}
			DisplayMsgError = true;

			return Page();
		}

		public async Task<IActionResult> OnGetLogout()
		{
			await HttpContext.SignOutAsync();
			return Redirect("/Admin");
		}
	}
}
