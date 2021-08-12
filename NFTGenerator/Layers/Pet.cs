using System;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace NFTGenerator.Layers
{
    [Priority(1)]
    public class Pet : Layer
    {
        public override void Apply(Image<Rgba32> image, Random rand)
        {

        }
    }
}
