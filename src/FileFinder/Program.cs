using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace FileFinder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter a file name in this format: \"filename\"");
            string userInput = Console.ReadLine();
            DriveInfo di = new DriveInfo(@"C:\");
            DirectoryInfo dirInfo = di.RootDirectory;
            FileInfo file = dirInfo.EnumerateFiles().SingleOrDefault(x => x.Name == userInput);
            if (file == null)
            {
                Console.WriteLine("Could not find a file with that specific filename.");
            }
            else {
                file.Open(FileMode.Open);
            }
        }
    }
}
