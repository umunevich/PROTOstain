using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public int price;
    public float volume;
}
