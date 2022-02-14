using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SiteLibrary.Entities.DTO;
using SiteLibrary.Entities.Entities.Models;
using siteManagement.DataAccess;
using siteManagement.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace siteManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //user ın apimiz ile token vasıtasıyla haberleşmek için giriş yapabişleceği token alabileceği kullanıcı bilgisini görüntüleyebileceği endpointleri yazdık.  
        Result<List<AutResponseDTO>> _result = new Result<List<AutResponseDTO>>();

        private readonly AppSettings _appSettings;
        private readonly AptDbContext _context;

        public LoginController(IOptions<AppSettings> appSettings, AptDbContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

      

        [HttpPost("login")]
        public AutResponseDTO Login(AutRequestDTO model)
        {
            var user = _context.user.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);
            // burada başarıyla giriş yapmış ve sistemde kayıtlı olan kullanıcıya kullanıcı bilgilerini dönmek için data taşıma amacıyla oluşturduğumuz autresponsedto sınıfımızdan bir nesne oluşturup kullanıcı bilgilerini bu nesneye atıp bu nesneyi de kullanıcıya döndük.
            var response = new AutResponseDTO()
            {
                Id = user.Id,
                FirstName = user.Name,
                LastName = user.SurName,
                UserName = user.Email,
                Token = token
            };

            return response;
        }
        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
