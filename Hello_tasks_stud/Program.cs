using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;



namespace Hello_tasks_stud
{
    class Program
    {
        static void Main(string[] args)
        {

            int a;
            try
            {
                do
                {
                    Console.WriteLine(@"Please,  type the number:                       
                        1.  Factorial                 
                        2.  Factorial with Continuation
                        3.  Factorial task async 
                       
                        ");
                    try
                    {
                        Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                        a = int.Parse(Console.ReadLine());
                        switch (a)
                        {
                            case 1:
                                Console.WriteLine("Factorial");
                                Fact_frk(4);
                                break;
                            case 2:
                                Console.WriteLine("Continuation ");
                                Fact_cont(5);

                                break;
                            case 3:
                                Console.WriteLine("Factorial task async ");
                                Task t = Fact_async(3);

                                t.Wait();
                                break;
                            default:
                                Console.WriteLine("Exit");
                                break;
                        }

                    }
                    catch (System.Exception e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                    }
                    finally
                    {
                        Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Press Spacebar to exit; press any key to continue");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                while (Console.ReadKey().Key != ConsoleKey.Spacebar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        #region Fact_Async

        //Create async Task Fact_async(int j) to calculate and output factorial
        async static Task<int> Fact_async(int j)
        {
            CancellationTokenSource source = new CancellationTokenSource();
            // Create a cancellation token source
            CancellationToken cancellationToken = source.Token;
            // Create a cancellation token 
            int number = j;
            Func<object, int> func = (object obj) =>
            {
                return number = Factorial(cancellationToken, number);
            };
            Action<object> action = (object obj) =>
            {
                Console.WriteLine("Task : {0}, Object : {1}, Thread : {2}", Task.CurrentId, obj.ToString(), Thread.CurrentThread);
            };
            cancellationToken.Register(action, source.IsCancellationRequested);
            Task<int> task = Task<int>.Factory.StartNew(func, "Asyncronous task 2", cancellationToken);
            
            // Register a delegate for a callback when a  cancellation request is made
            // Create a task with the cancellation token as argument as a lambda expression and the Factorial method
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                source.Cancel();
                cancelNotification();
            }
            // If user presses Escape, request cancellation.
            Console.WriteLine($"Task Status : {task.Status}");
            source.Dispose();
            return await task;
            // Cancel task
        }




        // If user presses Escape, request cancellation.

        // Cancel task

        // await task

        // factorial value output 

        #endregion

        #region Fact_Cont
        // Create Fact_cont(int j) with  ContinueWith using
        //for factorial output to console
        static void Fact_cont(int j)
        {
            CancellationTokenSource source = new CancellationTokenSource();
            // Create a cancellation token source
            CancellationToken cancellationToken = source.Token;
            int number = j;
            // Create a cancellation token 
            Task<int> task = new Task<int>((x) => { return Factorial(cancellationToken, number); }, cancellationToken);
            // Create a task with the cancellation token as argument as a lambda expression and the Factorial method
            Action<object> action = (object obj) =>
            {
                Console.WriteLine("Task : {0}, Object : {1}, Thread : {2}", Task.CurrentId, obj.ToString(), Thread.CurrentThread);
            };
            Action<Task> DoOnSecond = (Task t) =>
            {
                if(t.IsCompleted)
                {
                    Console.WriteLine("Task #2 : is completed !");
                }
                Console.WriteLine("Task : {0}, Thread : {2}", Task.CurrentId, Thread.CurrentThread);
            };
            Action<Task> DoOnThird = (Task t) =>
            {
                if(t.IsCompleted)
                {
                    Console.WriteLine("Task #3 : is completed !");
                }
                Console.WriteLine("Task : {0}, Thread : {2}", Task.CurrentId, Thread.CurrentThread);
            };
            cancellationToken.Register(action, cancellationToken.IsCancellationRequested);
            // Register a delegate for a callback when a  cancellation request is made
            task.RunSynchronously();
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                source.Cancel();
                cancelNotification();
            }
            // If user presses Escape, request cancellation.
            Console.WriteLine($"Task Status : {task.Status}");
            Action t2Act = () =>
            {
                Console.WriteLine("Task #2 started !");
            };
            Task t2 = task.ContinueWith(DoOnSecond);
            
            
            Task t3 = t2.ContinueWith(DoOnThird);
            // Create continuation 2 tasks using lambda expressions 
            //with TaskContinuationOptions.OnlyOnRanToCompletion and  TaskContinuationOptions.NotOnRanToCompletion options

            // Task.WaitAll for these two tasks

            //IsCanceled properies output

        }
        #endregion
        #region Factorial
        // Create void Fact_frk(int j) to calculate factorial
        static void Fact_frk(int j)
        {
            CancellationTokenSource source = new CancellationTokenSource();
            // Create a cancellation token source
            CancellationToken cancellationToken = source.Token;
            int number = j;
            // Create a cancellation token 
            Task<int> task = new Task<int>((x) => { return Factorial(cancellationToken, number); }, cancellationToken);
            // Create a task with the cancellation token as argument as a lambda expression and the Factorial method
            Action<object> action = (object obj) =>
            {
                Console.WriteLine("Task : {0}, Object : {1}, Thread : {2}", Task.CurrentId, obj.ToString(), Thread.CurrentThread);
            };
            cancellationToken.Register(action, cancellationToken.IsCancellationRequested);
            // Register a delegate for a callback when a  cancellation request is made
            task.RunSynchronously();
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                source.Cancel();
                cancelNotification();
            }
            // If user presses Escape, request cancellation.
            Console.WriteLine($"Task Status : { task.Status}");
            // Cancel task
            source.Dispose();            

        }
        //factorial value output 

        #endregion
        static void cancelNotification()
        {
            Console.WriteLine("Cancellation request made");
        }

        // Create Facfactoristorial(CancellationToken ct, int num) to calculate recursively
        static int Factorial(CancellationToken ct, int num)
        { 
            ct.ThrowIfCancellationRequested();
            // throw if cancellation requested
            if (num < 1)
            {
                return 1;
            }
            //argument output 
            if (ct.IsCancellationRequested)
            {
                Thread.Sleep(5000);
                Console.WriteLine("Long work simulating !");
                return num;
            }
            return (num < 1) ? 1 : num * Factorial(ct, num - 1);
            // create if block to check cancellation requested

            //simulate long work

            //return recursive calculation of factorial 
            //use multiplication to  PressAnyKey() method result to catch key press

            //return 0 

        }


        #region Clava

        static int PressAnyKey()
        {
            KeyboardSend.KeyDown(Keys.Back);
            return 1;
        }

        static class KeyboardSend
        {
            //Simulation of a keyboard input 
            [DllImport("user32.dll")]
            private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

            private const int KEYEVENTF_EXTENDEDKEY = 1;
            private const int KEYEVENTF_KEYUP = 2;

            public static void KeyDown(Keys vKey)
            {
                keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
            }

            public static void KeyUp(Keys vKey)
            {
                keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            }
        }
        #endregion
    }
}