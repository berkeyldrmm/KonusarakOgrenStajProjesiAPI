using Microsoft.AspNetCore.Mvc;

namespace KonusarakOgrenStajProjesiAPI.Authentication
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute()
            : base(typeof(ApiKeyAuthorizationFilter))
        {
        }
    }
}
