using UnityEngine;

public class SlotUI : MonoBehaviour
{
    public Slot Slot_;
    public string SlotZone;

    public void OnClick()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            FindObjectOfType<PlayerInventory>().DropSlotFromBackpack(this);
        }
        else
        {
            FindObjectOfType<PlayerInventory>().MoveSlotFromBackpackToArm(this);
        }
    }
}