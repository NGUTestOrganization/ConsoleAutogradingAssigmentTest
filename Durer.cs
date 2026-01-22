using System;
using System.IO;
using System.Text.Json;

public static class Solution
{
    public static Shape Cube { get; private set; } = default!;
    public static Shape Pyramid { get; private set; } = default!;
    public static float XMin { get; private set; }
    public static float XMax { get; private set; }
    public static float YMin { get; private set; }
    public static float YMax { get; private set; }
    public static int Resolution { get; private set; }

    static Solution()
    {
        LoadFromJson("durer_data.json");
    }

    public static void Main()
    {
        Console.WriteLine("CUBE:");
        PrintShape(Cube);

        Console.WriteLine("\nPYRAMID:");
        PrintShape(Pyramid);
    }

    private class DataModel
    {
        public Shape Cube { get; set; } = default!;
        public Shape Pyramid { get; set; } = default!;
        public float XMin { get; set; }
        public float XMax { get; set; }
        public float YMin { get; set; }
        public float YMax { get; set; }
        public int Resolution { get; set; }
    }

    public class Shape
    {
        public float[][] VertexTable { get; set; } = default!;
        public int[][] EdgeTable { get; set; } = default!;
    }

    private static void LoadFromJson(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException($"JSON file not found: {path}");

        var json = File.ReadAllText(path);
        var data = JsonSerializer.Deserialize<DataModel>(json)!;

        Cube = data.Cube;
        Pyramid = data.Pyramid;
        XMin = data.XMin;
        XMax = data.XMax;
        YMin = data.YMin;
        YMax = data.YMax;
        Resolution = data.Resolution;
    }

    private static void PrintShape(Shape shape)
    {
        Console.WriteLine("VertexTable:");
        for (int i = 0; i < shape.VertexTable.Length; i++)
        {
            var v = shape.VertexTable[i];
            Console.WriteLine($"[{i}] ({v[0]}, {v[1]}, {v[2]})");
        }

        Console.WriteLine("EdgeTable:");
        for (int i = 0; i < shape.EdgeTable.Length; i++)
        {
            var e = shape.EdgeTable[i];
            Console.WriteLine($"[{i}] ({e[0]}, {e[1]})");
        }
    }
}

