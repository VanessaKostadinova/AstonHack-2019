using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneScript1 : MonoBehaviour
{
	[SerializeField] private AudioSource ac;
	[SerializeField] private AudioClip clip1;
	[SerializeField] private AudioClip clip2;
	[SerializeField] private AudioClip clip3;
	[SerializeField] private AudioClip clip4;
	[SerializeField] private AudioClip clip5;
	[SerializeField] private AudioClip clip6;
	[SerializeField] private AudioClip clip7;
	[SerializeField] private AudioClip clip8;
	[SerializeField] private AudioClip clip9;

	[SerializeField] private Light light;
	[SerializeField] private PresidentScript president;
	[SerializeField] private MeshRenderer button;
	[SerializeField] private MeshRenderer fist;
	[SerializeField] private Rigidbody alsoFist;

	[SerializeField] private Text text;

	private int progress;

    // Start is called before the first frame update
    void Start()
    {
		this.progress = 0;
		ac.clip = clip1;
		ac.Play();

		this.transform.position = new Vector3(0, 25f, 50f);
		this.transform.rotation = Quaternion.AngleAxis(180f, Vector3.up) * Quaternion.AngleAxis(60f, Vector3.right);
		text.text = "Mr. President, we face a Dire situation: The intergalactic conglomerate known as COmpany 2 is releasing unprecidented amounts of their propietary COmpany 2 gas into space.";
	}

    // Update is called once per frame
    void Update()
    {
		switch (this.progress)
		{
			case 0:
				this.transform.Translate(new Vector3(0f, 0f, -2f * Time.deltaTime), Space.World);
				if (!ac.isPlaying)
				{
					this.progress++;
					ac.clip = clip2;
					ac.Play();
					text.text = "At this moment, we can only assume that they intend to pollute the entire galaxy with deadly CO.2 gas. For the sake of all life in this galaxy, we must act now.";
				}
				break;
			case 1:
				this.transform.Translate(new Vector3(0f, 0f, -2f * Time.deltaTime), Space.World);
				if (!ac.isPlaying)
				{
					this.progress++;
					ac.clip = clip3;
					ac.Play();
					text.text = "At this very moment, Company 2 sits in orbit, releasing it's gas. Conventional weapons have proven useless against them and their vast array of satellite networks have thwarted any deployments of the space force.";
				}
				break;
			case 2:
				this.transform.Translate(new Vector3(0f, -1.5f * Time.deltaTime, -2f * Time.deltaTime), Space.World);
				this.transform.Rotate(Vector3.right, 5f * Time.deltaTime, Space.World);
				if (!ac.isPlaying)
				{
					this.progress++;
					ac.clip = clip4;
					ac.Play();
					light.enabled = true;
					president.StartFlap();
					text.text = "Release Admiral Goose.";
				}
				break;
			case 3:
				if (!ac.isPlaying)
				{
					this.progress++;
					ac.clip = clip5;
					ac.Play();
					this.transform.position = new Vector3(0f, 7.5f, -15f);
					this.transform.rotation = Quaternion.AngleAxis(300f, Vector3.up);
					text.text = "I beg your pardon, Sir?";
				}
				break;
			case 4:
				if (!ac.isPlaying)
				{
					this.progress++;
					ac.clip = clip6;
					ac.Play();
					this.transform.position = new Vector3(10f, 7.5f, -10f);
					this.transform.rotation = Quaternion.AngleAxis(210, Vector3.up);
					text.text = "Trust me on this, he's going to be the best, the greatest, I assure you.";
				}
				break;
			case 5:
				if (!ac.isPlaying)
				{
					this.progress++;
					ac.clip = clip7;
					ac.Play();
					this.transform.position = new Vector3(0f, 7.5f, -15f);
					this.transform.rotation = Quaternion.AngleAxis(300f, Vector3.up);
					text.text = "But sir, you can't be serious!";
				}
				break;
			case 6:
				if (!ac.isPlaying)
				{
					this.progress++;
					ac.clip = clip8;
					ac.Play();
					this.transform.position = new Vector3(10f, 7.5f, -10f);
					this.transform.rotation = Quaternion.AngleAxis(210, Vector3.up);
					button.enabled = true;
					text.text = "I am admiral!";
				}
				break;
			case 7:
				if (!ac.isPlaying)
				{
					this.progress++;
					ac.clip = clip9;
					ac.Play();
					this.transform.position = new Vector3(0f, 7.5f, -18f);
					this.transform.rotation = Quaternion.AngleAxis(260, Vector3.up) * Quaternion.AngleAxis(50, Vector3.right);
					fist.enabled = true;
					alsoFist.isKinematic = false;
					alsoFist.velocity = new Vector3(0f, -15f, 0f);
					text.text = "*Meaty Whack*";
				}
				break;
			case 8:
				if (!ac.isPlaying)
				{
					SceneManager.LoadScene("Liftoff");
				}
				break;
			default:
				break;
		}
    }
}
