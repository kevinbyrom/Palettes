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

            return new PaletteColor[] {
                new PaletteColor(0),
                new PaletteColor(64),
                new PaletteColor(128),
                new PaletteColor(255)
            };
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
