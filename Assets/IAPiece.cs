using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPiece : Piece
{
    void Start()
    {
        
    }
    void Update()
    {

        if (myenable&&!token)
        {
            StartCoroutine("MoveIA");
            myenable = false;
        }
        
    }
    IEnumerator MoveIA()
    {
        yield return new WaitForSeconds(1);
        while(!MovePart((directions)Random.Range(0, 4)))
        {
            
        }
        myenable = true;
        token = true;
    }
}

