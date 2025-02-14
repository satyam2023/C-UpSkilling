using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApis.Constant.StringConstant;

namespace WebApis.Helpers
{
    public static class UserAuthorizationHelper
    {

        public static IActionResult? ValidateUserAuthorization(HttpContext context, int userDataId)
        {
            var userIdFromToken = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userIdFromToken == null)
            {
                return new UnauthorizedObjectResult(new { message = StringConstant.userIdNotFound });
            }

            if (userDataId.ToString() != userIdFromToken)
            {
                return new UnauthorizedObjectResult(new { message = StringConstant.cannotAccessUserData });
            }

            return null; 
        }
    }
}
