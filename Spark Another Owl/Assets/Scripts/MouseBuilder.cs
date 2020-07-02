using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBuilder : MonoBehaviour
{
    void OnMouseOver()
    {
        // detect mouse click
            // if clicked
                print(gameObject.name + " clicked");
    }

    void OnMouseExit()
    {
        print("Mouse is no longer on " + gameObject.name);
    }

}
