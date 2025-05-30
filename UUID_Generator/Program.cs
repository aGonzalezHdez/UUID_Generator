using UUID_Generator.Services;

namespace UUID_Generator;

class Program
{
    static void Main(string[] args)
    {
        var generador = new UUIDGenerator();
        Console.WriteLine(generador.Generate("Hello, World!") );
        
    }
}