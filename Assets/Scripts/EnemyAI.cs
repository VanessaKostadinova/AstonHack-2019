using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] 
    private GameObject bullet;

	[SerializeField] 
    private float speed;

    [SerializeField] 
    private int maxBullets;

    [SerializeField]
    private float timer = 0.0f;

    private int bulletsShot;
	public GameObject tracker;

	private Vector3 direction;

    // Start is called before the first frame update
    void Start()
	{
		this.direction = Random.onUnitSphere;
	}

    // Update is called once per frame
    void Update()
    {
		Vector3 axis = Random.onUnitSphere;

		this.direction = Quaternion.AngleAxis(Time.deltaTime * this.speed, axis) * this.direction;

		this.transform.position += this.direction * Time.deltaTime * this.speed;

        if(bulletsShot <= maxBullets)
        {
            if ((timer -= Time.deltaTime) < 0)
            {
                Shoot();
                timer = 10f;
            }
        }
    }

    void Shoot()
    {
        GameObject f = GameObject.Instantiate(bullet, this.transform.position, this.transform.rotation);
        f.GetComponent<damageController>().target = "Player";
        bulletsShot++;
    }

	void OnDestroy()
	{
		GameObject.Destroy(this.tracker);
	}
}
