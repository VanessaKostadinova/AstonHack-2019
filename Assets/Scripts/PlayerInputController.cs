using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
	[SerializeField] private PlayerAnimationController animator;
	[SerializeField] private GameObject bullet;


	private float inputCooldown;
    private bool dashed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		this.inputCooldown -= Time.deltaTime;

		if (inputCooldown < 0f)
		{
            if (this.dashed)
            {
                this.GetComponent<HealthCounter>().invincible = false;
                Debug.Log("not invincible");
                dashed = false;
            }
            if (Input.GetKeyDown(KeyCode.Space)) Shoot();

			if (Input.GetKeyDown(KeyCode.LeftShift)) Dash();

			if (Input.GetKeyDown(KeyCode.LeftAlt)) Shit();
		}

        if (this.dashed)
        {
        }
    }

	private void Shoot()
	{
		GameObject f = GameObject.Instantiate(bullet, this.transform.position, this.transform.rotation);
        f.GetComponent<damageController>().target = "Enemy";
		this.inputCooldown = 0.1f;
	}

	private void Dash()
	{
		animator.SetAnimationMode(PlayerAnimationController.AnimationMode.Spinning);
        this.GetComponent<HealthCounter>().invincible = true;
        Debug.Log("invincible");
        dashed = true;
        this.inputCooldown = 1f;
	}

	private void Shit()
	{
		animator.SetAnimationMode(PlayerAnimationController.AnimationMode.PreShit);
        this.inputCooldown = 2f;
	}
}
