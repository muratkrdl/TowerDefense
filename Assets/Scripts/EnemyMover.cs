using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoints> path = new List<Waypoints>();
    [SerializeField] float enemyMoveSpeed = 1f;


    GameManager gameManager;
    Bank bank;

    private void OnEnable() 
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(WriteTheConsole());
    }

    void Awake() 
    {
        bank = FindObjectOfType<Bank>();
        gameManager = FindObjectOfType<GameManager>();    
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in parent.transform)
        {
            Waypoints waypoints = child.GetComponent<Waypoints>();

            if(waypoints != null)
            {
                path.Add(waypoints);
            }
        }
    }

    IEnumerator WriteTheConsole()
    {
        foreach(var waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float lerpPercent = 0f;

            transform.LookAt(endPosition);
            
            while(lerpPercent < 1)
            {
                lerpPercent += Time.deltaTime * enemyMoveSpeed;
                transform.position = Vector3.Lerp(startPosition, endPosition, lerpPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }

    void FinishPath()
    {
        gameObject.SetActive(false);
        bank.ReduceOurMoneyForEnemy();
        gameManager.reduceOurHealth();
    }

}
