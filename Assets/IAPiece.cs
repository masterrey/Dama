using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPiece : Piece
{
    IAControl.IaCallBack iaCallBack;
    void Start()
    {
        InvokeRepeating("TryIA", 0, 1);
    }

    void TryIA()
    {
        if (Myenable && !token)
        {
            StartCoroutine("MoveIA");
            Myenable = false;
        }
    }

    public void EnableIA(IAControl.IaCallBack iaCall)
    {
        iaCallBack = iaCall;
        Myenable = true;
    }
    void Update()
    {
       
       
        
    }
    IEnumerator MoveIA()
    {
        yield return new WaitForSeconds(1);
        int counter = 10;
        while(!MovePart((directions)Random.Range(0, 4))&&counter>0)
        {
            counter--;  
        }
        if (counter <= 0)
        {
            Myenable = false;
            iaCallBack(false);
        }
        else
        {
            token = true;
        }
    }
}

