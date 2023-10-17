using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] int startMoney = 300;
    [SerializeField] int killEnemyIncreaseMoney = 50;
    [SerializeField] int costOfTower = 100;
    [SerializeField] int costOfEnemyPassed = 40;

    public int currentMoney = 0;

    void Start() 
    {
        currentMoney = startMoney;        
    }

    void Update()
    {
        goldText.text = ("Gold: " + currentMoney.ToString());
    }

    public void IncreaseOurMoney()
    {
        currentMoney += killEnemyIncreaseMoney;
    }

    public void ReduceOurMoneyForTower()
    {
        currentMoney -= costOfTower;
        Debug.Log(currentMoney);
    }

    public void ReduceOurMoneyForEnemy()
    {
        currentMoney -= costOfEnemyPassed;
        Debug.Log(currentMoney);
    }
}
