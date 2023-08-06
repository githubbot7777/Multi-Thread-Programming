using System;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_practice
{
    class SpinLock
    {
        volatile int _locked = 0;
        public void Acquire()
        {
            while(true)
            {
                //Interlocked.Exchange 
                //locked에 1을 넣는다.
                //바뀌기전에 값을 반환한다.
                //int original = Interlocked.Exchange(ref _locked, 1);
                //if (original == 0)
                //    break;

                int expected = 0;
                int desired = 1;
                //locked의 값이 expected와 같다면 desired로 넣어주겠다.
                if (Interlocked.CompareExchange(ref _locked, desired, expected) == expected)
                    break;
            }
          

        }
        public void Release()
        {

            _locked = 0;
        }
    }

     class Program
    {

        static int _num = 0;
        static SpinLock _lock = new SpinLock();

        static void Thread_1()
        {
            for(int i=0;i<1000000;i++)
            {
                _lock.Acquire();
                _num++;
                _lock.Release();
            }
        }

        static void Thread_2()
        {
            for (int i = 0; i < 1000000; i++)
            {
                _lock.Acquire();
                _num--;
                _lock.Release();
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
