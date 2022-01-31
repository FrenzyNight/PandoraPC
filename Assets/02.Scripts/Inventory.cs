using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Transform rootSlot;
    public Cook cook;

    private List<InventorySlot> slots;

    void Start()
    {
        slots = new List<InventorySlot>();

        int slotCnt = rootSlot.childCount;
        for(int i = 0; i < slotCnt; i++)
        {
            var slot = rootSlot.GetChild(i).GetComponent<InventorySlot>();

            slots.Add(slot);
        }
        cook.doneCook += Cooked;
    }

    void Cooked(FoodProperty food)
    {
        Debug.Log(food.foodName);
        var emptySlot = slots.Find(f => f.food == null || f.food.foodName == string.Empty); //���� ��ȸ�ϸ鼭 ����ִ� �� ã��

        if (emptySlot != null)
        {
            Debug.Log("���Կ� �ֱ�!");
            emptySlot.SetFood(food); //�ֺ� ���� ������ ���� �ֱ�
        }
        else
        {
            Debug.Log("������ ��á��");
            //��á�ٴ� �޼���â ����
        }
    }
}
