using JwtToken.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtToken.Repository
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config;
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = configuration;

        }
        public string GenerateJwtToken(string user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));

            var claims = new[]
            {
                new Claim("Email" ,user),


            };
            var token = new JwtSecurityToken(
                issuer: _config["Issuer"],
                audience: _config["Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenstring;
        }

        public async Task<LogInModel> Login(LogInModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                throw new NullReferenceException();

            }
            model.Token = GenerateJwtToken(model.Email);
            var resault = await _userManager.CheckPasswordAsync(user, model.Password);
            return model;
        }

        public async Task<User> RegisterNew(RegisterModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException("model is null");
            }
            if (model.Password != model.ConfirmPassword)
            {
                return await Task.FromException<User>(new ArgumentNullException("model", "passwords arent match"));
            }
            var user = new User
            {
                Email = model.Email,
                UserName = model.Email
            };
            var resault = await _userManager.CreateAsync(user, model.Password);
            return user;
        }
    }
}
