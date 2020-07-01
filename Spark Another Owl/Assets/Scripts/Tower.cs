using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] ParticleSystem shotFX;
    [SerializeField] float towerRange = 60f;

    // Update is called once per frame
    void Update()
    {
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
