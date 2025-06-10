using UUID_Generator.Services;

namespace UUID_Generator;

class Program
{
    static void Main(string[] args)
    {
        var dnsUUID = "6ba7b810-9dad-11d1-80b4-00c04fd430c8";
        //prueba de cambio
        var hAWB = "9056377013999";
        var idSdaEnvio = "2222103";
        var combined = hAWB + "&" + idSdaEnvio;
        //var combined = "test";
        
        Console.WriteLine($"Original string:{combined}");
        var uuidV4 = UUIDGenerator.GenerateV4(combined);
        Console.WriteLine($"UuidV4: {uuidV4}");
        
        var uuidV5 = UUIDGenerator.GenerateV5(combined);
        Console.WriteLine($"UuidV5: {uuidV5}");
    }
}
