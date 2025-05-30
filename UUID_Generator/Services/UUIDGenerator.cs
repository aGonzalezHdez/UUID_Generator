using System.Security.Cryptography;
using System.Text;

namespace UUID_Generator.Services;

public class UUIDGenerator
{
    public Guid Generate(string input)
    {
        using var sha256 = SHA256.Create();
        byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Modificar los bits para que cumpla con UUID versión 4 (como en Python)
        hash[6] = (byte)((hash[6] & 0x0F) | 0x40); // versión   4
        hash[8] = (byte)((hash[8] & 0x3F) | 0x80); // variant RFC 4122

        byte[] guidBytes = new byte[16];
        Array.Copy(hash, guidBytes, 16);

        return new Guid(guidBytes);
    }
}