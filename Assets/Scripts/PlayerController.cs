using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private Animator anim;
    private int groundIndex;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
    }

    void Start()
    {
        groundIndex = LayerMask.GetMask("Ground");  
    }
	
	// Update is called once per frame
	void FixedUpdate ()
	{
        float moveHorizontal = Input.GetAxis("Horizontal");
	    float moveVertical = Input.GetAxis("Vertical");
	    Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.MovePosition(transform.position + movement * speed * Time.deltaTime);

	    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	    RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 200, groundIndex))
        {
            Vector3 target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
	      
        if (moveHorizontal != 0 || moveVertical != 0)
	    {
	        anim.SetBool("Move", true);
	    }
	    else
	    {
	        anim.SetBool("Move", false);
	    }
	}
}
