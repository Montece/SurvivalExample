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
        RegisterItem("�����", "axe", 0, "���������� ��� ������ ������ ��� ������� �� ����� ��������.");
    }

    ///<summary> ����������� �������� � ���� ������ </summary>
    private void RegisterItem(string title, string id, int type, string description)
    {
        Item item = new Item();
        item.Title = title;
        item.ID = id;
        item.Description = description;
        item.Icon = null; //�������!
        item.Type = type;
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