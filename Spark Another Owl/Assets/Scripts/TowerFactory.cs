using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int maxTowers = 6;

    Queue<Tower> towerQueue = new Queue<Tower>();
    Queue<TowerBasement> blockQueue = new Queue<TowerBasement>();
    public void AddTower(TowerBasement blockToBuildOn)
    {        
        int numTowers = towerQueue.Count;

        if(maxTowers > numTowers)
        {
            InstantiateNewTower(blockToBuildOn);
            
        }
        else
        {
            MoveExistingTower(blockToBuildOn);
        }

        Debug.Log("towerQueue.Count = " + towerQueue.Count);
    }

    private void InstantiateNewTower(TowerBasement blockToBuildOn)
    {
        Instantiate(towerPrefab, blockToBuildOn.transform.position, Quaternion.identity);
        blockToBuildOn.isPlaceble = false;

        Tower tower = FindObjectOfType<Tower>();
        towerQueue.Enqueue(tower);
        blockQueue.Enqueue(blockToBuildOn);
    }

    private void MoveExistingTower(TowerBasement blockToBuildOn)
    {
        Tower towerToMove = towerQueue.Dequeue();
        TowerBasement blockToEnable = blockQueue.Dequeue();

        Destroy(towerToMove.gameObject);
        blockToEnable.isPlaceble = true;
        
        InstantiateNewTower(blockToBuildOn);

        Debug.Log(towerToMove.gameObject.name + "is moved to " + blockToBuildOn.gameObject.name );                
        
    }

    
}
