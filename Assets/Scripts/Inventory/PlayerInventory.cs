using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public GameObject InventoryZone;
    public GameObject SlotPrefab;

    public Slot[] Slots = null;
    public ItemsDatabase ItemsDatabase;

    private void Start()
    {
        InventoryZone.SetActive(false);

        Slots = new Slot[27];
        for (int i = 0; i < Slots.Length; i++) Slots[i] = new Slot();

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
                //Инвентарь открыт
                RefreshInventory();
            }
            else
            {
                //Инвентарь закрыт
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

            if (slot.Item != null) //Есть ли предмет в инвентаре?
            {
                slotGameObject.GetChild(0).GetComponent<Image>().sprite = slot.Item.Icon; //Иконка
                slotGameObject.GetChild(1).GetComponent<TMP_Text>().text = slot.Item.Title; //Название

                if (slot.Item.IsStackable)
                {
                    slotGameObject.GetChild(2).GetComponent<TMP_Text>().text = slot.Count.ToString(); //Количество
                }
                else slotGameObject.GetChild(2).GetComponent<TMP_Text>().text = ""; //Количество

                if (slot.Item.IsDurability)
                {
                    slotGameObject.GetChild(3).GetComponent<TMP_Text>().text = slot.Durability.ToString(); //Прочность
                }
                else slotGameObject.GetChild(3).GetComponent<TMP_Text>().text = ""; //Прочность
            }
            else
            {
                slotGameObject.GetChild(0).gameObject.SetActive(false); //Иконка
                slotGameObject.GetChild(1).GetComponent<TMP_Text>().text = ""; //Название
                slotGameObject.GetChild(2).GetComponent<TMP_Text>().text = ""; //Количество
                slotGameObject.GetChild(3).GetComponent<TMP_Text>().text = ""; //Прочность
            }
        }
    }
}
