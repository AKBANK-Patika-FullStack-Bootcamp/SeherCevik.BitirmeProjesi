using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SiteLibrary.Entities.Entities.Models;

namespace siteManagement.Helpers
{
    //kullanıcı bizim authorize kontrolü yaptığımız (authorize attribute) endpointlere istek attığında gönderdiği veriler bizim user sınıfımızla uyuşuğ uyuşmadığını kontrol etmek için yazdığımız sınıftır.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]

    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];
            if (user == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
