using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TouchToWin : MonoBehaviour
{
 
 
 
private RaycastHit hit;  //variable
 
void Start ()
    {
   
    }
   
    // Update is called once per frame
    void Update ()
    {
   
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition) ;
         
            if(Input.GetMouseButtonDown(0))
            {
 
            if(Physics.Raycast(ray, out hit, 1000))
            {
            if(hit.collider.CompareTag("Cube"))
            {
 
                    ProcessWin(hit.transform.gameObject);
            }
           
       
               
           
            }
       
        }
 
    }
       
        public void ProcessWin(GameObject go)
        {
 
         Application.LoadLevel("TtileScreen");
        }
       
   
   
   
 
 
 
 
 
}
   
 


               