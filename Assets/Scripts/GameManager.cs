using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] int maxHealth = 100;
    [SerializeField] int enemyPassedReduceHealthAmount = 1;
    int currentHealth = 0;
    
    void Awake() 
    {
        currentHealth = maxHealth;    
    }

    void Update() 
    {
        if(currentHealth < 1)
        {
            //You Losted Game Screen
            Application.Quit();
        }
        healthText.text = ("Health: " + currentHealth);
    }

    public void reduceOurHealth()
    {
        currentHealth -= enemyPassedReduceHealthAmount;
    }

}
