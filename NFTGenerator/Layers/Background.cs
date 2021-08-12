using System;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace NFTGenerator.Layers
{
    [Priority(0)]
    public class Card : Layer
    {
        static Color[] Colors = new[]
        {
            new Color(new Rgba32(0, 0, 255)),
            new Color(new Rgba32(0, 255, 0)),
            new Color(new Rgba32(255, 0, 0)),
            new Color(new Rgba32(0, 0, 0)),
            new Color(new Rgba32(255, 255, 255)),
            new Color(new Rgba32(255, 0, 255)),
            new Color(new Rgba32(0, 255, 255)),
            new Color(new Rgba32(255, 255, 0)),
        };

        public override void Apply(Image<Rgba32> image, Random rand)
        {
            var backgrounds = LoadImages("backgrounds");
            var selected = backgrounds[rand.Next(backgrounds.Count)];

            selected.Mutate(x =>
            {
                if (rand.Next(2) == 0)
                {
                    x.Sepia();
                }
            });

            image.Mutate(x =>
            {
                x.DrawImage(selected, 1);
            });
        }
    }
}
