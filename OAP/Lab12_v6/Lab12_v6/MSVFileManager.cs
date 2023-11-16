using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;
using System.IO.Compression;

namespace Lab12_v6
{
    internal class MSVFileManager
    {
        public static void TaskA(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            FileStream? fstream = null;


                fstream = new FileStream("C:\\Container\\Lab12Dir\\msvdirinfo.txt", FileMode.OpenOrCreate);
            // операции с fstream
                fstream.Close();


            File.AppendAllText("C:\\Container\\Lab12Dir\\msvdirinfo.txt","\nzxczxc2");

            if (!File.Exists("C:\\Container\\Lab12Dir\\newfile.txt"))
            {
                File.Copy("C:\\Container\\Lab12Dir\\msvdirinfo.txt", "C:\\Container\\Lab12Dir\\newfile.txt");
            }

            File.Delete("C:\\Container\\Lab12Dir\\msvdirinfo.txt");


            MSVLog.writelog($"выполнен пункт 1 из 5 задания");
        }

        public static async void TaskB(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            FileStream? fstream = null;



            string[] txtfiles = Directory.GetFiles("C:\\Container\\Lab12Dir", "*.txt");

            foreach (string txtfile in txtfiles)
            {

                FileInfo fileInf = new FileInfo(txtfile);
                if (!File.Exists(@$"C:\Container\Lab12MSVFiles\\{fileInf.Name}"))
                {
                    File.Copy(txtfile, @$"C:\Container\Lab12MSVFiles\\{fileInf.Name}");
                }

            }
            if (!(Directory.Exists("C:\\Container\\Lab12Dir\\Lab12MSVFiles"))) { 
            Directory.Move(path, "C:\\Container\\Lab12Dir\\Lab12MSVFiles");
            }

            if (!File.Exists(@"C:\\Container\\Lab12Dir\\result.zip"))
            {
                ZipFile.CreateFromDirectory("C:\\Container\\Lab12Dir\\Lab12MSVFiles", "C:\\Container\\Lab12Dir\\result.zip");
            }

            MSVLog.writelog($"выполнен пункт 2 и 3 из 5 задания ");
        }

        



    }
}
