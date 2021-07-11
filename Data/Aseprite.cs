using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SharpAseprite.Data
{
    public class Aseprite
    {
        public readonly Header header;

        public Aseprite(Stream stream)
        {
            var reader = new BinaryReader(stream);
            var bytes = reader.ReadBytes(128);

            header = new Header(bytes);
        }

        public override string ToString()
        {
            return header.ToString();
        }
    }
}
