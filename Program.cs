using System;
using System.IO;

namespace SharpAseprite
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileStream = new FileStream("ase file.ase", FileMode.Open);
            var binaryReader = new BinaryReader(fileStream);
            var header = binaryReader.ReadBytes(128);

            var memoryStream = new MemoryStream(header);
            var headerReader = new BinaryReader(memoryStream);

            Console.WriteLine($"{headerReader.ReadUInt32()}"); // File Size - format FLI/FLC
            Console.WriteLine($"{headerReader.ReadUInt16()}"); // Magic Number
            Console.WriteLine($"{headerReader.ReadUInt16()}"); // Width pixels  
            Console.WriteLine($"{headerReader.ReadUInt16()}"); // Height pixels
            Console.WriteLine($"{headerReader.ReadUInt16()}"); // Color depth
            Console.WriteLine($"{headerReader.ReadUInt32()}"); // Flags
            Console.WriteLine($"{headerReader.ReadUInt16()}"); // Speed (Deprecated)
        }
    }
}
