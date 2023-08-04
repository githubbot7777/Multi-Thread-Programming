using System;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_practice
{
    //메모리 배리어
    //1) 코드 재배치 억제
    //2) 가시성

    class Program
    {

        static int x = 0;
        static int y = 0;
        static int r1 = 0;
        static int r2 = 0;

        static void Thread_1()
        {
            y = 1;// 1
            Thread.MemoryBarrier();
            r1 = x;// 2
            /*
             * 1번과 2번이 최적화로 인해 바뀐다
             * 따라서 해결법으로 Memory Barrier 사용
             * 
            */

        }

        static void Thread_2()
        {
            x = 1;//1
            Thread.MemoryBarrier();
            r2 = y;//2
        }

        static void Main()
        {
            int count = 0;
            while (true)
            {
                count++;
                x = y = r1 = r2 = 0;

                Task t1 = new Task(Thread_1);
                Task t2 = new Task(Thread_2);
                t1.Start();
                t2.Start();

                Task.WaitAll(t1, t2);

                //최적화로 인해 thread_1 Thread_2의 1번 2번 줄이 바뀜으로
                //r1 r2 둘다 0이 되는 경우가 나옴
                if (r1 == 0 && r2 == 0)
                    break;
            }

            Console.WriteLine($"{count}번만에 빠져나옴!");
        }
    }

}
