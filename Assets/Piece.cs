using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public enum directions {UL,UR,DL,DR};
    protected bool myenable = false;
    public static bool token;
    void Start()
    {
        
    }

    public bool MovePart(directions d)
    {


            Vector3 newposition=Vector3.zero;
            Vector3 direction = Vector3.zero;
        switch (d)
        {
            case (directions.UL):
                direction= new Vector3(-1, 0, 1);
                break;
            case (directions.UR):
                direction = new Vector3(1, 0, 1);
                break;
            case (directions.DL):
                direction = new Vector3(-1, 0, -1);
                break;
            case (directions.DR):
                direction = new Vector3(1, 0, -1);
                break;
            default:
                break;
        }
        newposition = transform.position + direction;

        if (Physics.Raycast(transform.position,direction, out RaycastHit hit, 2))
        {
            return false;
           
        }


        if (newposition.x>=0&& newposition.x<=7&& newposition.z>=0&& newposition.z<= 7)
        {
            transform.position = newposition;
            return true;
        }
        return false;

    }
}
