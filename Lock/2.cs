using System;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_practice
{
    class SpinLock
    {
        volatile bool _locked = false;
        public void Acquire()
        {
            //lock을 얻는 과정이 두개로 나눠져 있다. (1,2)
            //->올바른 스핀락이 아니다.
            //1.
            while(_locked)
            {
                //잠김이 풀리기를 기다린다
            }

            //2.
            _locked = true;

        }
        public void Release()
        {

            _locked = false;
        }
    }

     class Program
    {
       
        static void Main(string[] args)
        {
           

        }
        
    }

}
