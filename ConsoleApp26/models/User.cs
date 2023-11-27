using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp26.models
{
    public class User
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? username { get; set; }
        public string? surname { get; set; }
        public string? password { get; set; }

        public string HashPassword()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
