using UnityEngine;

[System.Serializable]
public class Item
{
    public string Title; //�������� ��������
    public string ID; //���������� ������������� ��������
    public string Description; //�������� ��������
    public Sprite Icon; //������ ��������
    public int Type; //��� ��������
}

/* ===== ���� ��������� =====
 * 0 - ������
 * 1 - ��������� (���, ����, ��������, ...)
 * 2 - ���������� (�����, �����, �����, ������, ...)
 * 3 - '���������
 */