using System;
using System.Threading;
using System.Threading.Tasks;

namespace Csharp_practice
{

    class Program
    {
        static SpinLock _lock = new SpinLock();

        //Read 할일이 많고 Write할일이 적을때 효율성이 높은 Lock
        /*Reader-Writer Lock는 데이터베이스 시스템, 파일 시스템, 캐시 관리 등과 같이 
          읽기 작업이 빈번하고 쓰기 작업이 상대적으로 드물게 발생하는 상황에서 유용하게 사용됩니다. 
          이를 통해 읽기 작업에 대한 병렬 처리를 더 많이 활용할 수 있어 전체적인 성능을 향상시킬 수 있습니다.*/
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
