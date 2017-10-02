using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    public float smooth;
	// Use this for initialization
	void Start ()
	{
	    player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    Vector3 target = player.position + new Vector3(0.6f, 2.5f, -3.5f);
        transform.position = Vector3.Lerp(transform.position, target, smooth * Time.deltaTime);
	}
}
