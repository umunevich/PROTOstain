using UnityEngine;

namespace Proto.Scripts.Item
{
    public interface IItem
    {
        float Cost();
        float Volume();
        float Size();
    }

    public interface IPickable
    {
        void OnPickUp();
    }
    
    public class Item : MonoBehaviour, IItem, IPickable
    {
        [SerializeField] private float cost;
        [SerializeField] private float volume;
        [SerializeField] private float size;
        
        public float Cost() => cost;
        public float Volume() => volume;
        public float Size() => size;

        public void OnPickUp()
        {
            Destroy(gameObject);
        }
    }
}
