using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAppear : MonoBehaviour
{
    public GameObject enemy;
    public float appearTime;
    public Transform[] appearPoints;
    public PlayerHealthy playerHealthy;
    
    // Use this for initialization
	void Start () 
    {
        InvokeRepeating("Appear", appearTime, appearTime);
	}

    void Appear()
    {
        if (playerHealthy.hp <= 0)
        {
            return;
        }
        int appearPointsIndex = Random.Range(0, appearPoints.Length);
        GameObject.Instantiate(enemy, appearPoints[appearPointsIndex].position, appearPoints[appearPointsIndex].rotation);
    }
}
