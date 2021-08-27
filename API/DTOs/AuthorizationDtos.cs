namespace API.DTOs
{
    public class AuthorizedDto
    {
        public string Username { get; set; }
        public string Token { get; set; }
        
    }

    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterDto
    {
        public string  Username { get; set; }
        public string  Password { get; set; }
    }
}