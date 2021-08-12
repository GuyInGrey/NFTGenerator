using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;

namespace NFTGenerator
{
    public static class Generator
    {
        private static List<Layer> LayerGenerators;
        static Generator()
        {
            LayerGenerators = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(Layer).IsAssignableFrom(t) && t != typeof(Layer))
                .OrderBy(t =>
                {
                    var a = (PriorityAttribute)t.GetCustomAttribute(typeof(PriorityAttribute));
                    return a is null ? 0 : a.Value;
                })
                .Select(l => (Layer)Activator.CreateInstance(l))
                .ToList();
        }

        public static byte[] Generate(int token/*, string walletAddress*/)
        {
            //var num = (int)(BigInteger.Parse(walletAddress[2..], NumberStyles.HexNumber) * (token + 1) % 65536);
            //var r = new Random(num);
            var r = new Random(token);


            var i = new Image<Rgba32>(1024, 1536);

            foreach (var l in LayerGenerators)
            {
                l.Apply(i, r);
            }

            using var m = new MemoryStream();
            i.Save(m, new PngEncoder());
            return m.ToArray();
        }
    }
}
