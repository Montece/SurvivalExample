using UnityEngine;

[System.Serializable]
public class Item
{
    public string Title; //�������� ��������
    public string ID; //���������� ������������� ��������
    public string Description; //�������� ��������
    public Sprite Icon; //������ ��������
    public ItemType Type; //��� ��������
    public bool IsStackable; //����� �� ���������?
    public bool IsDurability; //����� �� ����� ���������?
}

//===== ���� ��������� =====
public enum ItemType
{
    Resource, // 0 - ������
    Consumable, // 1 - ��������� (���, ����, ��������, ...)
    Equipment, // 2 - ���������� (�����, �����, �����, ������, ...)
    Buildings // 3 - '���������
}