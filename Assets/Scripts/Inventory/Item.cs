using UnityEngine;

[System.Serializable]
public class Item
{
    public string Title; //Название предмета
    public string ID; //Уникальный идентификатор предмета
    public string Description; //Описание предмета
    public Sprite Icon; //Иконка предмета
    public ItemType Type; //Тип предмета
    public bool IsStackable; //Может ли стакаться?
    public bool IsDurability; //Может ли иметь прочность?
}

//===== ТИПЫ ПРЕДМЕТОВ =====
public enum ItemType
{
    Resource, // 0 - Ресурс
    Consumable, // 1 - Расходник (еда, вода, здоровье, ...)
    Equipment, // 2 - Экипировка (топор, кирка, копье, удочка, ...)
    Buildings // 3 - 'Постройки
}