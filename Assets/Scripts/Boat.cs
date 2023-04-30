using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public ItemsDatabase ItemsDatabase;
    public PlayerInventory PlayerInventory;

    public bool IsWork = false;

    public bool Repair()
    {
        bool hasWood = false;
        Slot needHaveWood = new Slot()
        {
            Item = ItemsDatabase.GetItemByID("wood"),
            Count = 5,
            Durability = 0
        };

        bool hasStone = false;
        Slot needHaveStone = new Slot()
        {
            Item = ItemsDatabase.GetItemByID("stone"),
            Count = 5,
            Durability = 0
        };

        foreach (Slot slot in PlayerInventory.Slots)
        {
            if (slot.Item != null && !hasWood)
            {
                if (slot.Item.ID == needHaveWood.Item.ID)
                {
                    if (slot.Count >= needHaveWood.Count)
                    {
                        hasWood = true;
                    }
                }
            }

            if (slot.Item != null && !hasStone)
            {
                if (slot.Item.ID == needHaveStone.Item.ID)
                {
                    if (slot.Count >= needHaveStone.Count)
                    {
                        hasStone = true;
                    }
                }
            }
        }

        if (hasWood && hasStone)
        {
            //Забираем

            bool takeWood = false;
            bool takeStone = false;

            foreach (Slot slot in PlayerInventory.Slots)
            {
                if (slot.Item != null && !takeWood)
                {
                    if (slot.Item.ID == needHaveWood.Item.ID)
                    {
                        if (slot.Count >= needHaveWood.Count)
                        {
                            slot.Count -= needHaveWood.Count;
                            if (slot.Count <= 0)
                            {
                                slot.Item = null;
                                slot.Count = 0;
                                slot.Durability = 0;
                            }
                            takeWood = true;
                        }
                    }
                }

                if (slot.Item != null && !takeStone)
                {
                    if (slot.Item.ID == needHaveStone.Item.ID)
                    {
                        if (slot.Count >= needHaveStone.Count)
                        {
                            slot.Count -= needHaveStone.Count;
                            if (slot.Count <= 0)
                            {
                                slot.Item = null;
                                slot.Count = 0;
                                slot.Durability = 0;
                            }
                            takeStone = true;
                        }
                    }
                }
            }

            IsWork = true;
            return true;
        }
        else
        {
            return false;
        }
    }
}
