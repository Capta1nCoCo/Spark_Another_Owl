using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] bool isRunning = true; // todo make private

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColourStartAndEnd();        
        Pathfind();
    }

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);

        while(queue.Count > 0 && isRunning)
        {
            var searchCenter = queue.Dequeue();            
            print("Searching from: " + searchCenter); // todo remove log
            HaltIfEndFound(searchCenter);
            ExploreNeighbours(searchCenter);
            searchCenter.isExplored = true;
        }
        // todo work-out path!
        print("Finished pathfinding?");
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("Searching from the end point. Algorithm stopped."); // todo remove log
            isRunning = false;
        }
    }

    private void ExploreNeighbours(Waypoint from)
    {
        if (!isRunning) { return; }
        
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = from.GetGridPos() + direction;
            try
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
            catch
            {
                // print("No block: " + neighbourCoordinates);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored)
        {
            // do nothing
        }
        else
        {
            neighbour.SetTopColour(Color.yellow);
            queue.Enqueue(neighbour);
            print("Queueing" + neighbour.name);
        }
        
    }

    private void ColourStartAndEnd()
    {
        startWaypoint.SetTopColour(Color.green);
        endWaypoint.SetTopColour(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping block " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
                
            }            
        }
    }
    
}
