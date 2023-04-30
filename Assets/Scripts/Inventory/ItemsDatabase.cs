using System.Collections.Generic;
using UnityEngine;

public class ItemsDatabase : MonoBehaviour
{
    public List<Item> Items = new List<Item>();

    private void Awake()
    {
        Initializate();
    }

    ///<summary> ������������� ���� ������ ��������� </summary>
    public void Initializate()
    {
        RegisterItem("�����", "stick", ItemType.Resource, "������������ �����.");
        RegisterItem("������", "wood", ItemType.Resource, "��������������� ������.");
        RegisterItem("������", "stone", ItemType.Resource, "���������� ������.");

        RegisterItem("�����", "axe", ItemType.Equipment, "���������� ��� ������ ������ ��� ������� �� ����� ��������.");
        RegisterItem("�����", "pickaxe", ItemType.Equipment, "���������� ��� ������ �����.");

        RegisterConsumable("�����", "coconut", ItemType.Consumable, "��������� ����, �������� ����������� ���������.", 10, 10, 5);
    }

    ///<summary> ����������� �������� � ���� ������ </summary>
    private void RegisterItem(string title, string id, ItemType type, string description)
    {
        Item item = new Item();
        item.Title = title;
        item.ID = id;
        item.Description = description;
        item.Icon = Resources.Load<Sprite>("ItemIcons\\" + id);
        item.Type = type;

        switch (type)
        {
            case ItemType.Resource:
                item.IsStackable = true;
                item.IsDurability = false;
                break;
            case ItemType.Consumable:
                item.IsStackable = true;
                item.IsDurability = false;
                break;
            case ItemType.Equipment:
                item.IsStackable = false;
                item.IsDurability = true;
                break;
            case ItemType.Buildings:
                item.IsStackable = true;
                item.IsDurability = false;
                break;
            default:
                break;
        }

        Items.Add(item);
    }

    ///<summary> ����������� ���������� � ���� ������ </summary>
    private void RegisterConsumable(string title, string id, ItemType type, string description, int addFood, int addWater, int addHealth)
    {
        Consumable item = new Consumable();
        item.Title = title;
        item.ID = id;
        item.Description = description;
        item.Icon = Resources.Load<Sprite>("ItemIcons\\" + id);
        item.Type = type;
        item.AddFood = addFood;
        item.AddWater = addWater;
        item.AddHealth = addHealth;

        switch (type)
        {
            case ItemType.Resource:
                item.IsStackable = true;
                item.IsDurability = false;
                break;
            case ItemType.Consumable:
                item.IsStackable = true;
                item.IsDurability = false;
                break;
            case ItemType.Equipment:
                item.IsStackable = false;
                item.IsDurability = true;
                break;
            case ItemType.Buildings:
                item.IsStackable = true;
                item.IsDurability = false;
                break;
            default:
                break;
        }

        Items.Add(item);
    }

    ///<summary> �������� ������� �� ��� ����������� �������������� </summary>
    public Item GetItemByID(string id)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].ID == id) 
            {
                return Items[i];
            }
        }

        return null;
    }
}