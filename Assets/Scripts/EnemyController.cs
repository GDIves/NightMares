using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent enemyNav;
    private Animator enemyAnim;
    private GameObject player;
    public float distance;

    void Awake()
    {
        enemyNav = this.GetComponent<NavMeshAgent>();
        enemyAnim = this.GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () 
    {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	
	// Update is called once per frame
	void Update () 
    {
	    if (Vector3.Distance(transform.position, player.transform.position) < distance)
	    {
	        enemyNav.isStopped = true;
	        enemyAnim.SetBool("Move", false);
	    }
	    else
	    {
	        enemyNav.isStopped = false;
            enemyAnim.SetBool("Move", true);
	        enemyNav.SetDestination(player.transform.position);  
	    }
	}
}
