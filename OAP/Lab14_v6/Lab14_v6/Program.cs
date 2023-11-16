
using Lab14_v6;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Threading;

public class Program
{
     static void counter()
    {
        int n = 2;
       for (int i=1;i<=n;i++)
        {
            Console.WriteLine(i);
        }
    }




    static void Main(string[] args)
    {

/*        var allprocess = Process.GetProcesses();
        foreach (Process process in allprocess)
        {
            // выводим id и имя процесса
            Console.WriteLine($"ID: {process.Id}  Name: {process.ProcessName}  MachineName: {process.MachineName} ");
            Process proc = Process.GetProcessesByName("devenv")[0];
            ProcessThreadCollection processThreads = proc.Threads;

            foreach (ProcessThread thread in processThreads)
            {
                Console.WriteLine($"ThreadId: {thread.Id}  StartTime: {thread.StartTime}");
            }
        }*/


        Console.WriteLine("-------------------");


        AppDomain domain = AppDomain.CurrentDomain;
        Console.WriteLine($"Name: {domain.FriendlyName}");
        Console.WriteLine($"Base Directory: {domain.BaseDirectory}");
        Console.WriteLine();

        Console.WriteLine("список загруженных в домен сборок: ");

        Assembly[] domassemblies = domain.GetAssemblies();
        foreach (Assembly asm in domassemblies)
        {
            Console.WriteLine(asm.GetName().Name);
        }

        //domen creation
        Console.WriteLine("--------------");
              /*  DomainWorker.MakeNewDomain();*/


/*        Console.WriteLine("--------------");

        ThreadWorker.CheckThreadWork(20);

        Console.WriteLine("0000000000000000000000");
        Thread.Sleep(400);
        Fourth_task.Fourth();*/

        Console.WriteLine("\n -------------------");

        Timer_task.StartTimerTask();

    }


}