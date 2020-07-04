using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] Transform objectToPan;    
    [SerializeField] ParticleSystem shotFX;
    [SerializeField] float towerRange = 30f;

    public TowerBlock baseTowerBlock;

    // State
    Transform targetEnemy;
    
    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            LookAtEnemy();
            ShootAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>(); // Get the collection of things
        if (sceneEnemies.Length == 0)
        {
            return;
        }
        Transform closestEnemy = sceneEnemies[0].transform; // Assume the first is the "winner"

        foreach (EnemyDamage sceneEnemy in sceneEnemies) // For each item in collection
        {
            closestEnemy = GetClosest(closestEnemy, sceneEnemy.transform); // Update winner
        }
        targetEnemy = closestEnemy; // return the winner

    }

    private Transform GetClosest(Transform closestEnemy, Transform nextEnemy)
    {
        float distanceToCurrentTarget = Vector3.Distance(closestEnemy.position, transform.position);
        float distanceToNextTarget = Vector3.Distance(nextEnemy.position, transform.position);
        if (distanceToNextTarget < distanceToCurrentTarget)
        {
            return nextEnemy;
        }
        return closestEnemy;
    }

    private void ShootAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= towerRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = shotFX.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = isActive;
    }

    private void LookAtEnemy()
    {
        objectToPan.LookAt(targetEnemy);        
    }
}
