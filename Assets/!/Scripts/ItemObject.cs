using UnityEngine;
using UnityEngine.Events;

public class ItemObject : MonoBehaviour, Pickable
{
    [SerializeField] protected ItemSO item;
    public event UnityAction<ItemSO> OnPickUp = delegate { }; 

    public void PickUp(Inventory inventory)
    {
        if (inventory.AddItem(item))
        {
            OnPickUp.Invoke(item);
            Destroy(gameObject);
        }
    }
}
