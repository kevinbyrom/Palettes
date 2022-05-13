using System;
using System.Collections.Generic;


namespace Palettes
{
    public class Palette
    {
        public string Name { get; set; }
        public List<PaletteColor> Colors = new List<PaletteColor>();

        public Palette(string name)
        {
            this.Name = name;
        }

        public void Add(PaletteColor color)
        {
            if (!this.Colors.Contains(color))
                this.Colors.Add(color);
        }

        public void Add(Palette pallete)
        {
            foreach (var color in pallete.Colors)
                Add(color);
        }

        public void Add(IEnumerable<PaletteColor> colors)
        {
            this.Colors.AddRange(colors);
        }
    }
}
