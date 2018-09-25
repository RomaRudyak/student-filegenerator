using System;
using System.IO;
using System.Linq;

namespace FileGenerator
{
    class Program
    {
        private const Int32 FileCountPerDir = 100;
        private const Int32 DirCount = 1000;
        private const Int32 FileMaxSize = 8_388_608;

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
