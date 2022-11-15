using Microsoft.AspNetCore.Rewrite;

public class RedirectHostRule : IRule
{
    private readonly Uri mTargetUri;

    public RedirectHostRule(string url)
    {
        mTargetUri = new Uri(url);
    }

    public void ApplyRule(RewriteContext context)
    {
        var request = context.HttpContext.Request;
        
        // Console.WriteLine($"Host.Host: {context.HttpContext.Request.Host.Host}, Target.Host: {mTargetUri.Host}, Contain: {context.HttpContext.Request.Host.Host.Contains(mTargetUri.Host)}, {context.HttpContext.Request.Path}");
        // Console.WriteLine($"isSameFQDN: {isSameFQDN()}, isImage: {isImage()}, {context.HttpContext.Request.Path}");

        if(isSameFQDN())
            return;
        
        if(isImage())
        {
            context.Result = RuleResult.EndResponse;
            context.HttpContext.Response.StatusCode = StatusCodes.Status302Found;
            // context.HttpContext.Response.Headers.Location = $"https://cdn.origingaia.com/official/global{request.Path}";
            context.HttpContext.Response.Headers.Location = $"{mTargetUri}{request.Path}";
        }

        bool isImage() => request.Path.Value != null && request.Path.Value.Contains("images");

        bool isSameFQDN() => context.HttpContext.Request.Host.Host == mTargetUri.Host;
    }
}