using System;
using System.IO;
using System.Linq;

namespace FileGenerator
{
    class Program
    {
        private const Int32 FileCountPerDir = 400;
        private const Int32 DirLevel = 2;
        private const Int32 DirCountPerDir = 5;
        private const Int32 FileMaxSizeBytes = 4_194_304;


        static void Main(string[] args)
        {
            var dir = args.FirstOrDefault() ?? throw new InvalidOperationException("Specify output dir");

            CreateDirIfNeeded(dir);
            GenerateTestSet(dir);
        }

        private static void GenerateTestSet(string dir)
        {
            GenerateDirTree(dir, 0);
        }

        private static void GenerateDirTree(string dir, int level)
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

        private static void CreateFiles(string dir)
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

        private static void CreateDirIfNeeded(string dir)
        {
            if (Directory.Exists(dir))
            {
                return;
            }

            Directory.CreateDirectory(dir);
        }
    }
}
