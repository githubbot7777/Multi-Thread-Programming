using System;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_practice
{

    class Program
    {
        static int number;
        static object _obj = new object();
      
        //c++ mutex
       static void Thread_1()
        {
            for(int i=0;i<100000;i++)
            {
                lock(_obj)
                {
                    number++;
                }
            }     
        }

        static void Thread_2()
        {
            for (int i = 0; i < 100000; i++)
            {
                lock (_obj)
                {
                    number--;
                } 
            }
        }
        static void Main(string[] args)
        {
            Task t1 = new Task(Thread_1);
            Task t2 = new Task(Thread_2);

            t1.Start();
            t2.Start();

            Task.WaitAll(t1, t2);

            Console.WriteLine(number);

        }
        
    }

}
