using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissileTracker : MonoBehaviour
{
	public Transform target;
	[SerializeField] private Image img;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 diff = Camera.main.transform.position - target.position;
		img.color = new Color(1f, 1f, 1f, 1f / (diff.magnitude / 100f));
	}
}
