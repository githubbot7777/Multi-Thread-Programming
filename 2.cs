using System;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_practice
{
   
   class Program
    {
       
        static void ThreadMain()
        {
         
            while(true)
              Console.WriteLine("Hello Thread!");
        }
        static void Main(string[] args)
        {
            Thread t = new Thread(ThreadMain);
            t.Name = "Test Thread";
            //thread 기본적으로 foreground 스레드임
            t.IsBackground = true;
            t.Start();
            Console.WriteLine("Waiting For Thread");
            //스레드가 종료될때까지 대기
            t.Join();

            Console.WriteLine("Hello World!");
        }
    }
}
