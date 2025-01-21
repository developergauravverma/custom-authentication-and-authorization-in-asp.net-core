using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MyApp.CustomeToken;

namespace MyApp.Middleware;

public class CustomeAuthenticationFilter : Attribute, IAuthorizationFilter
{
    public async void OnAuthorization(AuthorizationFilterContext context)
    {
        var tokenManager = context.HttpContext.RequestServices.GetService(typeof(ITokenManager)) as ITokenManager;
        bool result = context.HttpContext.User.Claims.Any(x => x.Type.Equals("Authorization"));
        string? token = string.Empty;
        bool isVerified = await tokenManager.VerifyToken(token);
        if (result)
        {
            token = context.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type.Equals("Authorization"))?.Value;
            if(tokenManager is not null && token is not null && isVerified) result = false;
        }
        if(!result)
        {
            var CustomeViewResult = new ViewResult { ViewName = "_Error" };
            var modelMetadata = new EmptyModelMetadataProvider();
            CustomeViewResult.ViewData = new ViewDataDictionary(modelMetadata, context.ModelState);
            CustomeViewResult.ViewData.Add("HandleException", "Authentication token is expire Plz login again");
            context.Result = CustomeViewResult;
        }
    }
}