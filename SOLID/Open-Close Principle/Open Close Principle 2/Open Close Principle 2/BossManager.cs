using System;
using System.Collections.Generic;
using System.Text;

namespace Open_Close_Principle_2
{
    class BossManager<T> where T : IApplicant
    {
        public Boss CreateBoss(T worker)
        {
            Boss boss = new Boss()
            {
                FirstName = worker.FirstName,
                LastName = worker.LastName
            };
            return boss;
        }
    }
}
