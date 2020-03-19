using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public enum directions {UL,UR,DL,DR};
    private bool myenable = false;
    public static bool token;
    Color oldcolor;
    Material mymaterial;

    protected bool Myenable {
        //get => myenable; 
        //set => myenable = value;
        get
        {
            return myenable;
        }
        set
        {
            myenable = value;
            if (myenable)
            {
                oldcolor = GetComponent<Renderer>().material.color;
                GetComponent<Renderer>().sharedMaterial.color = oldcolor+Color.white/2;
            }
            else
            {
                GetComponent<Renderer>().sharedMaterial.color = oldcolor;
            }
        }
    
    }

   protected void Selected()
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

        if (CheckBoard(newposition))
        {
            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, 2))
            {

                Object otherType = hit.collider.gameObject.GetComponent<Piece>();
                Object myType = GetComponent<Piece>();

                if (otherType.GetType() == myType.GetType())
                {
                    print("Amigo ");
                    return false;
                }
                else
                {
                    print("Quero te mata!");
                    newposition += direction;
                    if (CheckBoard(newposition))
                    {
                        Destroy(hit.collider.gameObject);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            transform.position = newposition;
            return true;
        }

        return false;

    }

    bool CheckBoard(Vector3 newpos)
    {
        if (newpos.x >= 0 && newpos.x <= 7 && newpos.z >= 0 && newpos.z <= 7)
        {
            return true;
        }
        return false;
    }
}
