using System;
using System.IO;

namespace systemIO_pract
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Имя диска: {drive.Name}");
                Console.WriteLine($"Объём диска: {drive.TotalSize / (1024 * 1024 * 1024)} Гб");
                Console.WriteLine($"Свободное пространство: {drive.AvailableFreeSpace / (1024 * 1024 * 1024)} Гб");
                Console.WriteLine($"Метка диска: {drive.VolumeLabel}");
                Console.WriteLine("============================");
            }

            // 2
            string directoryPath = @"F:\prac_2";
            PrintDirectoryTree(directoryPath);
            Console.WriteLine("============================");

            // 3
            string directoryPathWithFilter = @"F:\prac_2";
            string filter = "*.pdf";
            PrintDirectoryTreeWithFilter(directoryPathWithFilter, filter);
            Console.WriteLine("============================");

            // 4
            string fileName = "Malinkin.txt";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("Здравствуйте, Глеб Ильич!");
                writer.WriteLine("Вот моя практическая #2!");
            }

            using (StreamReader reader = new StreamReader(fileName))
            {
                string contents = reader.ReadToEnd();
                Console.WriteLine($"Содержимое файла {fileName}: {contents}");
            }
        }

        static void PrintDirectoryTree(string path)
        {
            Console.WriteLine($"Содержимое папки {path}:");
            foreach (string directory in Directory.GetDirectories(path))
            {
                Console.WriteLine($"Папка: {directory}");
                PrintDirectoryTree(directory);
            }
            foreach (string file in Directory.GetFiles(path))
            {
                Console.WriteLine($"Файл: {file}");
            }
        }

        static void PrintDirectoryTreeWithFilter(string path, string filter)
        {
            Console.WriteLine($"Содержимое папки {path} с фильтром {filter}:");
            foreach (string directory in Directory.GetDirectories(path))
            {
                PrintDirectoryTreeWithFilter(directory, filter);
            }
            foreach (string file in Directory.GetFiles(path, filter))
            {
                Console.WriteLine($"Файл: {file}");
            }
        }
    }
}
