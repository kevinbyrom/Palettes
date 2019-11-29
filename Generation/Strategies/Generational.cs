using System;
using System.Collections.Generic;
using Palettes.Utilities;


namespace Palettes.Generation
{
    public class GenerationalColors : IColorStrategy
    {
        public PaletteColor RootColor1 { get; set; }
        public PaletteColor RootColor2 { get; set; }
        public PaletteColor GradientTarget { get; set; }
        public int NumEntries { get; set; }
        public int NumGens { get; set; }
        
        public GenerationalColors(int numEntries, PaletteColor rootColor1, PaletteColor rootColor2, PaletteColor gradientTarget, int numGens)
        {
            this.RootColor1 = rootColor1;
            this.RootColor2 = rootColor2;
            this.GradientTarget = gradientTarget;
            this.NumEntries = numEntries;
            this.NumGens = numGens;
        }


        public IEnumerable<PaletteColor> GetColors()
        {
            var colors = new List<PaletteColor>();

            var child1 = PaletteColor.Linear(RootColor1, RootColor2, .25f);
            var child2 = PaletteColor.Linear(RootColor1, RootColor2, .75f);

            colors.AddRange(GradientColors.Create(this.NumEntries, child1, this.GradientTarget));

            if (this.NumGens > 1)
                colors.AddRange(GenerationalColors.Create(this.NumEntries, child1, child2, this.GradientTarget, this.NumGens - 1));

            colors.AddRange(GradientColors.Create(this.NumEntries, child2, this.GradientTarget));


            return colors;
        }


        public static IEnumerable<PaletteColor> Create(int numEntries, PaletteColor rootColor1, PaletteColor rootColor2, PaletteColor gradientTarget, int numGens)
        {
            var strategy = new GenerationalColors(numEntries, rootColor1, rootColor2, gradientTarget, numGens);

            return strategy.GetColors();
        }
    }


    public static class GenerationalExtension
    {
        public static Palette Generational(this Palette palette, int numEntries, PaletteColor rootColor1, PaletteColor rootColor2, PaletteColor gradientTarget, int numGens)
        {           
            palette.Add(GenerationalColors.Create(numEntries, rootColor1, rootColor2, gradientTarget, numGens));

            return palette;
        }
    }
}
