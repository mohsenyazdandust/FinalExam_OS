using System;
using System.Diagnostics;

namespace FinalExam_OS
{
    internal class Program
    {
        static Semaphore semaphore = new Semaphore(2, 2);

        static void Main(string[] args)
        {
            // Find Number //
            string path = @"C:\Users\themohsen\Desktop\MY.txt";

            string txt = File.ReadAllText(path);
            string[] lines = txt.Split("\n");

            int num = 0;

            foreach (string line in lines)
            {
                try
                {
                    num = Convert.ToInt32(line);
                    break;
                } catch (Exception ex) {}
            }

            // Q1 //
            Thread q1 = new Thread(() =>
            {
                Fact(num);
            });
            // q1.Start();


            // Q2 //
            Thread q2 = new Thread(() =>
            {
                Fiboo(num);
            });
            // q2.Start();

            // Q3 //
            Thread q3 = new Thread(() =>
            {
               Q3(num);
            });
            // q3.Start();

            // Q4 //
            // Process notepad = Process.Start("notepad", path);
            // Thread.Sleep(10000);
            // notepad.Kill();
        }

        static int Fact(int x)
        {
            Thread.Sleep(1000);
            if (x == 1)
            {
                Console.WriteLine($"Q1: {1}");
                return 1;
            }
            else
            {
                int temp = x * Fact(x - 1);
                Console.WriteLine($"Q1: {temp}");
                return temp;
            }
        }

        static int Fiboo(int x)
        {
            Thread.Sleep(1000);
            if (x == 1)
            {
                Console.WriteLine($"Q2: {0}");
                return 0;
            } else if (x == 2)
            {
                Console.WriteLine($"Q2: {1}");
                return 1;
            } else
            {
                int temp = Fiboo(x - 1) + Fiboo(x - 2);
                Console.WriteLine($"Q2: {temp}");
                return temp;
            }
        }

        static void Q3(int num)
        {
            semaphore.WaitOne();
            Thread q1 = new Thread(() =>
            {
                Fact(num);
            });
            q1.Start();
            semaphore.Release();

            semaphore.WaitOne();
            Thread q2 = new Thread(() =>
            {
                Fiboo(num);
            });
            q2.Start();
            semaphore.Release();
        }
    }
}