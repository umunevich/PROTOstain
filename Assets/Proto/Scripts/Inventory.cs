using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Dont destroy on load
    [SerializeField] public float maxCapacity = 100f;

    public float currentVolume = 0f;
    public List<ItemSO> itemsInside = new List<ItemSO>();

    public bool CanAddItem(ItemSO item)
    {
        return currentVolume + item.volume <= maxCapacity;
    }

    public bool AddItem(ItemSO item)
    {
        if (CanAddItem(item))
        {
            itemsInside.Add(item);
            currentVolume += item.volume;
            Debug.Log($"Предмет {item.itemName} додано. Бак заповнено на: {currentVolume}/{maxCapacity}");
            return true;
        }
        Debug.Log("Бак переповнений! Потрібно розвантаження в Ізолятор.");
        return false;
    }

    public void ClearToIsolator(out int totalMoney)
    {
        totalMoney = 0;
        foreach (ItemSO item in itemsInside)
        {
            totalMoney += item.price;
        }
        itemsInside.Clear();
        currentVolume = 0;
    }
}
