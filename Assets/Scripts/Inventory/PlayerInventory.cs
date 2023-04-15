using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public MouseLook MouseLook_;
    public GameObject InventoryZone;
    public GameObject ArmZone;
    public GameObject SlotPrefab;
    public GameObject BagPrefab;

    public Slot Arm = null;
    public Slot[] Slots = null;
    public ItemsDatabase ItemsDatabase;

    private void Start()
    {
        InventoryZone.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        MouseLook_.enabled = true;

        Slots = new Slot[27];
        for (int i = 0; i < Slots.Length; i++) Slots[i] = new Slot();
        Arm = new Slot();
        RefreshArm();

        AddToInventory(new Slot()
        {
            Item = ItemsDatabase.GetItemByID("axe"),
            Count = 1,
            Durability = 100
        });

        AddToInventory(new Slot()
        {
            Item = ItemsDatabase.GetItemByID("axe"),
            Count = 1,
            Durability = 100
        });

        AddToInventory(new Slot()
        {
            Item = ItemsDatabase.GetItemByID("axe"),
            Count = 1,
            Durability = 100
        });

        AddToInventory(new Slot()
        {
            Item = ItemsDatabase.GetItemByID("stick"),
            Count = 5,
            Durability = 0
        });

        AddToInventory(new Slot()
        {
            Item = ItemsDatabase.GetItemByID("axe"),
            Count = 1,
            Durability = 100
        });

        AddToInventory(new Slot()
        {
            Item = ItemsDatabase.GetItemByID("stick"),
            Count = 5,
            Durability = 0
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryZone.SetActive(!InventoryZone.activeSelf);

            if (InventoryZone.activeSelf)
            {
                //��������� ������
                RefreshInventory();
                Cursor.lockState = CursorLockMode.None;
                MouseLook_.enabled = false;
            }
            else
            {
                //��������� ������
                Cursor.lockState = CursorLockMode.Locked;
                MouseLook_.enabled = true;
            }
        }
    }

    public bool AddToInventory(Slot newSlot)
    {
        if (newSlot == null) return false;
        if (newSlot.Item == null) return false;

        if (newSlot.Item.IsStackable)
        {
            for (int i = 0; i < Slots.Length; i++)
            {
                if (Slots[i].Item != null && Slots[i].Item.ID == newSlot.Item.ID)
                {
                    Slots[i].Count += newSlot.Count;
                    return true;
                }
            }
        }

        for (int i = 0; i < Slots.Length; i++)
        {
            if (Slots[i].Item == null)
            {
                Slots[i].Item = newSlot.Item;
                Slots[i].Count = newSlot.Count;
                Slots[i].Durability = newSlot.Durability;
                return true;
            }
        }

        return false;
    }

    private void RefreshArm()
    {
        HideArm();
        ShowArm();
    }

    private void HideArm()
    {
        foreach (Transform child in ArmZone.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void ShowArm()
    {
        Transform slotGameObject = Instantiate(SlotPrefab, ArmZone.transform).transform;
        slotGameObject.GetComponent<SlotUI>().Slot_ = Arm;
        slotGameObject.GetComponent<SlotUI>().SlotZone = "Arm";

        if (Arm.Item != null) //���� �� ������� � ����?
        {
            slotGameObject.GetChild(0).GetComponent<Image>().sprite = Arm.Item.Icon; //������
            slotGameObject.GetChild(1).GetComponent<TMP_Text>().text = Arm.Item.Title; //��������

            if (Arm.Item.IsStackable)
            {
                slotGameObject.GetChild(2).GetComponent<TMP_Text>().text = Arm.Count.ToString(); //����������
            }
            else slotGameObject.GetChild(2).GetComponent<TMP_Text>().text = ""; //����������

            if (Arm.Item.IsDurability)
            {
                slotGameObject.GetChild(3).GetComponent<TMP_Text>().text = Arm.Durability.ToString(); //���������
            }
            else slotGameObject.GetChild(3).GetComponent<TMP_Text>().text = ""; //���������
        }
        else
        {
            slotGameObject.GetChild(0).gameObject.SetActive(false); //������
            slotGameObject.GetChild(1).GetComponent<TMP_Text>().text = ""; //��������
            slotGameObject.GetChild(2).GetComponent<TMP_Text>().text = ""; //����������
            slotGameObject.GetChild(3).GetComponent<TMP_Text>().text = ""; //���������
        }
    }

    private void RefreshInventory()
    {
        HideSlots();
        ShowSlots();
    }

    private void HideSlots()
    {
        foreach (Transform child in InventoryZone.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void ShowSlots()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            Transform slotGameObject = Instantiate(SlotPrefab, InventoryZone.transform).transform;
            Slot slot = Slots[i];
            slotGameObject.GetComponent<SlotUI>().Slot_ = slot;
            slotGameObject.GetComponent<SlotUI>().SlotZone = "Inventory";

            if (slot.Item != null) //���� �� ������� � ���������?
            {
                slotGameObject.GetChild(0).GetComponent<Image>().sprite = slot.Item.Icon; //������
                slotGameObject.GetChild(1).GetComponent<TMP_Text>().text = slot.Item.Title; //��������

                if (slot.Item.IsStackable)
                {
                    slotGameObject.GetChild(2).GetComponent<TMP_Text>().text = slot.Count.ToString(); //����������
                }
                else slotGameObject.GetChild(2).GetComponent<TMP_Text>().text = ""; //����������

                if (slot.Item.IsDurability)
                {
                    slotGameObject.GetChild(3).GetComponent<TMP_Text>().text = slot.Durability.ToString(); //���������
                }
                else slotGameObject.GetChild(3).GetComponent<TMP_Text>().text = ""; //���������
            }
            else
            {
                slotGameObject.GetChild(0).gameObject.SetActive(false); //������
                slotGameObject.GetChild(1).GetComponent<TMP_Text>().text = ""; //��������
                slotGameObject.GetChild(2).GetComponent<TMP_Text>().text = ""; //����������
                slotGameObject.GetChild(3).GetComponent<TMP_Text>().text = ""; //���������
            }
        }
    }

    public void MoveSlotFromBackpackToArm(SlotUI slotUI)
    {
        Slot slot = slotUI.Slot_;
        string zone = slotUI.SlotZone;

        if (slot.Item != null)
        {
            if (zone == "Inventory")
            {
                if (Arm.Item != null)
                {
                    Slot tempSlot = new Slot();
                    tempSlot.Item = Arm.Item;
                    tempSlot.Count = Arm.Count;
                    tempSlot.Durability = Arm.Durability;

                    Arm.Item = slot.Item;
                    Arm.Count = slot.Count;
                    Arm.Durability = slot.Durability;

                    slot.Item = tempSlot.Item;
                    slot.Count = tempSlot.Count;
                    slot.Durability = tempSlot.Durability;
                }
                else
                {
                    Arm.Item = slot.Item;
                    Arm.Count = slot.Count;
                    Arm.Durability = slot.Durability;

                    slot.Item = null;
                    slot.Count = 0;
                    slot.Durability = 0;
                }
            }

            if (zone == "Arm")
            {
                bool result = AddToInventory(slot);

                if (result)
                {
                    slot.Item = null;
                    slot.Count = 0;
                    slot.Durability = 0;
                }
            }

            RefreshInventory();
            RefreshArm();
        }
    }

    public void DropSlotFromBackpack(SlotUI slotUI)
    {
        Slot slot = slotUI.Slot_;

        GameObject bag = Instantiate(BagPrefab);
        bag.transform.position = transform.position + transform.forward * 2f;

        Slot slot_ = new Slot();
        slot_.Item = slot.Item;
        slot_.Count = slot.Count;
        slot_.Durability = slot.Durability;
        bag.GetComponent<SlotInWorld>().SetSlot(slot_);

        slot.Item = null;
        slot.Count = 0;
        slot.Durability = 0;

        RefreshInventory();
    }
}
