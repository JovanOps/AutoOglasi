using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace AutoOglasi.Controllers
{
    public class LangController : Controller
    {
        public IActionResult Set(string c = "en", string? returnUrl = "/")
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(c)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
            return LocalRedirect(returnUrl ?? "/");
        }
    }
}
