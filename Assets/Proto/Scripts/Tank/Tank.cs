using System.Collections.Generic;
using System.Linq;

namespace Proto.Scripts.Tank
{
    using Item;

    public interface ITank<in T> where T : IItem
    {
        float  TotalCost();
        float TotalVolume();
        void AddItem(T item);
        void Clear();
    }

    public interface IOffloader<T> where T : IItem
    {
        List<T> Offload();
    }
    
    public class Tank : ITank<IItem>, IOffloader<IItem>
    {
        public float TotalCost()
        {
            return _items.Sum(item => item.Cost());
        }

        public float TotalVolume()
        {
            return _items.Sum(item => item.Volume());
        }

        public void AddItem(IItem item)
        {
            if (ValidateItem(item))
            {
                _items.Add(item);
            }
        }

        public List<IItem> Offload()
        {
            return _items.ToList();
        }

        public void Clear()
        {
            _items.Clear();
        }
        
        private static bool ValidateItem(IItem item)
        {
            return item != null &&
                   item.Cost() >= 0 &&
                   item.Volume() > 0;
        }
        
        private readonly List<IItem>  _items = new List<IItem>();
    }
}

