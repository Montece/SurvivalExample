using UnityEngine;

public class SlotInWorld : MonoBehaviour
{
    public string ItemID;
    public int Count;
    public int Durability;

    public Slot slot;

    public void Start()
    {
        slot = new Slot();
        slot.Durability = Durability;
        slot.Count = Count;
        slot.Item = FindObjectOfType<ItemsDatabase>().GetItemByID(ItemID);
    }
}
