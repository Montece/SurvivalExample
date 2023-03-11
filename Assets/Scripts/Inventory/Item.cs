using UnityEngine;

[System.Serializable]
public class Item
{
    public string Title; //Название предмета
    public string ID; //Уникальный идентификатор предмета
    public string Description; //Описание предмета
    public Sprite Icon; //Иконка предмета
    public int Type; //Тип предмета
}

/* ===== ТИПЫ ПРЕДМЕТОВ =====
 * 0 - Ресурс
 * 1 - Расходник (еда, вода, здоровье, ...)
 * 2 - Экипировка (топор, кирка, копье, удочка, ...)
 * 3 - 'Постройки
 */