using UnityEngine;

public class SlotInWorld : MonoBehaviour
{
    public string ItemID;
    public int Count;
    public int Durability;

    private Slot slot;

    public void Start()
    {
        if (slot == null)
        {
            slot = new Slot();
            slot.Durability = Durability;
            slot.Count = Count;
            slot.Item = FindObjectOfType<ItemsDatabase>().GetItemByID(ItemID);
        }
    }

    public Slot GetSlot()
    {
        return slot;
    }

    public void SetSlot(Slot slot_)
    {
        slot = slot_;
    }
}
