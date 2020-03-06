﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPiece : Piece
{
   
    void Start()
    {
        
    }
 
    void Update()
    {
        if (myenable)
        {
            if (Input.GetMouseButtonDown(0))
            {
                bool validmove = false;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray,out RaycastHit hit, 100))
                {
                    if (hit.point.x - transform.position.x > 0)
                    {
                        if (hit.point.z - transform.position.z > 0)
                        {
                            validmove= MovePart(directions.UR);
                        }
                        else
                        {
                            validmove= MovePart(directions.DR);
                        }
                        
                    }
                    else
                    {
                        if (hit.point.z - transform.position.z > 0)
                        {
                            validmove= MovePart(directions.UL);
                        }
                        else
                        {
                            validmove= MovePart(directions.DL);
                        }

                    }
                    if (validmove)
                    {
                        myenable = false;
                        token = false;
                    }
                }
            }
        }
    }
    void OnMouseUp()
    {
        if(token)
        myenable = true;
    }
}