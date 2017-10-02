using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAppear : MonoBehaviour
{
    public GameObject enemy;
    public float appearRate;
    private float nextAppear = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.time > nextAppear)
	    {
	        nextAppear = Time.time + appearRate;
	        Instantiate(enemy, transform.position, transform.rotation);
	    }
	}
}
