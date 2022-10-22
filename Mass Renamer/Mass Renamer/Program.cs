using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.WebRequestMethods;

namespace MassRenamer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Clip Folder Renamer";
            string path;

            Console.Write("Folder Path: "); path = Console.ReadLine();

            string[] filesInDirectory = 
                Directory.GetFiles(path, "*.mp4");

            Console.WriteLine(
                "Files in folder: " 
                + filesInDirectory.Length 
                + "\n\n"
            );

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            int i = 0;

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            foreach (string file in filesInDirectory) 
            {
                FileInfo fileInfo = new FileInfo(file);

                Console.WriteLine(
                    "File {0} " +
                    "being renamed to {1}.mp4",
                    fileInfo, i
                );

                fileInfo.MoveTo(path + "\\" + i + ".mp4");
                i++;
                Console.WriteLine("File renamed.\n");
            }

            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            Console.ReadKey();
        }
    }
}
