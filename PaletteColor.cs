using System;
using System.Collections.Generic;
using Palettes.Utilities;


namespace Palettes
{
    public static class PaletteColors
    {
        public static PaletteColor Black = new PaletteColor(0);
        public static PaletteColor White = new PaletteColor(255);
        public static PaletteColor Red = new PaletteColor(255, 0, 0);
        public static PaletteColor Yellow = new PaletteColor(255, 255, 0);
        public static PaletteColor Green = new PaletteColor(0, 255, 0);
        public static PaletteColor Teal = new PaletteColor(0, 255, 255);
        public static PaletteColor Blue = new PaletteColor(0, 0, 255);
        public static PaletteColor Purple = new PaletteColor(255, 0, 255);
    }

    public struct PaletteColor
    {
                
        public int Red;
        public int Green;
        public int Blue;

        public PaletteColor(int val)
        {
            this.Red = val;
            this.Green = val;
            this.Blue = val;
        }

        public PaletteColor(int red, int green, int blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public override bool Equals(object obj)
        {
            if (obj is PaletteColor target)
                return this.Red == target.Red && this.Green == target.Green && this.Blue == target.Blue;

            return false;
        }

        public override int GetHashCode()
        {
            string s = String.Format("{0:000}{1:000}{2:000}", this.Red, this.Green, this.Blue);
            
            return s.GetHashCode();
        }

        #region Utility Methods

        public static PaletteColor Linear(PaletteColor minVal, PaletteColor maxVal, float pct)
        {
            int red = Interpolation.Linear(minVal.Red, maxVal.Red, pct);
            int green = Interpolation.Linear(minVal.Green, maxVal.Green, pct);
            int blue = Interpolation.Linear(minVal.Blue, maxVal.Blue, pct);
            
            return new PaletteColor(red, green, blue);
        }

        #endregion

        #region Operator Overloads

        public static PaletteColor operator+ (PaletteColor a, PaletteColor b)
        {
            int red = Math.Min(a.Red + b.Red, 255);
            int green = Math.Min(a.Green + b.Green, 255);
            int blue = Math.Min(a.Blue + b.Blue, 255);

            return new PaletteColor(red, green, blue);
        }

        public static PaletteColor operator+ (PaletteColor a, int val)
        {
            int red = Math.Min(a.Red + val, 255);
            int green = Math.Min(a.Green + val, 255);
            int blue = Math.Min(a.Blue + val, 255);

            return new PaletteColor(red, green, blue);
        }

        public static PaletteColor operator- (PaletteColor a, PaletteColor b)
        {
            int red = Math.Max(a.Red - b.Red, 0);
            int green = Math.Max(a.Green - b.Green, 0);
            int blue = Math.Max(a.Blue - b.Blue, 0);

            return new PaletteColor(red, green, blue);
        }

        public static PaletteColor operator- (PaletteColor a, int val)
        {
            int red = Math.Max(a.Red - val, 0);
            int green = Math.Max(a.Green - val, 0);
            int blue = Math.Max(a.Blue - val, 0);

            return new PaletteColor(red, green, blue);
        }

        public static PaletteColor operator* (PaletteColor a, int val)
        {
            int red = Math.Min(a.Red * val, 255);
            int green = Math.Min(a.Green * val, 255);
            int blue = Math.Min(a.Blue * val, 255);

            return new PaletteColor(red, green, blue);
        }

        public static PaletteColor operator/ (PaletteColor a, int val)
        {
            int red = Math.Max(a.Red / val, 0);
            int green = Math.Max(a.Green / val, 0);
            int blue = Math.Max(a.Blue / val, 0);

            return new PaletteColor(red, green, blue);
        }

        public static PaletteColor operator& (PaletteColor a, PaletteColor b)
        {
            int red = (a.Red + b.Red) / 2;
            int green = (a.Green + b.Green) / 2;
            int blue = (a.Blue + b.Blue) / 2;

            return new PaletteColor(red, green, blue);
        }

        #endregion

    }

    public static class PaletteColorListExtentions
    {
        public static List<PaletteColor> Tint(this List<PaletteColor> colors, PaletteColor tint, float pct = .5f)
        {
            var tinted = new List<PaletteColor>();

            foreach (var color in colors)
            {
                tinted.Add(PaletteColor.Linear(color, tint, pct));
            }

            return tinted;
        }
    }
}
