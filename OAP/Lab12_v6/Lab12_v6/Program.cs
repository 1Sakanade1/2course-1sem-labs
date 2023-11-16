using Lab12_v6;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {

        // diskinfo test
        MSVDiskInfo.GetFullDiskInfo();
        MSVDiskInfo.GetDiskFSInfo();
        MSVDiskInfo.GetDiskFreeSpace();

        Console.WriteLine("----------------");


        //fileinfo test

        string filepath = $"C:\\Container\\code\\lab12_filelog.txt";

        MSVFileInfo.GetFileInfo(filepath);
        MSVFileInfo.GetFilePath(filepath);
        MSVFileInfo.GetFileCreationTime(filepath);

        Console.WriteLine("----------------");

        //dirinfo test

        string dirName = "C:\\container";

        MSVDirInfo.GetDirFiles(dirName);
        MSVDirInfo.GetDirCreationTime(dirName);
        MSVDirInfo.GetSubdiramount(dirName);

        MSVDirInfo.GetParentDir(dirName);

        Console.WriteLine("----------------");


        string path = @"C:\Container\Lab12Dir";
        string path2 = @"C:\Container\Lab12MSVFiles";
        MSVFileManager.TaskA(path);
        MSVFileManager.TaskB(path2);

        //MSVLog.writelog("file removed");

    }
}