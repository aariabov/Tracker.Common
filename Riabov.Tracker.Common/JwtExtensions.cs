using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Riabov.Tracker.Common;

public static class JwtExtensions
{
    public const string SecurityKey = "super secret key1";
    
    public static void AddJwtAuthentication(this IServiceCollection services)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey));
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(
                opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        RequireExpirationTime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });
    }
}