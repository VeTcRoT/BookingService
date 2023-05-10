using BookingService.Api.Models.Auth;
using BookingService.Application.Exceptions;
using BookingService.Application.Interfaces.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookingService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHash _passwordHash;

        public AuthenticationController(IConfiguration configuration, IUnitOfWork unitOfWork, IPasswordHash passwordHash)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _passwordHash = passwordHash;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _unitOfWork.UserRepository.GetUserByEmailAsync(request.Email);

            if (user == null)
                throw new NotFoundException(nameof(User), request.Email);

            var isPasswordValid = _passwordHash.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt);

            if (!isPasswordValid)
                throw new BadRequestException("Incorrect password.");

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                },
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: signinCredentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new JWTTokenResponse
            {
                Token = tokenString
            });
        }
    }
}
