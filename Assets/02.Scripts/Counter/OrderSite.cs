using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSite : MonoBehaviour
{
    public GameObject warning; //���� â
    public GameObject clear; //Ŭ���� â
    public GameObject orderSite;
    public GameObject exitButton;
    public GameObject counterPanel;

    public int finish;
    private int finishMax;


    void Start()
    {
        finishMax = 3;
        finish = 0;
    }

    private void Update()
    {
        if (finish == finishMax)
        {
            clear.SetActive(true);
            StartCoroutine("ExitOrder");
        }
    }

    public void Enter()
    {
        orderSite.SetActive(true);
    }

    public void Exit()
    {
        orderSite.SetActive(false);
    }

    IEnumerator ExitOrder()
    {
        yield return new WaitForSeconds(2f);
        clear.SetActive(false);
        counterPanel.SetActive(false);
    }
}
