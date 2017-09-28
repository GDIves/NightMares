using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealthy : MonoBehaviour {

    public float hp = 100;
    private Animator enemyAnim;
    private EnemyMove enemyMove;
    private NavMeshAgent enemyAgent;
    private CapsuleCollider enemyCollider;
    private Transform mainCamera;
    private ParticleSystem hitParticle;
    public AudioClip deathClip;
    public int enemyScore;

    void Update()
    {
        if(this.hp <= 0)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 0.5f);
            if(transform.position.y <= -1)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void Awake()
    {
        enemyAnim = this.GetComponent<Animator>();
        enemyMove = this.GetComponent<EnemyMove>();
        enemyAgent = this.GetComponent<NavMeshAgent>();
        enemyCollider = this.GetComponent<CapsuleCollider>();
        hitParticle = this.GetComponentInChildren<ParticleSystem>();
    }

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }



    public void TakeDamage(float damage, Vector3 hitPoint)
    {
        if (this.hp <= 0) return;
        this.GetComponent<AudioSource>().Play();
        hitParticle.transform.position = hitPoint;
        hitParticle.Play();
        this.hp -= damage;
        if(this.hp <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        ScoreText.scores += enemyScore;
        enemyAnim.SetBool("Dead", true);
        enemyMove.enabled = false;
        enemyAgent.enabled = false;
        enemyCollider.enabled = false;
        AudioSource.PlayClipAtPoint(deathClip, mainCamera.position, 1.0f);
    }
}
