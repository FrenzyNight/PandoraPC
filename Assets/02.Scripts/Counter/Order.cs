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
    [SerializeField] private Button orderButton; //�ֹ� ��ư

    public int curQuantity; //���� ����
    public int maxQuantity; //�ִ� ����


    void Start()
    {
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

    IEnumerator WarningExitDelay()
    {
        yield return new WaitForSeconds(2f);
        orderSite.warning.SetActive(false);
    }

}
