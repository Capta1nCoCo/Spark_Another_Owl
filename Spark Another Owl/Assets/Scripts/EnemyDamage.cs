using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] ParticleSystem dmgParticle;
    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] int hitPoints = 10;

    // Start is called before the first frame update
    void Start()
    {
        // AddNonTriggerBoxCollider(); // not needed with new Enemy prefab, but may be needed in the future
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
        ParticleSystem fx = Instantiate(deathParticle, transform.position, Quaternion.identity);
        fx.Play();
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        hitPoints = hitPoints - 1;        
        dmgParticle.Play();
    }


}
