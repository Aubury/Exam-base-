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
      public Inbox()
        {
            string currentDir = Environment.CurrentDirectory.ToLower();
            string subPath = @"FileWatcher\";
            DirectoryInfo dirInfo = new DirectoryInfo(currentDir);
            if(!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subPath);

         }
        public string Folder_processed()
        {
            string currentDir = Environment.CurrentDirectory.ToLower();
            string subPath = @"FileWatcher\Folder_processed";
            DirectoryInfo dirInfo = new DirectoryInfo(currentDir);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subPath);

            return dirInfo.FullName;

        }
         public string Folder_Errors()
        {
            string currentDir = Environment.CurrentDirectory.ToLower();
            string subPath = @"FileWatcher\Folder_Errors";
            DirectoryInfo dirInfo = new DirectoryInfo(currentDir);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subPath);

            return dirInfo.FullName;

        }
        public bool FileWatcher()
        {

            FileSystemWatcher watcher = new FileSystemWatcher();

            watcher.Path = @"FileWatcher\";
            watcher.Filter = "*.json";
            watcher.Created += new FileSystemEventHandler(Watcher_Created);
            watcher.EnableRaisingEvents = true;

            if(watcher.EnableRaisingEvents == true) { return true; }
            else { return false; }

        }
        public void Move_File_Folder_processed()
        {
            int n=1;
            string subPath = @"FileWatcher\Request.json";
            string subPath1 = @"FileWatcher\Folder_processed\Request.json";
            if(File.Exists(subPath1))
            {
                  do
                   {
                        n++;
                        subPath1 = ($"FileWatcher\\Folder_processed\\Request+{n}.json");
                    }
                    while (File.Exists(subPath1));
                    
              
            }
            if(File.Exists(@"FileWatcher\Request.json"))
            {
                File.Move(subPath, subPath1);
            }


        }
        private static void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File {e.Name} created!\n");
        }

    }
}
