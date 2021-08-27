using System.Security.Claims;

namespace API.Services.ClaimsExtensions
{
    public static class ClaimsPrincipleExtensions
    {
        public static string GetUsername(this ClaimsPrincipal claims)
         {
             return claims.FindFirst(ClaimTypes.Name)?.Value;
         }

         public static int GetUserId(this ClaimsPrincipal claims)
         {
             return int.Parse(claims.FindFirst(ClaimTypes.NameIdentifier)?.Value);
         }
    }
}