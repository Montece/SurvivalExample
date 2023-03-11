using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Slot[] Slots = null;
    public ItemsDatabase ItemsDatabase;

    void Start()
    {
        Slots = new Slot[27];
        for (int i = 0; i < Slots.Length; i++) Slots[i] = new Slot();

        Item item = ItemsDatabase.GetItemByID("axe");
        Debug.Log(item);
        Slots[2].Item = item;
        Slots[2].Count = 1;
        Slots[2].Durability = 100;
    }

    void Update()
    {
        
    }
}
