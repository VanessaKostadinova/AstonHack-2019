using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LiftoffController : MonoBehaviour
{
	[SerializeField] private AudioSource duckAudio;
	[SerializeField] private Transform duck;

	// Start is called before the first frame update
	void Start()
	{
		duckAudio.volume = 0f;
		duckAudio.pitch = 0f;
	}

    // Update is called once per frame
    void Update()
    {
		duckAudio.volume += 0.05f * Time.deltaTime;
		duckAudio.pitch += 0.05f * Time.deltaTime;

		duckAudio.volume = Mathf.Clamp01(duckAudio.volume);

		duck.Translate(new Vector3(0.0f, 5.0f * Time.deltaTime, 0.0f), Space.World);

		if (duck.position.y > 100f)
		{
			SceneManager.LoadScene("SampleScene");
		}
    }
}
