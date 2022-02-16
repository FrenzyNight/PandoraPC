using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ElecButton : MonoBehaviour
{
    private ElecManager elecManager;

    public Image image;
    public Sprite up;
    public Sprite down;

    public bool isDown;

    public void DOWN() //������° ���ܱⰡ ������ �ִ� ����
    {
        isDown = true;
        image.sprite = down;
    }

    public void UP()
    {
        isDown = false;
        image.sprite = up;
    }

    public void OnClick()
    {

        if (isDown)
        {
            Debug.Log("���ܱ� �ø���");
            image.sprite = up;
            isDown = false;
        }
        else
        {
            Debug.Log("���ܱ� ������");
            image.sprite = down;
            isDown = true;
        }
    }

}
