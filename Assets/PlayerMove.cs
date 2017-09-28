using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private Animator moveAnim;
    private int groundLayerIndex;
    public Rigidbody rb;

	// Use this for initialization
	void Start () {
        moveAnim = this.GetComponent<Animator>();
        groundLayerIndex = LayerMask.GetMask("Ground");
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    float Horizontal = Input.GetAxis("Horizontal");
	    float Vertical = Input.GetAxis("Vertical");
        rb.MovePosition(transform.position + new Vector3(Horizontal, 0, Vertical) * speed * Time.deltaTime);

        //返回一条从摄像机通过一个鼠标所在点的射线
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //获得射线与碰撞器的碰触信息
        RaycastHit hitInfo;
        //检测到射线与groundLayerIndex碰撞
        if(Physics.Raycast(ray,out hitInfo,200,groundLayerIndex))
        {
            Vector3 target = hitInfo.point;//碰撞点
            target.y = transform.position.y;//固定Player的y轴位置
            transform.LookAt(target);//将Player面向碰撞点
        }


        if(Horizontal!=0||Vertical!=0){
            moveAnim.SetBool("Move", true); 
        } 
        else
        {
            moveAnim.SetBool("Move", false);
        }
	}
}
