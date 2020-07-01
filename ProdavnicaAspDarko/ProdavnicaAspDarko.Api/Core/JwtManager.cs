using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProdavnicaAspDarko.Api.Core
{
    public class JwtManager
    {
        private readonly ProdavnicaAspDarkoContext _context;

        public JwtManager(ProdavnicaAspDarkoContext context)
        {
            _context = context;
        }

        public string MakeToken(string email, string lozinka)
        {

            var user = _context.Klijenti.Include(u => u.KlijentUseCases)
                 .FirstOrDefault(x => x.Email == email && x.Lozinka == lozinka);

            if (user == null)
            {
                return null;
            }

            var actor = new JwtActor
            {
                Id = user.Id,
                AllowedUseCases = user.KlijentUseCases.Select(x => x.UseCaseId),
                Identity = user.Email
            };


            var issuer = "asp_api";
            var secretKey = "ThisIsMyVerySecretKey";
            var claims = new List<Claim> 
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iss, "asp_api", ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, issuer),
                new Claim("ActorData", JsonConvert.SerializeObject(actor), ClaimValueTypes.String, issuer)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddSeconds(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
