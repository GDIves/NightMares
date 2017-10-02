using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float hp;
    public AudioClip hurtAudio;
    private PlayerShoot playerShoot;
    private PlayerController playerController;
    private Animator anim;
    private Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public Image damageImage;
    public Slider healthSlider;
    public Animation gameOverAnimation;

    void Update()
    {
        damageImage.color = Color.Lerp(damageImage.color, Color.clear, 5*Time.deltaTime);
    }

    void Awake()
    {
        playerController = this.GetComponent<PlayerController>();
        playerShoot = this.GetComponentInChildren<PlayerShoot>();
        anim = this.GetComponent<Animator>();
    }
    public void TakeDamage(float attack)
    {
        if (hp <= 0) return;
        hp -= attack;
        AudioSource.PlayClipAtPoint(hurtAudio, Camera.main.transform.position, 1);
        damageImage.color = flashColor;
        healthSlider.value = hp;
        if (hp <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        GetComponent<AudioSource>().Play();
        anim.SetTrigger("Dead");
        gameOverAnimation.Play();
        playerController.enabled = false;
        playerShoot.enabled = false;
    }
}
