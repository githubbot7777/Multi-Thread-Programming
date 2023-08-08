using System;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_practice
{
    //Thread Local Storage: Thread마다 고유한 공간
    class Program
    {
                                                                                          //ThreadPool에 없는 경우 새로 만든다
        static ThreadLocal<string> ThreadName = new ThreadLocal<string>(() => { return $"My Name is {Thread.CurrentThread.ManagedThreadId}"; });

        static void WhoAmI()
        {
            bool repeat = ThreadName.IsValueCreated;//재사용 여부
            if(repeat)
                Console.WriteLine(ThreadName.Value+" (repeat)");
            else
                Console.WriteLine(ThreadName.Value);
        }
        static void Main(string[] args)
        {
            ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMinThreads(3, 3);

            Parallel.Invoke(WhoAmI, WhoAmI, WhoAmI, WhoAmI, WhoAmI, WhoAmI, WhoAmI, WhoAmI, WhoAmI);

            ThreadName.Dispose();//ThreadLocal<T> 인스턴스 정리 및 해제

            
        }
    }
       

}
