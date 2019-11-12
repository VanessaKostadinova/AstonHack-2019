using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresidentScript : MonoBehaviour
{
	[SerializeField] private Transform mouth;

	private bool isFlapping;
	private float theta;

    // Start is called before the first frame update
    void Start()
    {
		this.isFlapping = false;
		this.theta = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlapping)
		{
			this.theta += Time.deltaTime;
			mouth.transform.localPosition = new Vector3(0f, Mathf.Sin(theta * 32f) * 0.1f - 0.1f, 0f);

			while (this.theta > 360f) this.theta -= 360f;
		}
    }

	public void StartFlap()
	{
		this.isFlapping = true;
	}
	public void StopFlap()
	{
		this.isFlapping = false;
	}
}
