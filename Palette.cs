using System;
using System.Collections.Generic;


namespace Palettes
{
    public class Palette
    {
        public string Name { get; set; }
        public List<PaletteColor> Colors => new List<PaletteColor>();

        public Palette(string name)
        {
            this.Name = name;
        }
    }
}
