using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Primitives;

namespace Lombiq.AnalyzersTest
{
    /// <summary>
    /// Mimics https://github.com/Lombiq/Helpful-Libraries/blob/9edb4ac0e361839253b9b725eb7607e0ba25de85/Lombiq.HelpfulLibraries.AspNetCore/Security/ApplicationBuilderExtensions.cs.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Mimics https://github.com/Lombiq/Helpful-Libraries/blob/9edb4ac0e361839253b9b725eb7607e0ba25de85/Lombiq.HelpfulLibraries.AspNetCore/Security/ApplicationBuilderExtensions.cs#L128.
        /// </summary>
        public static IApplicationBuilder UseStrictAndSecureCookies(this IApplicationBuilder app)
        {
            return app.Use((context, next) =>
            {
                const string setCookieHeader = "Set-Cookie";
                context.Response.OnStarting(() =>
                {
                    var setCookie = context.Response.Headers[setCookieHeader];
                    var newCookies = new List<string>(capacity: setCookie.Count);
                    context.Response.Headers[setCookieHeader] = new StringValues(newCookies.ToArray());

                    return Task.CompletedTask;
                });

                return next();
            });
        }
    }
}
