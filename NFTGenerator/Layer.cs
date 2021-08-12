using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace NFTGenerator
{
    public class Layer
    {
        public virtual void Apply(Image<Rgba32> image, Random random) { }

        public static Image<Rgba32> LoadImage(string name) => 
            Image.Load<Rgba32>(@"C:\NFTGeneratorData\" + name.Replace("/", @"\"));

        public static List<Image<Rgba32>> LoadImages(string dirName) =>
            Directory.GetFiles(@"C:\NFTGeneratorData\" + dirName.Replace("/", @"\"))
                .Select(f => Image.Load<Rgba32>(f))
                .ToList();
    }
}
