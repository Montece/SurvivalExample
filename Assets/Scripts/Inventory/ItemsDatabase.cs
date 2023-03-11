using System.Collections.Generic;
using UnityEngine;

public class ItemsDatabase : MonoBehaviour
{
    public List<Item> Items = new List<Item>();

    private void Awake()
    {
        Initializate();
    }

    ///<summary> Инициализация базы данных предметов </summary>
    public void Initializate()
    {
        RegisterItem("Топор", "axe", 0, "Инструмент для добычи дерева или обороны от диких животных.");
    }

    ///<summary> Регистрация предмета в базе данных </summary>
    private void RegisterItem(string title, string id, int type, string description)
    {
        Item item = new Item();
        item.Title = title;
        item.ID = id;
        item.Description = description;
        item.Icon = null; //Сделать!
        item.Type = type;
        Items.Add(item);
    }

    ///<summary> Получить предмет по его уникальному идентификатору </summary>
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