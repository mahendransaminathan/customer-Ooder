public class LoginResponse
{
    public string Token { get; set; }
    public string Username { get; set; }

    public DateTime Expiration { get; set; } // token expiration time
    
    public string Role { get; set; }          // user role, if you include it in JWT

    public bool IsAuthenticated { get; set; }    
}