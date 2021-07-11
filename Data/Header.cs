using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SharpAseprite.Data
{
    public class Header
    {
        public readonly uint FileSize;
        public readonly ushort MagicNumber;
        public readonly ushort Frames;
        public readonly ushort Width;
        public readonly ushort Height;
        public readonly ColorDepth ColorDepth;
        public readonly uint Flags;
        public readonly ushort Speed;
        public readonly byte PalleteEntry;
        public readonly ushort NumberOfColors;
        public readonly byte PixelWidth;
        public readonly byte PixelHeight;
        public readonly short GridPositionX;
        public readonly short GridPositionY;
        public readonly ushort GridWidth;
        public readonly ushort GridHeight;

        public Header(byte[] bytes)
        {
            var stream = new MemoryStream(bytes);
            var reader = new BinaryReader(stream);

            FileSize = reader.ReadUInt32();                 // File size - format FLI/FLC
            MagicNumber = reader.ReadUInt16();              // Magic number (0xA5E0)
            Frames = reader.ReadUInt16();                   // Frames
            Width = reader.ReadUInt16();                    // Width in pixels
            Height = reader.ReadUInt16();                   // Height in pixels
            ColorDepth = (ColorDepth)reader.ReadUInt16();   // Color depth (bits per pixel)
            Flags = reader.ReadUInt32();                    // Flags : 1 = Layer opacity has valid value
            Speed = reader.ReadUInt16();                    // DEPRECATED: You should use the frame duration field from each frame header

            reader.ReadUInt32();                            // Set to be 0
            reader.ReadUInt32();                            // Set to be 0

            PalleteEntry = reader.ReadByte();               // Palette entry (index) which represent transparent color in all non-background layers(only for Indexed sprites).
            reader.ReadBytes(3);                            // Ignore these bytes

            NumberOfColors = reader.ReadUInt16();           // Number of colors (0 means 256 for old sprites)

            PixelWidth = reader.ReadByte();                 // Pixel width (pixel ratio is "pixel width/pixel height"). If this or pixel height field is zero, pixel ratio is 1:1
            PixelHeight = reader.ReadByte();                // Pixel height

            GridPositionX = reader.ReadInt16();             // X position of the grid
            GridPositionY = reader.ReadInt16();             // Y position of the grid
            GridWidth = reader.ReadUInt16();                // Grid width (zero if there is no grid, grid size is 16x16 on Aseprite by default)
            GridHeight = reader.ReadUInt16();               // Grid height (zero if there is no grid)

            reader.ReadBytes(84);                           // For future (set to zero)
        }

        public override string ToString()
        {
            return $"FileSize : {FileSize}\n" +
                $"MagicNumber : {MagicNumber}\n" +
                $"Frames : {Frames}\n" +
                $"Width : {Width}\n" +
                $"Height : {Height}\n" +
                $"ColorDepth : {ColorDepth}\n" +
                $"Flags : {Flags}\n" +
                $"Speed : {Speed}\n" +
                $"PalleteEntry : {PalleteEntry}\n" +
                $"NumberOfColors : {NumberOfColors}\n" +
                $"PixelWidth : {PixelWidth}\n" +
                $"PixelHeight : {PixelHeight}\n" +
                $"GridPositionX : {GridPositionX}\n" +
                $"GridPositionY : {GridPositionY}\n" +
                $"GridWidth : {GridWidth}\n" +
                $"GridHeight : {GridHeight}";
        }
    }
}
