using System;
using System.Collections.Generic;
using System.Linq;

namespace Proto.Scripts.Tank
{
    using Item;

    public interface ITank<in T> where T : IItem
    {
        float  TotalCost();
        float TotalVolume();
        bool AddItem(T item);
        void Clear();
    }

    public interface IOffloader<T> where T : IItem
    {
        List<T> Offload();
    }
    
    public class Tank : ITank<IItem>, IOffloader<IItem>
    {
        public Tank(float maxVolume)
        {
            if (maxVolume < 0)
            {
                throw new ArgumentException("maxVolume must be >= 0");
            }
            _maxVolume = maxVolume;
        }
        public float TotalCost()
        {
            return _items.Sum(item => item.Cost());
        }

        public float TotalVolume()
        {
            return _items.Sum(item => item.Volume());
        }

        public bool AddItem(IItem item)
        {
            if (!ValidateItem(item)) return false;
            _items.Add(item);
            return true;
        }

        public List<IItem> Offload()
        {
            return _items.ToList();
        }

        public void Clear()
        {
            _items.Clear();
        }
        
        private bool ValidateItem(IItem item)
        {
            return item != null &&
                   item.Cost() >= 0 &&
                   item.Volume() > 0 && 
                   TotalVolume() + item.Volume() <= _maxVolume;
        }
        
        private readonly List<IItem>  _items = new List<IItem>();
        private readonly float _maxVolume;
    }
}

