using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAControl : MonoBehaviour
{
    public IAPiece[] iAPieces;
    bool wait;
    public delegate void IaCallBack(bool validmove);
    public IaCallBack iaCall;

    // Start is called before the first frame update
    void Start()
    {
        iAPieces = GameObject.FindObjectsOfType<IAPiece>();
        iaCall = myCallBack;
    }

    void myCallBack(bool validmove)
    {
        if (!validmove) {
            wait = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!wait&&!Piece.token)
        {
            wait = true;
            iAPieces[Random.Range(0, iAPieces.Length)].EnableIA(iaCall);
        }

        if (Piece.token)
        {
            wait = false;
        }
    }
}
