using CleanArchMvc.API.Models;
using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tokencontroller : ControllerBase
    {
        private readonly IAuthenticate _authentication;
        private readonly IConfiguration _configuration;

        public tokencontroller(IAuthenticate authentication, IConfiguration configuration)
        {
            _authentication = authentication ?? throw new ArgumentNullException(nameof(authentication));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [HttpPost("CreateUser")]
        //[ApiExplorerSettings(IgnoreApi =true)]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> CreateUser([FromBody] LoginModel userInfo)
        {
            // "usuario@localhost"
            // "Numsey#2021"
            var result = await _authentication.RegisterUser(userInfo.Email, userInfo.Password);
            if(result)
            {
                return Ok($"User {userInfo.Email} was create successfully");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attemp.");
                return BadRequest(ModelState);
            }
        }

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userInfo)
        {
            // "usuario@localhost"
            // "Numsey#2021"
            var result = await _authentication.Authenticate(userInfo.Email, userInfo.Password);
            if (result)
            {
                return GenereteToken(userInfo);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attemp.");
                return BadRequest(ModelState);
            }
        }
        private UserToken GenereteToken(LoginModel userInfo)
        {
            //declaração do usuario
            var clains = new[]
            {
                new Claim("email", userInfo.Email),
                new Claim("meuvalor", "MeuValorChave"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            //gerando chave privada para assinar o token
            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            //gerar assinatura digital do token
            var credential = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256 );

            //tempo de expiracao do token
            var expiration = DateTime.UtcNow.AddMinutes(10);

            //gera token
            JwtSecurityToken token = new JwtSecurityToken(
                
                //emissor
                issuer: _configuration["Jwt:Issuer"],
                
                //audiencia
                audience: _configuration["Jwt:Audience"],
                
                //claims
                claims: clains,

                //data expiracao 10 minutos, pos criacao
                expires: expiration,

                //assinatura digital
                signingCredentials: credential
                );

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
