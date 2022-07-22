using Login.Interfaces;
using Login.Models;
using Login.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// JWT Token Authentiation Repository
/// </summary>
namespace Login.Service
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        #region Variable Declaration

        Dictionary<string, string> userRecords;
        private readonly IConfiguration configuration;
        private readonly FlightDbContext _db;

        #endregion

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="JWTManagerRepository" /> class.</summary>
        /// <param name="_configuration">The configuration.</param>
        /// <param name="db">The database.</param>
        public JWTManagerRepository(IConfiguration _configuration, FlightDbContext db)
        {
            configuration = _configuration;
            _db = db;
        }

        #endregion

        #region Public Methods

        /// <summary>Authenticates the specified users.</summary>
        /// <param name="users">The Logged user details</param>
        /// <param name="isRegister">True if it is registration mode else false</param>
        /// <returns>The Generated token</returns>
        public Tokens Authenticate(LoginViewModel users, bool isRegister)
        {
            if (isRegister)
            {
                if (_db.Logins.Any(x => x.UserName == users.UserName))
                {
                    return null;
                }

                Models.Login tbllogin = new Models.Login();
                tbllogin.UserName = users.UserName;
                tbllogin.Password = users.Password;
                _db.Logins.Add(tbllogin);
                _db.SaveChanges();
            }

            userRecords = _db.Logins.ToList().ToDictionary(x => x.UserName, x => x.Password);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            if (!userRecords.Any(x => x.Key == users.UserName && x.Value == users.Password))
            {
                return null;
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name,users.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }

        #endregion
    }
}
