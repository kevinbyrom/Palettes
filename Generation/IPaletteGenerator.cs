using System;


namespace Palettes.Generation
{
    public interface IPaletteGenerator
    {
        Palette Generate(string name);
    }
}
