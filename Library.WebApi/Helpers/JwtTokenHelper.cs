//using Library.WebApi.JwtOptions;
//using Library.WebApi.Services;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;

//namespace Library.WebApi.Helpers
//{
//    public static class JwtTokenHelper
//    {
//        public static IServiceCollection AddJwtToken(this IServiceCollection services, ConfigurationManager configuration)
//        {
//            var authOptions = configuration.GetSection(nameof(AuthSettings));
//            services.Configure<AuthSettings>(authOptions);

//            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authOptions[nameof(AuthSettings.SecretKey)]!));

//            var jwtAppSettingOptions = configuration.GetSection(nameof(JwtIssuerOptions));

//            var tokenValidationParameters = new TokenValidationParameters
//            {
//                ValidateIssuer = true,
//                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

//                ValidateAudience = true,
//                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

//                ValidateIssuerSigningKey = true,
//                IssuerSigningKey = signingKey,

//                RequireExpirationTime = true,
//                ValidateLifetime = true,
//                ClockSkew = TimeSpan.Zero
//            };

//            services.Configure<JwtIssuerOptions>(options =>
//            {
//                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
//                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
//                options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
//            });

//            services
//                .AddAuthentication(config =>
//                {
//                    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//                    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//                })
//                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
//                {
//                    options.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
//                    options.TokenValidationParameters = tokenValidationParameters;
//                    options.SaveToken = true;

//                    options.Events = new JwtBearerEvents
//                    {
//                        OnAuthenticationFailed = context =>
//                        {
//                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
//                            {
//                                context.Response.Headers.Add("Token-Expired", "true");
//                            }
//                            return Task.CompletedTask;
//                        }
//                    };
//                });

//            services.AddTransient<TokenProvider>();

//            services.AddTransient<AuthService>();

//            return services;
//        }
//    }
//}
