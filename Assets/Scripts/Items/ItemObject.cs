using UnityEngine;

public class ItemObject : MonoBehaviour, Interactable
{
    [SerializeField] public ItemData itemData;

    public int GetPrice() => itemData.price;
    
    public void Interact()
    {
        Destroy(gameObject);
    }
}
