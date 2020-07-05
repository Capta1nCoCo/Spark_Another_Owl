using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] ParticleSystem dmgParticle;
    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] int hitPoints = 10;
    [SerializeField] AudioClip dmgSFX;
    [SerializeField] AudioClip deathSFX;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
        Destroy(gameObject);
        
    }

    private void ProcessHit()
    {
        audioSource.PlayOneShot(dmgSFX);
        hitPoints = hitPoints - 1;        
        dmgParticle.Play();        
    }


}
