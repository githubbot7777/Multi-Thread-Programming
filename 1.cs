using System;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_practice
{
   
   class Program
    {
        static bool _stop = false;
        static void ThreadMain()
        {
            Console.WriteLine("쓰레드 시작");
            //Release 모드 사용시 최적화로 인해 정상적 실행 안됨
            /*
            if (_stop == false)
            {
                while (true)
                {

                }
            }
             이런 식으로 어셈블리어로 최적화됨
             쓰레드시작은 되지만 종료는 안됨
             
             해결방법: 메모리 배리어, lock, atomic
             */

            while (_stop==false)
            {

            }
            
           

            Console.WriteLine("쓰레드 종료");
        }
        static void Main(string[] args)
        {

            Task t = new Task(ThreadMain);
            t.Start();

            Thread.Sleep(1000);

            _stop = true;

            Console.WriteLine("Stop 호출");
            Console.WriteLine("종료 대기중");

            //Task가 끝날때까지 대기
            t.Wait();

            Console.WriteLine("종료 성공");
        }
    }
}
