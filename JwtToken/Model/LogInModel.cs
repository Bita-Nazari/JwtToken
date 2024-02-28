namespace JwtToken.Model
{
    public class LogInModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsRememberMe { get; set; }
        public string? Token { get; set; }
    }
}
