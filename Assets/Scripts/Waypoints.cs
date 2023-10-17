using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isPlaceable;

    Bank bank;

    public bool IsPlaceable { get {return isPlaceable; } }

    void Start() 
    {
        bank = FindObjectOfType<Bank>();
    }

    private void OnMouseDown() 
    {
        if(isPlaceable)
        {
            if(bank.currentMoney > 1)
            {
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
                isPlaceable = false;
                bank.ReduceOurMoneyForTower();
            }
        }
    }
}
