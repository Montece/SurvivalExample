[System.Serializable]
public class Slot
{
    //===== НЕИЗМЕНЯЕМЫЕ ДАННЫЕ =====
    public Item Item = null; //Предмет в слоте

    //===== ИЗМЕНЯЕМЫЕ ДАННЫЕ =====
    public int Count = 0; //Количество предметов в слоте
    public int Durability = 0; //Прочность предмета в слоте (одного!)
}