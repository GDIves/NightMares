using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour 
{
    public float smoothing;
    public Transform player;
	// Use this for initialization

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetPos = player.position + new Vector3(1, 5, -5);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);
	} 
}
