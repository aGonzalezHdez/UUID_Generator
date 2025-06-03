using System.Security.Cryptography;
using System.Text;
using Dodo.Primitives;

namespace UUID_Generator.Services;

public static class UUIDGenerator
{
    private static string dnsUUID { get; set; } = "6ba7b810-9dad-11d1-80b4-00c04fd430c8";
    public static Guid GenerateV4(string input)
    {
        using var sha1 = SHA1.Create();
        var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Se Modifican los bits para que cumpla con UUID versión 4
        hash[6] = (byte)((hash[6] & 0x0F) | 0x40); // versión 4
        hash[8] = (byte)((hash[8] & 0x3F) | 0x80); // variant RFC 4122

        var guidBytes = new byte[16];
        Array.Copy(hash, guidBytes, 16);

        return new Guid(guidBytes);
    }
    
    
    public static Guid GenerateV5(string name)
    {
        // Convierte el namespace en bytes (puede ser un GUID base como namespace)
        var namespaceGuid = Guid.Parse(dnsUUID);
        var namespaceBytes = namespaceGuid.ToByteArray();

        // Convierte el nombre en bytes
        var nameBytes = Encoding.UTF8.GetBytes(name);

        // Combina ambos usando LINQ
        var data = namespaceBytes.Concat(nameBytes).ToArray();

        // Hash con SHA1
        using (var sha1 = SHA1.Create())
        {
            var hash = sha1.ComputeHash(data);

            // Crea un nuevo GUID a partir del hash
            var newGuid = new byte[16];
            Array.Copy(hash, 0, newGuid, 0, 16);

            // Ajuste de versión y variante
            newGuid[6] = (byte)((newGuid[6] & 0x0F) | 0x50); // Version 5
            newGuid[8] = (byte)((newGuid[8] & 0x3F) | 0x80); // RFC 4122 variant

            return new Guid(newGuid);
        }
    }
}