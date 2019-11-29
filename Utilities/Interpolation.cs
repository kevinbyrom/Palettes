using System;
using System.IO;


namespace Palettes.Utilities
{
    public static class Interpolation
    {
        public static int Linear(int minVal, int maxVal, float pct)
        {
            return (int)(minVal + ((float)(maxVal - minVal) * pct));
        }
    }
}
