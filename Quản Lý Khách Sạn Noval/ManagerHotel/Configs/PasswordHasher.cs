using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Web;

namespace ManagerHotel.Configs
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                var hash = new StringBuilder();
                foreach (byte b in hashedBytes)
                {
                    hash.Append(b.ToString("x2"));
                    //x là hệ cơ số 16, 2 ở đây là biểu diễn hệ 16 này thành 2 ký tự AB chẳng hạn
                }
                return hash.ToString();
            }
        }
    }
}