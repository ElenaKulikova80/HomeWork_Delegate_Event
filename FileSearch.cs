using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class FileFoundArgs : EventArgs
    {
        public string FoundFile { get; }
        public bool CancelRequested { get; set; }
        public FileFoundArgs(string fileName) => FoundFile = fileName;
    }

    
    public class FileSearch
    {
        //объявление события FileFound
        public event EventHandler<FileFoundArgs>? FileFound;

        //метод для поиска файла
        public void Search(string directory, string searchPattern)
        {
            foreach(var file in Directory.EnumerateFiles(directory, searchPattern))
            {
                //RaiseFileFound(file);
                FileFoundArgs args = RaiseFileFound(file);
                if (args.CancelRequested)
                {
                    break;
                }
                Console.WriteLine("Файл найден");
            }

            FileFoundArgs RaiseFileFound(string file)
            {
                var args = new FileFoundArgs(file);
                //FileFound?.Invoke(this, new FileFoundArgs(file));
                FileFound?.Invoke(this, args);
                return args;
            }
        }
    }
}
