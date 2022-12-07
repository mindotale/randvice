using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Randvice.Core.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Randvice.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtSettings _jwtSettings;

    public IdentityService(UserManager<IdentityUser> userManager, JwtSettings jwtSettings)
    {
        _userManager = userManager;
        _jwtSettings = jwtSettings;
    }

    public async Task<AuthenticationCredentials> LoginAsync(
        LoginUserCommand command,
        CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(command.Email);
        if (user is null)
        {
            throw new NotImplementedException();
        }

        var passwordIsValid = await _userManager.CheckPasswordAsync(user, command.Password);
        if (!passwordIsValid)
        {
            throw new NotImplementedException();
        }

        return new AuthenticationCredentials(GetJwt(user));
    }

    private string GetJwt(IdentityUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim("id", user.Id)
        };
        var keyBytes = Encoding.UTF8.GetBytes(_jwtSettings.Key);
        var key = new SymmetricSecurityKey(keyBytes);
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var expirationTime = DateTime.UtcNow.Add(_jwtSettings.ExpirationTime);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            Expires = expirationTime,
            SigningCredentials = signingCredentials
        };

        var jwt = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(jwt);
    }
}
