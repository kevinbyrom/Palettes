using System;
using System.Collections.Generic;

namespace Palettes.Generation
{
    public interface IColorStrategy
    {
        IEnumerable<PaletteColor> GetColors();
    }
}
