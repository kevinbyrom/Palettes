using System;
using System.Collections.Generic;
using Palettes.Utilities;


namespace Palettes.Generation
{
    public class GradientColors : IColorStrategy
    {
        public PaletteColor StartColor { get; set; }
        public PaletteColor EndColor { get; set; }
        public int NumEntries { get; set; }
        
        public GradientColors(int numEntries, PaletteColor startColor, PaletteColor endColor)
        {
            this.StartColor = startColor;
            this.EndColor = endColor;
            this.NumEntries = numEntries;
        }


        public IEnumerable<PaletteColor> GetColors()
        {
            var colors = new List<PaletteColor>();

            for (int i = 0; i < this.NumEntries; i++)
            {
                int red = Interpolation.Linear(StartColor.Red, EndColor.Red, (float)i / (this.NumEntries));
                int green = Interpolation.Linear(StartColor.Green, EndColor.Green, (float)i / (this.NumEntries));
                int blue = Interpolation.Linear(StartColor.Blue, EndColor.Blue, (float)i / (this.NumEntries));

                colors.Add(new PaletteColor(red, green, blue));
            }

            return colors;
        }

        public static IEnumerable<PaletteColor> Create(int numEntries, PaletteColor startColor, PaletteColor endColor)
        {
            var strategy = new GradientColors(numEntries, startColor, endColor);

            return strategy.GetColors();
        }
    }


    public static class GradientExtension
    {
        public static Palette Grayscale(this Palette palette, int numEntries, PaletteColor startColor, PaletteColor endColor)
        {           
            palette.Add(GradientColors.Create(numEntries, startColor, endColor));

            return palette;
        }
    }
}
