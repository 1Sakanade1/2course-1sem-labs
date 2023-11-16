using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab12_v6
{
    internal class MSVFileInfo
    {
        public static void GetFileInfo(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                Console.WriteLine($"Имя файла: {fileInfo.Name}");
                Console.WriteLine($"Расширение файла: {fileInfo.Extension}");
                Console.WriteLine($"Размер: {fileInfo.Length}\n");
            }
            MSVLog.writelog($"выведена информация о файле по адресу: {path} ") ;
        }

        public static void GetFilePath(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                Console.WriteLine($"Путь до файла: {fileInfo.DirectoryName}\n" );

            }
            MSVLog.writelog($"выведен путь до файла : {path} ");

        }

        public static void GetFileCreationTime(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {

                Console.WriteLine($"Время создания: {fileInfo.CreationTime}\n");

                Console.WriteLine($"Время последнего изменения: {File.GetLastWriteTime(path)}\n");

            }

            MSVLog.writelog($"выведена информация о создании файла: {path} ");
        }
    }


}

