using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    private int numberSpawned;

    [SerializeField]
    private int maxSpawn;

    [SerializeField]
    private GameObject satelite;

    [SerializeField]
    private GameObject tracker;

    [SerializeField]
    private float timer = 10f;

    // Start is called before the first frame update
    void Start()
    {
        numberSpawned = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if((timer -= Time.deltaTime) < 0)
        {
            SpawnSatelite();
            timer = 10f;
        }
    }

    void SpawnSatelite()
    {
        if(numberSpawned <= maxSpawn)
        {
            GameObject s = GameObject.Instantiate(satelite);
            GameObject g = GameObject.Instantiate(tracker, GameObject.FindGameObjectWithTag("UI").transform);
            g.GetComponent<SateliteTracker>().target = s.transform;
			s.GetComponent<EnemyAI>().tracker = g;
            numberSpawned++;
        }
    }
}
