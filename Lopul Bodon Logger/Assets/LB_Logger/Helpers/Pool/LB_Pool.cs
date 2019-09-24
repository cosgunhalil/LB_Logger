
namespace Helpers.Pool
{
    using System.Collections.Generic;
    using UnityEngine;

    public class LB_Pool : MonoBehaviour
    {

        public GameObject PoolableObjectPrefab;

        protected Stack<LB_Poolable> pool;
        protected List<LB_Poolable> livingItems;

        protected void PopulatePool(int population)
        {
            livingItems = new List<LB_Poolable>();
            pool = new Stack<LB_Poolable>();

            for (int i = 0; i < population; i++)
            {
                AddObjectToPool(GenerateObject());
            }
        }

        protected void AddObjectToPool(LB_Poolable poolable)
        {
            pool.Push(poolable);
            poolable.Deactivate();
        }

        private LB_Poolable GenerateObject()
        {
            var item = Instantiate(PoolableObjectPrefab).GetComponent<LB_Poolable>();
            item.Deactivate();
            return item;
        }

        public LB_Poolable GetBullet()
        {
            if (pool.Count == 0)
            {
                AddObjectToPool(GenerateObject());
            }

            var item = pool.Pop();
            item.Activate();
            livingItems.Add(item);

            return item;
        }
    }
}

