using System;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_practice
{

    class Program
    {
        static int number;
      

       static void Thread_1()
        {
          for(int i=0;i<10000;i++)
            {
                number++;

                //int temp = number;
                //temp += 1;
                //number = temp;
                //number++은 어셈블리어로 3줄을 의미 -> 원자성 보장이 안됨

                //해결방법
                //int afterValue=Interlocked.Increment(ref number);
                //반환값은 바뀐후의 값
            }
        }

        static void Thread_2()
        {
            for (int i = 0; i < 10000; i++)
            {
                number--;
                //해결방법
                //Interlocked.Decrement(ref number);

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
