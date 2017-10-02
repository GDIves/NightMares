using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour 
{
    private NavMeshAgent enemyAgent;
    private GameObject player;
    private Animator enemyAnim;
    public float distance;
    
    void Awake()
    {
        enemyAgent = this.GetComponent<NavMeshAgent>();
        enemyAnim = this.GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if(Vector3.Distance(transform.position,player.transform.position) < distance)
        {
            enemyAgent.isStopped = true;
            enemyAnim.SetBool("Move", false);
        }
        else
        {          
            enemyAgent.isStopped = false;
            enemyAnim.SetBool("Move", true);
            enemyAgent.SetDestination(player.transform.position);
        }      
	}
}
