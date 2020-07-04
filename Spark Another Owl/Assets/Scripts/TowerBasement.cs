using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBasement : MonoBehaviour
{
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
            FindObjectOfType<TowerFactory>().AddTower(this);
        }        
    }

}
