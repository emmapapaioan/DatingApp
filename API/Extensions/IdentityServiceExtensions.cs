using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration config)
        {
            // Configures authentication services to use JWT bearer tokens as the default scheme for authentication.
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            // Add a JWT bearer authentication handler to the pipeline and provide options to configure it.
            .AddJwtBearer(options =>
            {
                // Creates a new instance of TokenValidationParameters to configure token validation parameters.
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true, // Enable the validation of the token's issuer signing key.
                                                     // Set the security key used to validate the token's signature.
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding
                        .UTF8.GetBytes(config["TokenKey"])),
                    ValidateIssuer = false, // Disables the validation of the token's issuer.
                    ValidateAudience = false // Disable the validation of the token's audience.
                };
            });

            return services;
        }
    }
}