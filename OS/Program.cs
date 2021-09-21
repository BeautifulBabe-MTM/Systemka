using System;
using System.Diagnostics;
using System.IO;

namespace OS
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = String.Empty;
            string choice = String.Empty;

            if (args?.Length > 0)
                Console.WriteLine("SALAM ALEJKUM");
            foreach (var item in args)
                Console.WriteLine(item);
            
            Console.WriteLine("Enter file path: ");
            path = Console.ReadLine();

            FileInfo info = new FileInfo(path);
            do
            {
                if (path.Contains("\""))
                    path = path.Replace("\"", " ");
                
                if (info.Exists)
                {
                    try
                    {
                        Console.WriteLine($"Your path - {path}\n");
                        Console.WriteLine($"Full name - {info.FullName}\n" +
                            $"Name - {info.Name}\n" +
                            $"Directory - {info.Directory}\n" +
                            $"Directory name - {info.DirectoryName}\n" +
                            $"Attributes - {info.Attributes}\n" +
                            $"Creation time - {info.CreationTime}\n" +
                            $"Is read only? - {info.IsReadOnly}\n" +
                            $"Extension - {info.Extension}" +
                            $"\nLast access time - {info.LastAccessTime}\n");

                        Console.WriteLine("If you need to open enter - \"Open\" if not, stay string emtpy");
                        choice = Console.ReadLine();
                        if (choice.ToLower() == "open")
                            try
                            {
                                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        else
                        {
                            System.Threading.Thread.Sleep(3000);
                            Environment.Exit(0);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                    Console.WriteLine("ERROR!");
            } while (choice.ToLower() != "open");
        }
    }
}