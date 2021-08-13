using System;

using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace NFTGenerator.Layers
{
    [Priority(1)]
    public class Pet : Layer
    {
        FontCollection collection;
        FontFamily family;

        public Pet()
        {
            collection = new FontCollection();
            family = collection.Install(@"C:\NFTGeneratorData\font.ttf");
        }

        public override void Apply(Image<Rgba32> image, Random rand, int token)
        {
            image.Mutate(x =>
            {
                var font = new Font(family, 128);
                x.DrawText(token.ToString(), font, Color.White, new PointF(10, 10));
            });
        }
    }
}
