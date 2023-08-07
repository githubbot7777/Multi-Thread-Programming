using System;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_practice
{

    class Program
    {
        static SpinLock _lock = new SpinLock();

        //Read 할일이 많고 Write할일이 적을때 효율성이 높은 Lock
        static ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();

        class Reward
        {

        }

        static Reward GetRewardById(int id)
        {
            _rwLock.EnterReadLock();

            _rwLock.ExitReadLock();

            return null;
        }

        static void AddReward(Reward reward)
        {
            _rwLock.EnterWriteLock();

            _rwLock.ExitWriteLock();

          
        }

        static void Main(string[] args)
        {

            
        }
    }
       

}
