using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SateliteTracker : MonoBehaviour
{
	public Transform target;
	[SerializeField] private RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {

    }

	// Update is called once per frame
	void Update()
	{
		Vector3 newPos = target.transform.position;
		newPos = Camera.main.WorldToViewportPoint(newPos);
		if (newPos.z < 0)
		{
			newPos.x = 1f - newPos.x;
			newPos.y = 1f - newPos.y;
			newPos.z = 0; 

			float max = 0;
			max = newPos.x > max ? newPos.x : max;
			max = newPos.y > max ? newPos.y : max;
			max = newPos.z > max ? newPos.z : max;
			newPos /= max;
		}
		newPos = Camera.main.ViewportToScreenPoint(newPos);
		newPos.z = 0f;
		newPos.x = Mathf.Clamp(newPos.x, 50f, Screen.width - 50f);
		newPos.y = Mathf.Clamp(newPos.y, 50f, Screen.height - 50f);
		rect.transform.position = newPos;
	}
}
