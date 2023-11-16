using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14_v6
{
    internal class Fourth_task
    {
        public static void Fourth()
        {
            // создаем новый поток
            var first = new Thread(OddNumbers) { Priority = ThreadPriority.Highest };
            var two = new Thread(EvenNumbers);
            

            FirstlyEvenSecondlyOdd();
            Console.WriteLine("\n--------------");
            ShowOneByOne();

        }
        private static void ShowOneByOne()
        {
            var mutex = new Mutex();
            var even = new Thread(ShowEvenNumbers);
            var odd = new Thread(ShowOddNumbers);
            odd.Start();
            even.Start();
            even.Join();
            odd.Join();

            void ShowEvenNumbers()
            {
                for (var i = 0; i < 15; i++)
                {
                    mutex.WaitOne();

                    if (i % 2 == 0)
                        Console.Write(i + " ");
                    mutex.ReleaseMutex();
                }
            }

            void ShowOddNumbers()
            {
                for (var i = 0; i < 10; i++)
                {
                    mutex.WaitOne();
                    Thread.Sleep(200);
                    if (i % 2 != 0)
                        Console.Write(i + " ");
                    mutex.ReleaseMutex();
                }
            }
        }
        private static void FirstlyEvenSecondlyOdd()
        {
            var objectToLock = new object();
            var even = new Thread(ShowEvenNumbers);
            var odd = new Thread(ShowOddNumbers);
            even.Start();
            odd.Start();
            even.Join();
            odd.Join();

            void ShowEvenNumbers()
            {
                lock (objectToLock)
                {
                    for (var i = 0; i < 15; i++)
                    {
                        if (i % 2 == 0)
                            Console.Write(i + " ");
                    }
                }
            }

            void ShowOddNumbers()
            {
                for (var i = 0; i < 10; i++)
                {
                    Thread.Sleep(200);
                    if (i % 2 != 0)
                        Console.Write(i + " ");
                }
            }
        }
        public static void OddNumbers()
        {

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                if (i % 2 != 0)
                {

                    Console.WriteLine(i + " ");
                }

            }
        }
        public static void EvenNumbers()
        {

            for (int i = 0; i < 15; i++)
            {
                Thread.Sleep(300);
                if (i % 2 == 0)
                {

                    Console.WriteLine(i + " ");
                }

            }

        }
    }
}
