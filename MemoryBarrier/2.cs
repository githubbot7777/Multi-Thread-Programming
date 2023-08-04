using System;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_practice
{

    class Program
    {
        int _answer;
        bool _complete;

        void A()
        {
            _answer = 123;
            Thread.MemoryBarrier();// _answer write에 대한 가시성 확보
            _complete = true;
            Thread.MemoryBarrier();// _complete write에 대한 가시성 확보
        }

        void B()
        {
            Thread.MemoryBarrier();// _complete 읽기전에 가시성 확보
            if(_complete)
            {
                Thread.MemoryBarrier();// _answer 읽기전에 가시성 확보
                Console.WriteLine(_answer);
            }
        }


        static void Main(string[] args)
        {

        }
        
    }

}
