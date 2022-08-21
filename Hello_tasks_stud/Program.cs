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
                        Console.WriteLine("Error: "+ e.Message);
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
        async static Task Fact_async(int j)
        {
            // Create a cancellation token source

            // Create a cancellation token 

            // Register a delegate for a callback when a  cancellation request is made

            // Create a task with the cancellation token as argument as a lambda expression and the Factorial method

            // If user presses Escape, request cancellation.

                // Cancel task

            // await task

            // factorial value output 

        }
        #endregion

        #region Fact_Cont
        // Create Fact_cont(int j) with  ContinueWith using
        //for factorial output to console
        static void Fact_cont(int j)
        {
            // Create a cancellation token source

            // Create a cancellation token

            // Create a task with the cancellation token as argument as a lambda expression and the Factorial method

            // Register a delegate for a callback when a  cancellation request is made

            // If user presses Escape, request cancellation.

                // Cancel task

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
            // Create a cancellation token source

            // Create a cancellation token 

            // Create a task with the cancellation token as argument as a lambda expression and the Factorial method

            // Register a delegate for a callback when a  cancellation request is made

            // If user presses Escape, request cancellation.

                // Cancel task

            }
            //factorial value output 
        }
        
        #endregion
        static void cancelNotification()
        {
            Console.WriteLine("Cancellation request made");
        }

        // Create Facfactoristorial(CancellationToken ct, int num) to calculate recursively
        static int Factorial(CancellationToken ct, int num)
        {
            // throw if cancellation requested

            //argument output 

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
