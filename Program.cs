using System;
using System.IO;
using Palettes.Generation;
using Palettes.Generation.Generators;


namespace Palettes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generating palettes...");
            GeneratePalette("Standard", new StandardGenerator(PaletteColors.Black), new StandardGenerator(PaletteColors.White));   
            GeneratePalette("BasicDark", new StandardGenerator(PaletteColors.Black));   
            GeneratePalette("BasicLight", new StandardGenerator(PaletteColors.White));   
            GeneratePalette("EarthyDark", new StandardGenerator(PaletteColors.Black, new PaletteColor(164, 100, 34)));   
            GeneratePalette("EarthyLight", new StandardGenerator(PaletteColors.White, new PaletteColor(164, 100, 34)));   
            GeneratePalette("IceyDark", new StandardGenerator(PaletteColors.Black, new PaletteColor(0, 190, 214)));   
            GeneratePalette("IceyLight", new StandardGenerator(PaletteColors.White, new PaletteColor(0, 190, 214)));   
            GeneratePalette("FireyDark", new StandardGenerator(PaletteColors.Black, new PaletteColor(204, 28, 0)));   
            GeneratePalette("FireyLight", new StandardGenerator(PaletteColors.White, new PaletteColor(204, 28, 0)));   
            GeneratePalette("Pastels", new StandardGenerator(PaletteColors.White, PaletteColors.White));   
            GeneratePalette("Shadows", new StandardGenerator(PaletteColors.White, PaletteColors.Black));  
            Console.WriteLine("Done"); 
        }

        static void GeneratePalette(string name, params IPaletteGenerator[] gens)
        {
            Palette palette = new Palette(name);

            foreach (var gen in gens)
            {
                palette.Add(gen.Generate(name));    
            }

            using (StreamWriter writer = new StreamWriter($"{name}.gpl", false))
            {
                WritePalette(writer, palette);
            }
        }

        static void WritePalette(StreamWriter writer, Palette palette)
        {
            WriteHeaders(writer, palette);
            WriteColors(writer, palette);
        }

        static void WriteHeaders(StreamWriter writer, Palette palette)
        {
            writer.WriteLine("GIMP Palette");
            writer.WriteLine($"Name: {palette.Name} Palette");
            writer.WriteLine("Columns: 0");
            writer.WriteLine("");
        }

        static void WriteColors(StreamWriter writer, Palette palette)
        {
            foreach (var color in palette.Colors)
            {
                writer.WriteLine("{0} {1} {2} Untitled", color.Red, color.Green, color.Blue);
            }
        }
    }
}
