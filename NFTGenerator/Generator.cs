using System;
using System.IO;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;

namespace NFTGenerator
{
    public static class Generator
    {
        public static byte[] Generate(int token)
        {
            var i = new Image<Rgba32>(1024, 1024);
            var m = new MemoryStream();
            i.Save(m, new PngEncoder());
            return m.ToArray();
        }
    }
}
