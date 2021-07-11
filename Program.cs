using SharpAseprite.Data;
using System;
using System.IO;

namespace SharpAseprite
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileStream = new FileStream("ase file.ase", FileMode.Open);

            Aseprite aseprite = new Aseprite(fileStream);
            Console.WriteLine($"{aseprite}");
        }
    }
}
