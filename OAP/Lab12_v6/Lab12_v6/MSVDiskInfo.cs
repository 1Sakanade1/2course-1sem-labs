using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab12_v6
{
    internal static class MSVDiskInfo
    {
        
        public static void GetFullDiskInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем диска: {drive.TotalSize}");
                    Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка диска: {drive.VolumeLabel}");
                }
                Console.WriteLine();

                MSVLog.writelog("выведена полная информация о диске");

            }
        }

        public static void GetDiskFSInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Файловая система: {drive.DriveFormat}");
            }
            MSVLog.writelog("выведена информация о файловой системе диска");
        }

        public static void GetDiskFreeSpace()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
            }
            MSVLog.writelog("выведена информация о памяти диска диска");
        }

    }
}
