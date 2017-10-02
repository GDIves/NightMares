using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public PlayerHealthy playerHealthy;
    private Animator anim;
    private GameObject enemy;

	// Use this for initialization
	void Awake()
	{
	    anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update() 
    {
	    if (playerHealthy.hp <= 0)
	    {
	        anim.SetTrigger("GameOver");
            InvokeRepeating("DestroyEnemy", 3, 3);
	        if (Input.GetKeyDown(KeyCode.R))
	        {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	        }
	    }
	}

    void DestroyEnemy()
    {
        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
    }
}
