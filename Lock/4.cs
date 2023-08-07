using System;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_practice
{
    //ARE 는 waittone 마다 set으로 release 시켜줘야함(자동문)
    //MRE 는 waitone 여러개 있어도 한번의 set으로 모두 release 가능(수동문)

     class Program
    {

        private static AutoResetEvent obj = new AutoResetEvent(false);

        static void Main()
        {
            new Thread(test).Start();
            Console.ReadLine();
            obj.Set();

            Console.ReadLine();
            obj.Set();
        }

        private static void test()
        {
           

            Console.WriteLine("start 1");

            obj.WaitOne();

            Console.WriteLine("ends 1");

            Console.WriteLine("start 2");

            obj.WaitOne();

            Console.WriteLine("ends 2");
        }
    }

}
