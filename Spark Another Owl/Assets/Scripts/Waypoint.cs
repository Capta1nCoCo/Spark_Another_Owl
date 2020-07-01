using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor;
    // public is ok here as is a data class
    public bool isExplored = false;
    public Waypoint exploredFrom;

    public bool isStart = false;
    public bool isEnd = false;

    Vector2Int gridPos;
   
    const int gridSize = 10;

    void Update()
    {
        if (isExplored && !isStart && !isEnd)
        {
            SetTopColour(exploredColor);
        }
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    public void SetTopColour(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }

    // My solution:
    public void MySetTopColour(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        if (gameObject.tag == "start")
        {
            topMeshRenderer.material.color = Color.red;
        }
        else if (gameObject.tag == "end")
        {
            topMeshRenderer.material.color = Color.green;
        }
        else
        {
            topMeshRenderer.material.color = color;
        }
        
    }
    

}   
