using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthy : MonoBehaviour 
{
    public float hp = 100;
    public float smoothing;
    private Animator anim;
    private PlayerMove playerMove;
    private PlayerShoot playerShoot;
    private SkinnedMeshRenderer bodyRenderer;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public AudioClip playerDeath;
    private Transform mainCamera;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Awake()
    {
        this.anim = this.GetComponent<Animator>();
        this.playerMove = this.GetComponent<PlayerMove>();
        this.playerShoot = this.GetComponentInChildren<PlayerShoot>();
        this.bodyRenderer = transform.Find("Player").GetComponent<Renderer>() as SkinnedMeshRenderer;
    }

    void Update()
    {
        bodyRenderer.material.color = Color.Lerp(bodyRenderer.material.color, Color.white, smoothing * Time.deltaTime);
        damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed*Time.deltaTime);
    }
	
    public void TakeDamage(float damage)
    {
        if (hp <= 0) return;
        this.hp -= damage;
        this.GetComponent<AudioSource>().Play();
        healthSlider.value = this.hp;
        bodyRenderer.material.color = Color.red;
        damageImage.color = flashColor;
        if(this.hp <= 0)
        {
            anim.SetBool("Dead", true);
            AudioSource.PlayClipAtPoint(playerDeath,mainCamera.position,1.0f);
            this.playerMove.enabled = false;
            this.playerShoot.enabled = false;
        }
    }
}
