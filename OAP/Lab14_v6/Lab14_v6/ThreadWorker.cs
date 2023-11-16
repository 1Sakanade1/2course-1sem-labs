using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


    internal class ThreadWorker
    {
        public static void CheckThreadWork(int n)
        {
            
            int[] prostn = new int[10] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };  

            // создаем новый поток
            Thread myThread = new Thread(Print);
            // запускаем поток myThread
            myThread.Start();
            
/*            myThread.Suspend();
            myThread.Resume();*/
            // действия, выполняемые в главном потоке

            int i = 0;

            while (prostn[i] <= n)
            {
                Console.WriteLine($"Главный поток: {prostn[i]} Приоритет: {Thread.CurrentThread.Priority}\n");
                Console.WriteLine($" ID потока:{Thread.CurrentThread.ManagedThreadId}\n");
                Console.WriteLine($"Работает ли поток: {Thread.CurrentThread.IsAlive}");
                Console.WriteLine("-  -  -  -  -  -  -");
                Thread.Sleep(300);


            i++;
            }

            // действия, выполняемые во втором потокке
            void Print()
            {
            int i_sec = 0;

            while (prostn[i_sec] <= n)
            {
                Console.WriteLine($"Второй поток: {prostn[i_sec]} Приоритет: {Thread.CurrentThread.Priority}\n");
                    Console.WriteLine($" ID потока:{Thread.CurrentThread.ManagedThreadId}\n");
                    Console.WriteLine($"Работает ли поток: {Thread.CurrentThread.IsAlive}");
                    Console.WriteLine("-  -  -  -  -  -  -");
                    Thread.Sleep(400);

                i_sec++;



                }
            }

        }
        


        


        public static void z2threadwork(int n)
        {
        // создаем новый поток
        Thread myThread = new Thread(Print);
        // запускаем поток myThread
        myThread.Start();

        // действия, выполняемые в главном потоке
        for (int i = 0; i < n + 1; i++)
        {
            if(i%2 == 0) { 
            Console.WriteLine($"Главный поток: {i} \n");
            Console.WriteLine("-  -  -  -  -  -  -");
            Thread.Sleep(300);
            }
        }

        // действия, выполняемые во втором потокке
        void Print()
        {
            for (int i = 0; i < n + 1; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine($"Второй поток: {i} \n");
                    Console.WriteLine("-  -  -  -  -  -  -");
                    Thread.Sleep(500);
                }
            }
        }


    }


    }
    
