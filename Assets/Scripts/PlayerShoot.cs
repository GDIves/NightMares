using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public Light gunLight;
    private ParticleSystem gunParticleSystem;
    private LineRenderer lineRenderer;
    private float nextShoot;
    public float shootRate;
    public float attack = 30; 

	void Start () 
    {
        gunParticleSystem = this.GetComponentInChildren<ParticleSystem>();
        lineRenderer = this.GetComponent<Renderer>() as LineRenderer;
	}
	

    void Shoot()
    {
        if (Time.time > nextShoot)
        {
            nextShoot = Time.time + shootRate;
            gunLight.enabled = true;
            gunParticleSystem.Play();
            lineRenderer.enabled = true;
            //标记射线初始点
            lineRenderer.SetPosition(0, transform.position);
            //定义一条从枪口射出的射线
            Ray ray = new Ray(transform.position, transform.forward);
            //射线碰撞信息
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))//如果射线碰撞到物体
            {
                //标记射线碰撞点为结束点，两点间绘制一条LineRenderer射线
                lineRenderer.SetPosition(1, hitInfo.point);
                if (hitInfo.collider.tag == "Enemy")//碰撞到的Collider为Enemy
                {
                    hitInfo.collider.GetComponent<EnemyHealthy>().TakeDamage(attack, hitInfo.point);
                }
            }
            else
            {
                //如果射线没有碰撞到物体，则绘制一条向前延伸100单位的射线
                lineRenderer.SetPosition(1, transform.position + transform.forward * 100);
            }
            GetComponent<AudioSource>().Play();
            Invoke("ClearEffect", 0.05f);
        } 
    }

    void ClearEffect()
    {
        gunLight.enabled = false;
        lineRenderer.enabled = false;
    }
}
