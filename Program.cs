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
            var dir = args.FirstOrDefault();

            CreateDirIfNeeded(dir);
            GenerateTestSet(dir);
        }

        private static void GenerateTestSet(string dir)
        {
            throw new NotImplementedException();
        }

        private static void CreateFiles(string dir)
        {
            
        }

        private static void CreateDirIfNeeded(string dir)
        {
            if(Directory.Exists(dir))
            {
                return;
            }

            Directory.CreateDirectory(dir);
        }
    }
}
