using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBuilder : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    public bool isPlaceble = true;
    

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            print(gameObject.name + " clicked");
            PlaceATower();
        }                           
    }

    private void PlaceATower()
    {
        if (isPlaceble)
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceble = false;
        }        
    }

    /* void OnMouseExit()
    {
        print("Mouse is no longer on " + gameObject.name);
    } */

}
