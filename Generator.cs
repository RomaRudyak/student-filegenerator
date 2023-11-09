using System;
using System.IO;

namespace FileGenerator;

internal class Generator
{
    public int FileCountPerDir { get; set; } = 400;
    public int DirLevel { get; set; } = 2;
    public int DirCountPerDir { get; set; } = 5;
    public int FileMaxSizeBytes { get; set; } = 4_194_304;

    public void Generate(string dir)
    {
        CreateDirIfNeeded(dir);
        GenerateDirTree(dir, 0);
    }

    private void GenerateDirTree(string dir, int level)
    {
        if (level > DirLevel)
        {
            return;
        }

        CreateFiles(dir);

        level++;

        for (int i = 0; i < DirCountPerDir; i++)
        {
            var current = Path.Combine(dir, $"dir{i}");
            Directory.CreateDirectory(current);
            GenerateDirTree(current, level);
        }
    }

    private void CreateFiles(string dir)
    {
        for (int i = 0; i < FileCountPerDir; i++)
        {
            var name = Path.Combine(dir, $"file{i}.txt");
            Random random = new Random();

            var content = new Byte[random.Next(FileMaxSizeBytes)];
            random.NextBytes(content);
            File.WriteAllBytes(name, content);
            Console.WriteLine(name);
        }
    }

    private void CreateDirIfNeeded(string dir)
    {
        if (Directory.Exists(dir))
        {
            return;
        }

        Directory.CreateDirectory(dir);
    }
}
