using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthCounter : MonoBehaviour
{
	[SerializeField]
    private AudioSource ac;

    [SerializeField]
    int health = 5;

    public bool invincible = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecrementHealth(int ammount)
    {
        if (!invincible)
        {
            health -= ammount;
			ac.Play();
        }

        if(health <= 0)
        {
            if(gameObject.tag == "Player")
            {
                SceneManager.LoadScene("GameOver");
            }
            if(gameObject.tag == "Boss")
            {
                SceneManager.LoadScene("GameWin");
            }

            Destroy(gameObject);
        }
    }

    public void IncreaseHealth(int ammount)
    {
        health += ammount;
    }

    public int getHealth()
    {
        return health;
    }
}