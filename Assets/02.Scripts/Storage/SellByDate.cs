using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SellByDate : MonoBehaviour
{
    public Storage storage;

    private DateTime today;
    private DateTime date;

    int randomNum;
    public Text sellbyDate;

    public bool bad;

    public GameObject child;

    private void Start()
    {
        sellbyDate = child.GetComponent<Text>();

        randomNum = UnityEngine.Random.Range(-500, 365);
        today = DateTime.Today;
        date = today.AddDays(randomNum);

        sellbyDate.text = date.ToString("yy/MM/dd");

        if (DateTime.Compare(today, date) < 0) //������� ����������
        {
            bad = false;

        }
        else
        {
            bad = true; //������� �����ų� ���ñ�����
            storage.badMax++;
        }
    }


    public void OnClick()
    {
        if(bad == false)
        {
            storage.warning.SetActive(true);
            StartCoroutine("WarningExitDelay");
        }
        else
        {
            storage.badCnt++;
            this.GetComponent<Button>().interactable = false;
            if (storage.badCnt == storage.badMax)
            {
                storage.clear.SetActive(true);
                StartCoroutine("ClearExitDelay");
            }
        }
    }

    IEnumerator WarningExitDelay()
    {
        yield return new WaitForSeconds(2f);
        storage.warning.SetActive(false);
        storage.panel.SetActive(false);
    }

    IEnumerator ClearExitDelay()
    {
        yield return new WaitForSeconds(2f);
        storage.clear.SetActive(false);
        storage.panel.SetActive(false);
    }
}