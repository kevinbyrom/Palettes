using System;
using Palettes.Generation;
using System.Linq;


namespace Palettes.Generation.Generators
{
    public class StandardGenerator : IPaletteGenerator
    {
        const int NUM_COLUMNS = 4;
        const int NUM_GENS = 2;

        public PaletteColor GradientTarget { get; set; }
        public PaletteColor? Tint { get; set; }

        public StandardGenerator(PaletteColor gradientTarget)
        {
            this.GradientTarget = gradientTarget;
        }

        public StandardGenerator(PaletteColor gradientTarget, PaletteColor tint)
        {
            this.GradientTarget = gradientTarget;
            this.Tint = tint;
        }


        public Palette Generate(string name)
        {
            var palette = new Palette(name);

            palette.Add(GrayscaleColors.Create(NUM_COLUMNS));

            palette.Add(GradientColors.Create(NUM_COLUMNS, PaletteColors.Red, this.GradientTarget));
            palette.Add(GenerationalColors.Create(NUM_COLUMNS, PaletteColors.Red, PaletteColors.Yellow, this.GradientTarget, NUM_GENS));

            palette.Add(GradientColors.Create(NUM_COLUMNS, PaletteColors.Yellow, this.GradientTarget));
            palette.Add(GenerationalColors.Create(NUM_COLUMNS, PaletteColors.Yellow, PaletteColors.Green, this.GradientTarget, NUM_GENS));

            palette.Add(GradientColors.Create(NUM_COLUMNS, PaletteColors.Green, this.GradientTarget));
            palette.Add(GenerationalColors.Create(NUM_COLUMNS, PaletteColors.Green, PaletteColors.Teal, this.GradientTarget, NUM_GENS));

            palette.Add(GradientColors.Create(NUM_COLUMNS, PaletteColors.Teal, this.GradientTarget));
            palette.Add(GenerationalColors.Create(NUM_COLUMNS, PaletteColors.Teal, PaletteColors.Blue, this.GradientTarget, NUM_GENS));

            palette.Add(GradientColors.Create(NUM_COLUMNS, PaletteColors.Blue, this.GradientTarget));           
            palette.Add(GenerationalColors.Create(NUM_COLUMNS, PaletteColors.Blue, PaletteColors.Purple, this.GradientTarget, NUM_GENS));

            palette.Add(GradientColors.Create(NUM_COLUMNS, PaletteColors.Purple, this.GradientTarget));           
            palette.Add(GenerationalColors.Create(NUM_COLUMNS, PaletteColors.Purple, PaletteColors.Red, this.GradientTarget, NUM_GENS));

            if (this.Tint != null)
            {
                palette.Colors = palette.Colors.Tint(this.Tint.Value);
            }

            return palette;
        }
    }
}
