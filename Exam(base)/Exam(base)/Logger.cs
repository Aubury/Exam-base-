using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_base_
{
   public  class Logger
    {
        Bancomat _bank;

        private static readonly string currentDir = Directory.GetCurrentDirectory();
        private static string pathToLog = Path.Combine(currentDir, "Log.txt");
        FileInfo fi = new FileInfo(pathToLog);
        FileStream s = null;
        public  void WriteLine(string message)
        {
            if (!fi.Exists)
                try { s = fi.Create(); }
                catch (Exception e) { Console.WriteLine(e.Message); }
                finally { s?.Close(); }

            File.AppendAllText("Log.txt", message);
        }
    }
}
