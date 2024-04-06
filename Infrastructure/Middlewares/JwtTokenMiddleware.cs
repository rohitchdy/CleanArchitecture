using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Middlewares;

public class JwtTokenMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IWebHostEnvironment _env;

    public JwtTokenMiddleware(RequestDelegate next, IWebHostEnvironment env)
    {
        _next = next;
        _env = env;
    }

    public async Task Invoke(HttpContext context)
    {
        if (_env.IsDevelopment())
        {
            string token = context.Session.GetString("JWTToken");

            if (!string.IsNullOrEmpty(token))
            {
                context.Request.Headers.Append("Authorization", "Bearer " + token);
            }
        }

        await _next(context);
    }
}
