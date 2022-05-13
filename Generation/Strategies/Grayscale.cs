using System;
using System.Collections.Generic;
using Palettes.Utilities;


namespace Palettes.Generation
{
    public class GrayscaleColors : IColorStrategy
    {
        public int NumEntries { get; set; }
        
        public GrayscaleColors(int numEntries)
        {
            this.NumEntries = numEntries;
        }


        public IEnumerable<PaletteColor> GetColors()
        {
            if (this.NumEntries == 0)
                throw new InvalidOperationException("NumEntries must be greater than zero");

            var colors = new List<PaletteColor>();
            for (int i = 0; i < this.NumEntries; i++)
            {
                var step = 256 / this.NumEntries;

                colors.Add(new PaletteColor(i * step));
            }

            return colors.ToArray();
        }


        public static IEnumerable<PaletteColor> Create(int numEntries)
        {
            var strategy = new GrayscaleColors(numEntries);

            return strategy.GetColors();
        }
    }

    public static class GrayscaleExtension
    {
        public static Palette Grayscale(this Palette palette, int numEntries)
        {           
            palette.Add(GrayscaleColors.Create(numEntries));

            return palette;
        }
    }
}
