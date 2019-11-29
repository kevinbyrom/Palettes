using System;
using System.Collections.Generic;
using Palettes.Utilities;


namespace Palettes.Generation
{
    public class MatrixColors : IColorStrategy
    {
        public int NumEntriesPerSet { get; set; }
        public PaletteColor[] RootColors { get; set; }
        
        public MatrixColors(int numEntriesPerSet, PaletteColor[] rootColors)
        {
            this.NumEntriesPerSet = numEntriesPerSet;
            this.RootColors = rootColors;
        }


        public IEnumerable<PaletteColor> GetColors()
        {
            var colors = new List<PaletteColor>();

            for (int x = 0; x < this.RootColors.Length; x++)
            {
                for (int y = 0; y < this.RootColors.Length; y++)
                {
                    if (x == y)
                        continue;

                    colors.AddRange(GradientColors.Create(this.NumEntriesPerSet, this.RootColors[x], this.RootColors[y]));
                }
            }

            return colors;
        }

        public static IEnumerable<PaletteColor> Create(int numEntriesPerSet, PaletteColor[] rootColors)
        {
            var strategy = new MatrixColors(numEntriesPerSet, rootColors);

            return strategy.GetColors();
        }
    }

    public static class MatrixExtension
    {
        public static Palette Matrix(this Palette palette, int numEntriesPerSet, PaletteColor[] rootColors)
        {           
            palette.Add(MatrixColors.Create(numEntriesPerSet, rootColors));

            return palette;
        }
    }
}
