

using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string name;
    public int count;

    public Item(string itemName, int itemCount)
    {
        name = itemName;
        count = itemCount;
    }
}