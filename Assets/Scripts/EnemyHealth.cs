using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    [Tooltip("adds amount to maxHealth when enemy dies.")] 
    [SerializeField] int difficultRamp = 1;


    Bank bank;

    int currentHealth = 0;

    void OnEnable() 
    {
        currentHealth = maxHealth;
    }

    void Start() 
    {
        bank = FindObjectOfType<Bank>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            bank.IncreaseOurMoney();
            maxHealth += difficultRamp;
        }
    }
}
