using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageController : MonoBehaviour
{

    [SerializeField]
    private int damage;

    [SerializeField]
    public string target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == target | collider.gameObject.tag == "Asteroid")
        {
            GetComponent<Collider>().enabled = false;
            Destroy(this.gameObject);
            collider.gameObject.GetComponent<HealthCounter>().DecrementHealth(damage);
        }
    }
}