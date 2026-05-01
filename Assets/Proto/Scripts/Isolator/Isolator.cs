using System.Collections.Generic;
using System.Linq;

namespace Proto.Scripts.Isolator
{
    using Item;
    using Tank;
    
    public interface IIsolator<in T> where T: IOffloader<IItem>
    {
        float TotalCost();
    }

    public interface IUploader<in T> where T : IOffloader<IItem>
    {
        void Upload(T offloader);
    }
    
    public class Isolator : IIsolator<IOffloader<IItem>>, IUploader<IOffloader<IItem>>
    {
        public float TotalCost()
        {
            return _items.Sum(item => item.Cost());    
        }
        
        public void Upload(IOffloader<IItem> offloader)
        {
            _items.AddRange(offloader.Offload());
        }

        private readonly List<IItem> _items =  new List<IItem>();    
    }
}
