using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyHealth enemyHealth;
    public float attack;
    private float nextAttack;
    public float attackRate;

    void Start()
    {
        enemyHealth = this.GetComponent<EnemyHealth>();
    }

    void OnTriggerStay(Collider c)
    {
        if (c.tag == "Player")
        {
            if (Time.time > nextAttack && enemyHealth.hp >= 0)
            {
                nextAttack = Time.time + attackRate;
                c.GetComponent<PlayerHealth>().TakeDamage(attack);
            }          
        }     
    }
}
