using System;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_practice
{
   
   class Program
    {
       
        static void ThreadMain(object state)
        {
    
           for(int i=0;i<5;i++)
              Console.WriteLine("Hello Thread!");
        }
        static void Main(string[] args)
        {
           
            
            ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMaxThreads(5, 5);

            for (int i = 0; i < 5; i++)
            {
                Task t = new Task(() => { while (true) { } }, TaskCreationOptions.LongRunning);
                t.Start();
            }

            //for (int i = 0; i < 4; i++)
            //   ThreadPool.QueueUserWorkItem((obj) => { while (true) { } });

            //thread 필요할때마다 pool에서 꺼내쓰고 다 쓰면 대기장소에 반납 
            ThreadPool.QueueUserWorkItem(ThreadMain);

            while(true)
            {

            }
            
        }
    }
}
