using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    public float attack = 5;
    private float nextAttack;
    public float attackRate;
    private EnemyHealthy enemyHealthy;

    void Awake()
    {
        enemyHealthy = this.GetComponent<EnemyHealthy>();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            if (Time.time > nextAttack && enemyHealthy.hp > 0)
            {
                nextAttack = Time.time + attackRate;
                col.GetComponent<PlayerHealthy>().TakeDamage(attack);
            }
        }
    }
}
