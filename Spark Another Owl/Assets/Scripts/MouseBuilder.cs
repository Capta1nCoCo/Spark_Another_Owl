using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBuilder : MonoBehaviour
{
    public bool isPlaceble = true;
    
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            print(gameObject.name + " clicked");
        }                           
    }

    /* void OnMouseExit()
    {
        print("Mouse is no longer on " + gameObject.name);
    } */

}
