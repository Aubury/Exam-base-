using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Exam_base_
{
    public class Inbox
    {
      public string Folder()
        {
            string currentDir = Environment.CurrentDirectory.ToLower();
            string subPath = @"FileWatcher\";
            DirectoryInfo dirInfo = new DirectoryInfo(currentDir);
            if(!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subPath);

            return dirInfo.FullName;

        }
        public void FileWatcher()
        {

            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = Environment.CurrentDirectory.ToLower();
            watcher.Filter = "*.json";
            watcher.Created += new FileSystemEventHandler(Watcher_Created);
            watcher.EnableRaisingEvents = true;
            //Console.ReadLine();
        }
        private static void Watcher_Created(object sender,FileSystemEventArgs e)
        {
            Console.WriteLine($"File {e.Name} created!\n");
        }
       
    }
}
