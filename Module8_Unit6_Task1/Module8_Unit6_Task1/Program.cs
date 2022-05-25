using System;
using System.IO;

namespace Module8_Unit6_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            /// Ввели путь к папке
            string Path;
            Console.WriteLine("Введите путь к папке:");
            Path = Console.ReadLine();
            ClearDirectory(Path);
        }

        static void ClearDirectory(string FolderName)
        {
             DirectoryInfo dirInfo = new DirectoryInfo(@$"{FolderName}");
            try
            {
                
                if (dirInfo.Exists)
                {
                    
                    foreach (FileInfo fi in dirInfo.GetFiles())
                    {
                        if ((DateTime.Now - fi.LastAccessTime) > TimeSpan.FromMinutes(30))
                        { fi.Delete(); }
                    }
                    foreach (DirectoryInfo di in dirInfo.GetDirectories())
                    {
                        ClearDirectory(di.FullName);
                        if ((DateTime.Now - di.LastAccessTime) > TimeSpan.FromMinutes(30))
                        { di.Delete(); }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }      



        


        
    }
}
