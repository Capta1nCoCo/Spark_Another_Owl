using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int baseHP = 10;
    [SerializeField] int dmgPoints = 1;
    [SerializeField] Text healthText;

    private void Start()
    {
        healthText.text = baseHP.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        baseHP -= dmgPoints;
        healthText.text = baseHP.ToString();
    }
}
