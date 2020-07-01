using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject dmgFX;
    [SerializeField] int hitPoints = 10;
    public bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider boxcollider = gameObject.AddComponent<BoxCollider>();
        boxcollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        isAlive = false;
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);        
        Destroy(gameObject);        
    }

    private void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        GameObject fx = Instantiate(dmgFX, transform.position, Quaternion.identity);        
    }


}
