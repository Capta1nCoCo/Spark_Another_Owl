using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    

    TextMesh textMesh;
    Vector3 gridPos;
    Waypoint waypoint;
    
    //int gridSize;


    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
        
    }

    void Update()
    {
        SnapToGrid();
        UpdatLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        gridPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        gridPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(gridPos.x, 0f, gridPos.z);
    }

    private void UpdatLabel()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        int gridSize = waypoint.GetGridSize();
        string labelText = gridPos.x / gridSize + "," + gridPos.z / gridSize;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
