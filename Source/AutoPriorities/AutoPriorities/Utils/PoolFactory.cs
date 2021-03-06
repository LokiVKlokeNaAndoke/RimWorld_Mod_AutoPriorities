using System.Collections.Generic;

namespace AutoPriorities.Utils
{
    public class PoolFactory<TPoolable, TArgs>
        where TPoolable : IPoolable<TPoolable, TArgs>, new()
        where TArgs : IPoolArgs
    {
        private Queue<TPoolable> _pool = new Queue<TPoolable>();

        public TPoolable Acquire(TArgs args)
        {
            var item = _pool.Count > 0 ? _pool.Dequeue() : new TPoolable();
            item.Initialize(args);
            return item;
        }

        public void Pool(TPoolable item)
        {
            item.Deinitialize();
            _pool.Enqueue(item);
        }
    }

    public interface IPoolable<TPoolable, TArgs>
        where TArgs : IPoolArgs
    {
        TPoolable Initialize(TArgs args);

        void Deinitialize();
    }

    public interface IPoolArgs
    {
    }
}