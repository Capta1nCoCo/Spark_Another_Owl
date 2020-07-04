using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBlock : MonoBehaviour
{
    public bool isPlaceble = true;
     
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
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
