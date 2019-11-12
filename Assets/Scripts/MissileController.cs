using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
	[SerializeField]
    private float speed = 10f;

	[SerializeField]
    private GameObject tracker;

    [SerializeField]
    private float rotationSpeed = 5000f;

    private float targetDistance = 20f;

    public Transform target;

	public GameObject g;

    private bool isLookingAt = true;

    private void OnEnable()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
		this.g = Instantiate(tracker, GameObject.FindGameObjectWithTag("UI").transform);
		g.GetComponent<MissileTracker>().target = this.transform;
		g.GetComponent<SateliteTracker>().target = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDirection = target.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0f);
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);

        if (Vector3.Distance(transform.position, target.position) < targetDistance)
        {
            isLookingAt = false;
        }

        if (isLookingAt)
        {
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

	void OnDestroy()
	{
		Destroy(g);
	}
}
