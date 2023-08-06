using System;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_practice
{
    //DeadLock 예제
    //BreakPoint 설정 후 디버그모드에서 모두 중단 후 작업자 스레드에서 호출 스택 확인
    //호출 스택 확인으로 자신의 lock을 획득하고 다른사람의 lock을 기다리고 있음
   
        class SessionManager
        {
            static object _lock = new object();

           public static void TestSession()
            {
                lock(_lock)
                {

                }
            }

           public static void Test()
            {
                lock (_lock)
                {
                    UserManager.TestUser();
                }
            }
        }

        class UserManager
        {
            static object _lock = new object();

            public static void TestUser()
            {
                lock (_lock)
                {

                }
            }

            public static void Test()
            {
                lock (_lock)
                {
                    SessionManager.TestSession();
                }
            }
        }

     class Program
    {
        static int number;
      
        static void Thread_1()
        {
            for (int i = 0; i < 10000; i++)
            {
                    SessionManager.Test();
            }
        }

        static void Thread_2()
        {
            for (int i = 0; i < 10000; i++)
            {
                    UserManager.Test();
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
