using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    public OrderSite orderSite;

    [SerializeField] private Text orderName; //�ֹ��� ���� �̸�
    [SerializeField] private Text Quantity; //���� ǥ��
    [SerializeField] private InputField orderQuantity; //�Է� ����
    [SerializeField] public Button orderButton; //�ֹ� ��ư

    private int curQuantity; //���� ����
    private int maxQuantity; //�ִ� ����


    void Start()
    {
        setQuantity();
    }

    /*private void Update()
    {
        if (orderSite.complete)
        {
            orderSite.clear.SetActive(true);
            StartCoroutine("ExitOrder");
        }
    }*/

    public void setQuantity()
    {
        curQuantity = Random.Range(10, 90);
        maxQuantity = 100;

        Quantity.text = curQuantity.ToString() + "/" + maxQuantity.ToString();
    }

    public void Input()
    {
        int temp = curQuantity + int.Parse(orderQuantity.text);
        if ( temp == maxQuantity)
        {
            curQuantity += int.Parse(orderQuantity.text); //���� ������ �Է� ������ŭ ����
            Quantity.text = curQuantity.ToString() + "/" + maxQuantity.ToString();
            orderSite.finish++;
            orderButton.interactable = false; //�ֹ� ���̻� ���ϰ� ��ư ��Ȱ��ȭ
        }
        else if( temp < maxQuantity)
        {
            curQuantity += int.Parse(orderQuantity.text); //���� ������ �Է� ������ŭ ����
            Quantity.text = curQuantity.ToString() + "/" + maxQuantity.ToString();
        }
        else if ( temp > maxQuantity)
        {
            orderSite.warning.SetActive(true);
            StartCoroutine("WarningExitDelay");
        }
    }

    public void ResetQuantity()
    {
        setQuantity();
        orderQuantity.text = "";
        orderButton.interactable = true;
    }

    IEnumerator WarningExitDelay()
    {
        yield return new WaitForSeconds(2f);
        orderSite.warning.SetActive(false);
    }

    /*IEnumerator ExitOrder()
    {
        yield return new WaitForSeconds(2f);
        orderSite.ResetOrder();
        orderSite.clear.SetActive(false);
        orderSite.counterPanel.SetActive(false);
    }*/

}
