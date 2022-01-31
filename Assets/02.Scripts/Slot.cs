using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [HideInInspector]
    public FoodProperty food;
    public Cook cook;

    private List<InventorySlot> slots;

    public Image image;

    public Image cookGuage;

    public float curCookTime;
    public bool isCooking;
    public bool finish;

    // public GameObject notCookPanel;  

    private void Start()
    {
        slots = new List<InventorySlot>();

        // notCookPanel.SetActive(false);
        isCooking = false;
        cookGuage.fillAmount = 0;
        curCookTime = 0;
        finish = false;
    }

    private void Update()
    {
        if (isCooking)
        {
            curCookTime += Time.deltaTime;
            cookGuage.fillAmount = curCookTime / food.cookTime;
            if (curCookTime >= food.cookTime)
            {
                isCooking = false;
                finish = true;
                cook.DoneCook(this); ;
                Debug.Log("�������� �Ϸ�");
                cookGuage.fillAmount = 0;
                cook.use = false;
            }
        }
        else
        {
            curCookTime = 0;
 
        }
    }

    public void SetFood(FoodProperty _food)
    {
        this.food = _food;

        if (_food == null)
        {
            image.enabled = false;
            gameObject.name = "Empty";
        }
        else
        {
            image.enabled = true;
            gameObject.name = food.foodName;
            image.sprite = food.foodSprite;
        }
    }

    public void Cooking()
    {
        if(cook.use == false)
        {
            cook.use = true;
            Debug.Log("��������");
            isCooking = true;
        }
        else
        {
            Debug.Log("�����Ұ�");
        }
    }

    /*public void ExitCooking()
    {
        cookingPanel.SetActive(false);
        isCooking = false; //�����ϴ� �� ���� ����
    }

    public void ExitNotCook()
    {
        notCookPanel.SetActive(false);
    }*/

}