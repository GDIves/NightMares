using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public ParticleSystem gunParticle;
    public Light shotLight;
    public float shotRate;
    private float nextShot;
    private LineRenderer gunLine;
    public float shotDamege = 30;

	// Use this for initialization
	void Start ()
	{
	    gunLine = GetComponent<Renderer>() as LineRenderer;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButton("Fire1") && Time.time > nextShot)
	    {
	        nextShot = Time.time + shotRate;
	        Shoot();
	    }
	}

    void Shoot()
    {
        gunParticle.Play();
        shotLight.enabled = true;
        GetComponent<AudioSource>().Play();
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);
        Ray ray = new Ray(transform.position,transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
           gunLine.SetPosition(1,hitInfo.point);
            if (hitInfo.collider.tag == "Enemy")
            {
                hitInfo.collider.GetComponent<EnemyHealth>().TakeDamege(shotDamege, hitInfo.point);
            }
        }
        else
        {
            gunLine.SetPosition(1, transform.position + transform.forward * 100);
        }
        Invoke("ClearEffect", 0.05f);
    }

    void ClearEffect()
    {
        shotLight.enabled = false;
        gunLine.enabled = false;
    }
}
