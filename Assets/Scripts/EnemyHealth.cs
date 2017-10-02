using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour 
{
    public ParticleSystem hitParticle;
    public AudioClip hurtAudio;
    public AudioClip deathAudio;
    private Animator enemyAnim;
    private NavMeshAgent enemyNav;
    private EnemyController enemyMove;
    public float hp;
    public int enemyScore;

    void Update()
    {
        if (hp <= 0)
        {
            transform.Translate(Vector3.down * Time.deltaTime);
            if (transform.position.y <= -2)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void Awake()
    {
        enemyAnim = this.GetComponent<Animator>();
        enemyNav = this.GetComponent<NavMeshAgent>();
        enemyMove = this.GetComponent<EnemyController>();
    }

    public void TakeDamege(float damage, Vector3 hitPoint)
    {
        if (this.hp <= 0) return;
        hitParticle.transform.position = hitPoint;
        hitParticle.Play();
        AudioSource.PlayClipAtPoint(hurtAudio, Camera.main.transform.position, 1);
        this.hp -= damage;
        if (this.hp <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        ScoreController.scores += enemyScore;   
        AudioSource.PlayClipAtPoint(deathAudio, Camera.main.transform.position, 1);
        enemyAnim.SetTrigger("Dead");
        enemyMove.enabled = false;
        enemyNav.enabled = false;
    }
}
