using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
	[SerializeField] AudioSource ac;
	[SerializeField] PresidentScript pr;

    // Start is called before the first frame update
    void Start()
    {
		ac.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (ac.isPlaying)
		{
			pr.StartFlap();
		}
		else
		{
			pr.StopFlap();
		}

		if (Input.GetKey(KeyCode.R))
		{
			SceneManager.LoadScene("SampleScene");
		}
    }
}
