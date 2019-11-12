using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
	[SerializeField] private float speed;
	public float speedMultiplier;

	//[SerializeField] private float bankCap;
	//[SerializeField] private float bankSpeedX;
	//[SerializeField] private float bankSpeedY;
	//[SerializeField] private PlayerAnimationController animator;

	//private float bankAmountX;
	//private float bankAmountY;
	//private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
		//this.bankAmountX = 0f;
		//this.isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
        Move();
    }

    private void Turn()
    {
        /*
		int bankDelta = 0;

		if (!isPaused)
		{
			if (Input.GetKey(KeyCode.A)) bankDelta--;
			if (Input.GetKey(KeyCode.D)) bankDelta++;
		}

		float amountToBank = this.bankSpeedX * Time.deltaTime;

		if (bankDelta != 0)
		{
			this.bankAmountX += amountToBank * bankDelta;

			this.bankAmountX = Mathf.Clamp(bankAmountX, -this.bankCap, this.bankCap);
		}
		
        
        else
		{
			if (Mathf.Abs(this.bankAmountX) < amountToBank)
			{
				this.bankAmountX = 0f;
			}
			else if (this.bankAmountX > 0)
			{
				this.bankAmountX -= amountToBank;
			}
			else
			{
				this.bankAmountX += amountToBank;
			}
		}

		bankDelta = 0;
		amountToBank = this.bankSpeedY * Time.deltaTime;

		if (!isPaused)
		{
			if (Input.GetKey(KeyCode.W)) bankDelta++;
			if (Input.GetKey(KeyCode.S)) bankDelta--;
		}

		if (bankDelta != 0)
		{
			this.bankAmountY += amountToBank * bankDelta;

			this.bankAmountY = Mathf.Clamp(bankAmountY, -this.bankCap, this.bankCap);
		}
		
        
        else
		{
			if (Mathf.Abs(this.bankAmountY) < amountToBank)
			{
				this.bankAmountY = 0f;
			}
			else if (this.bankAmountY > 0)
			{
				this.bankAmountY -= amountToBank;
			}
			else
			{
				this.bankAmountY += amountToBank;
			}
		}
        
		this.animator.SetBankAmount(-bankAmountX);
		this.transform.Rotate(Vector3.right, bankAmountY * Time.deltaTime, Space.Self);
		this.transform.Rotate(Vector3.up, bankAmountX * Time.deltaTime, Space.World);
        */

        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(90f * Time.deltaTime, 0f, 0f);
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.Rotate(-90f * Time.deltaTime, 0f, 0f);
		}
		if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, 120f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -120f * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Boss" | collision.gameObject.tag == "Asteroid" | collision.gameObject.tag == "Enemy")
        {
            this.GetComponent<HealthCounter>().DecrementHealth(1);
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
    }

 //   private void Pause()
 //   {
	//	isPaused = false;
 //   }

	//private void Unpause()
 //   {
	//	isPaused = true;
 //   }
}
