using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int maxTowers = 6;
    

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(TowerBlock blockToBuildOn)
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

    private void InstantiateNewTower(TowerBlock blockToBuildOn)
    {
        var newTower = Instantiate(towerPrefab, blockToBuildOn.transform.position, Quaternion.identity);
        blockToBuildOn.isPlaceble = false;

        newTower.baseTowerBlock = blockToBuildOn;
        
        towerQueue.Enqueue(newTower);        
    }

    private void MoveExistingTower(TowerBlock newBaseTowerBlock)
    {
        Tower oldTower = towerQueue.Dequeue();        

        oldTower.baseTowerBlock.isPlaceble = true;
        newBaseTowerBlock.isPlaceble = false;

        oldTower.transform.position = newBaseTowerBlock.transform.position;

        towerQueue.Enqueue(oldTower);                
        
    }

    
}
