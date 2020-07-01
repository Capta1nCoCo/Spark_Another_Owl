using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisions : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject dmgFX;
    [SerializeField] int hits = 10;

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

        if (hits <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);        
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        hits = hits - 1;
        GameObject fx = Instantiate(dmgFX, transform.position, Quaternion.identity);        
    }


}
