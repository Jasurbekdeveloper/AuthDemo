using System.Security.Cryptography;
using System.Text;

namespace AuthDemo.Infrastructure.Audentification;

public class PasswordHasher
{
    private const int keySize = 32;
    private const int iterationCount = 1000;
    
    public string GenerationPassword(string salt, string password)
    {
        using (var algoritm = new Rfc2898DeriveBytes(
            password, Encoding.UTF8.GetBytes(salt),
            iterations: iterationCount,
        hashAlgorithm: HashAlgorithmName.SHA256))

        {
            return Convert.ToBase64String(algoritm.GetBytes(keySize));
        }
    }

    public bool VerifyPassword(string salt, string password, string hash)
    {
        return GenerationPassword(salt, password).SequenceEqual(hash);
    }
}
