using System;
using System.IO;


namespace Palettes
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Basic";

            using (StreamWriter writer = new StreamWriter($"c:\\temp\\{name}.gpl", false))
            {
                WriteHeaders(writer, name);
            }
        }

        static void WriteHeaders(StreamWriter writer, string name)
        {
            writer.WriteLine("GIMP Palette");
            writer.WriteLine($"Name: {name} Palette");
            writer.WriteLine("Columns: 0");
            writer.WriteLine("");
        }

        static void WriteColors(StreamWriter writer, int red, int green, int blue)
        {

        }

    }
}
