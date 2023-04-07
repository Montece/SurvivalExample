using UnityEngine;

public class SlotUI : MonoBehaviour
{
    public Slot Slot_;
    public string SlotZone;

    public void OnClick()
    {
        FindObjectOfType<PlayerInventory>().MoveSlotFromBackpackToArm(this);
    }
}