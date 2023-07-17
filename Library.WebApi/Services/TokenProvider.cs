using Library.WebApi.JwtOptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library.WebApi.Services;

public class TokenProvider
{
    private readonly JwtIssuerOptions _jwtOptions;
    private readonly AuthSettings _authSettings;

    public TokenProvider(IOptions<JwtIssuerOptions> jwtOptions, IOptions<AuthSettings> authSettings) =>
        (_jwtOptions, _authSettings) = (jwtOptions.Value, authSettings.Value);

    public string CreateToken(IdentityUser user)
    {
        var token = CreateJwtToken(
            CreateClaims(user),
            CreateSigningCredentials()
        );

        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(token);
    }

    private JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials) =>
        new(_jwtOptions.Issuer, _jwtOptions.Audience, claims, null, _jwtOptions.Expiration, credentials);

    private List<Claim> CreateClaims(IdentityUser user) =>
        new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName)
        };

    private SigningCredentials CreateSigningCredentials() =>
        new(
            new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_authSettings.SecretKey)
            ),
            SecurityAlgorithms.HmacSha256
        );
}
