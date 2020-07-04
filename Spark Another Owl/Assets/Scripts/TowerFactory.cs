using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int maxTowers = 6;

    int numTowers;
    public void AddTower(TowerBasement blockToBuildOn)
    {
        Tower[] towers = FindObjectsOfType<Tower>();
        numTowers = towers.Length;

        if(maxTowers > numTowers)
        {
            InstantiateNewTower(blockToBuildOn);
            
        }
        else
        {
            MoveExistingTower();
        }

    }

    private static void MoveExistingTower()
    {
        Debug.Log("maxTowers limit reached");
        // todo actually move!
    }

    private void InstantiateNewTower(TowerBasement blockToBuildOn)
    {
        Instantiate(towerPrefab, blockToBuildOn.transform.position, Quaternion.identity);
        blockToBuildOn.isPlaceble = false;
    }
}
