using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab12_v6
{
    internal class MSVLog
    {


        public static void writelog(string info)
        {
           string logfilepath = "C:\\Container\\code\\2курс лабы\\OAP\\Lab12_v6\\logfile.txt";

        DateTime dateofchange = DateTime.Now;

            if (!File.Exists(logfilepath))
            {
                Directory.CreateDirectory(logfilepath);
            }

            List<string> lines = new List<string>();

            lines.Add("--------------------------------");
            lines.Add($"Время внесения изменений: {DateTime.Now}\n");
            lines.Add(info + "\n\n");

            File.AppendAllLines(logfilepath, lines);

        }

    }
}
