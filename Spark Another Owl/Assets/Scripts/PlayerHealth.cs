using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int baseHitPoints = 10;
    [SerializeField] int dmgPoints = 1;

    private void OnTriggerEnter(Collider other)
    {
        baseHitPoints = baseHitPoints - dmgPoints;
    }
}
