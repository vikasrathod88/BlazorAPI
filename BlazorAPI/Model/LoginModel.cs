using System.ComponentModel;

namespace BlazorAPI.Model
{
    public class LoginModel
    {
    
        public string UserName { get; set; }

        public string Password { get; set; } = null;
    }
}
