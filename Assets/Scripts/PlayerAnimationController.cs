using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
	public enum AnimationMode
	{
		Flying,
		Spinning,
		PreShit,
        PostShit
	}

	[SerializeField]
	private GameObject wingLeft;

	[SerializeField]
	private GameObject wingRight;

	[SerializeField]
	private float flapSpeed;

	[SerializeField]
	private float flapMagnitude;

	[SerializeField]
	private float spinSpeed;

    [SerializeField] 
    private GameObject poop;

    [SerializeField]
    private GameObject body;

    private float rot;

	private AnimationMode mode;

	// Start is called before the first frame update
	void Start()
    {
		this.rot = 0f;
		this.mode = AnimationMode.Flying;
    }

    // Update is called once per frame
    void Update()
	{
		rot += Time.deltaTime;
		while (rot > 360f) rot -= 360f;

		switch (this.mode)
		{
			case AnimationMode.Flying:
				this.wingLeft.transform.localRotation = Quaternion.identity;
				this.wingRight.transform.localRotation = Quaternion.identity;
				this.wingLeft.transform.Rotate(Vector3.forward, Mathf.Sin(rot * flapSpeed) * flapMagnitude, Space.Self);
				this.wingRight.transform.Rotate(Vector3.forward, -Mathf.Sin(rot * flapSpeed) * flapMagnitude, Space.Self);
				break;
			case AnimationMode.Spinning:
				this.transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime, Space.Self);
				if (this.rot > 0.5f)
				{
					this.SetAnimationMode(AnimationMode.Flying);
					this.transform.localRotation = Quaternion.identity;
				}
				break;
			case AnimationMode.PreShit:

                if (this.rot < 1.0f)
				{
					this.transform.Rotate(Vector3.left, Time.deltaTime * 135f, Space.Self);
                }
                else
                {
                    GameObject f = GameObject.Instantiate(poop, body.transform.position, body.transform.rotation);
                    this.SetAnimationMode(AnimationMode.PostShit);
                }
                break;
            case AnimationMode.PostShit:
                
                if (this.rot < 1.0f)
                {
                    this.transform.Rotate(Vector3.right, Time.deltaTime * 135f, Space.Self);
                }
                else
                {
                    this.transform.localRotation = Quaternion.identity;
                    this.SetAnimationMode(AnimationMode.Flying);
                }
                break;
        }
	}

	public void SetAnimationMode(AnimationMode a)
	{
		this.mode = a;

		this.rot = 0f;
	}

	public AnimationMode GetAnimationMode()
	{
		return this.mode;
	}

	public void SetBankAmount(float bankAmount)
	{
		if (this.mode == AnimationMode.Flying)
		{
			this.transform.localRotation = Quaternion.identity;
			this.transform.Rotate(Vector3.forward, bankAmount, Space.Self);
		}
	}
}
