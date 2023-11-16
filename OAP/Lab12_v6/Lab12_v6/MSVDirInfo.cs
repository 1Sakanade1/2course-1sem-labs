using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Lab12_v6
{
    internal class MSVDirInfo
    {
        public static void GetDirInfo(string dirName)
        {
            // если папка существует
            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }

                MSVLog.writelog($"выведена информация о директории : {dirName} ");

            }

        }

        public static void GetDirFiles(string dirName)
        {
            // если папка существует
            if (Directory.Exists(dirName))
            {
                string[] files = Directory.GetFiles(dirName);
                foreach (string s in files)
                {
                    Console.WriteLine(s + "\n");
                }

                MSVLog.writelog($"выведена информация о файлах директория : {dirName} ");

            }


        }

        public static void GetDirCreationTime(string dirName)
        {

            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            // если папка существует
            if (Directory.Exists(dirName))
            {
                Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}\n");

                MSVLog.writelog($"выведена информация о времени создания директория : {dirName} ");
            }

        }

        public static void GetSubdiramount(string dirName)
        {
            // если папка существует
            if (Directory.Exists(dirName))
            {
                string[] dirs = Directory.GetDirectories(dirName);
                var amount = (from p in dirs select p).Count();

                Console.WriteLine($"Количество поддиректориев: " + amount + "\n");

                MSVLog.writelog($"выведена информация о поддиректориях директория : {dirName} ");

            }
        }

        public static void GetParentDir(string dirName)
        {

            string dirTemp = "";

            string rslt;


            Console.WriteLine("список родительских директориев");

            // если папка существует 
            if (Directory.Exists(dirName))
            {

                dirTemp = Directory.GetParent(dirName).FullName;
                
                Console.WriteLine(dirTemp + "\n");

                MSVLog.writelog($"выведена информация о родительских директориях директория : {dirTemp} ");

            }
            


        }


    }
}
