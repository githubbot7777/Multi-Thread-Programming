using System;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_practice
{
    

     class Program
    {

        static int _num = 0;
        //커널단까지 가는 동기화 함수
        //비용이크다(시간)
        static Mutex _lock = new Mutex();

        static void Thread_1()
        {
            for(int i=0;i<100000;i++)
            {
                _lock.WaitOne();
                _num++;
                _lock.ReleaseMutex();
            }
        }

        static void Thread_2()
        {
            for (int i = 0; i < 100000; i++)
            {
                _lock.WaitOne();
                _num--;
                _lock.ReleaseMutex();
            }
        }

        static void Main(string[] args)
        {

            Task t1 = new Task(Thread_1);
            Task t2 = new Task(Thread_2);

            t1.Start();
            t2.Start();

            Task.WaitAll(t1, t2);

            Console.WriteLine(_num);

        }
        
    }

}
