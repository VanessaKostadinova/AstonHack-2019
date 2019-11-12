using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOutScript : MonoBehaviour
{
	[SerializeField] private float ttl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		ttl -= Time.deltaTime;

		if (ttl < 0f)
		{
			Destroy(this.gameObject);
		}
    }
}
