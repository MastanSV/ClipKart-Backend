using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ClipKart.Core.Constants;
using ClipKart.Core.Interfaces.Common;
using Microsoft.IdentityModel.Tokens;

namespace ClipKart.Core.Helpers.Common
{
    public class JWTTokenGenerator : IJWTTokenGenerator
    {
        private IConfiguration _configuration;

        public JWTTokenGenerator(IConfiguration configuratin)
        {
            _configuration = configuratin;
        }

        public string Generate(string userId, string role)
        {
            var jwtSettings = _configuration.GetSection(AppConfigurationConstants.JWTSettingsSection);

            var jwtSecretKey = Environment.GetEnvironmentVariable(EnvironementVariables.JWTSecretKey);

            if (jwtSecretKey == null)
            {
                throw new ArgumentNullException($"{nameof(jwtSecretKey)} is null. {nameof(jwtSecretKey)} has to be as a Env variable.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };


            var token = new JwtSecurityToken(
                    issuer: jwtSettings[AppConfigurationConstants.JWTIssuer],
                    audience: jwtSettings[AppConfigurationConstants.JWTAudience],
                    expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings[AppConfigurationConstants.JWTExpiryInMinutes])),
                    claims: claims,
                    signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
