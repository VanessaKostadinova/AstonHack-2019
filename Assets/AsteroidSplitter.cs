using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSplitter : MonoBehaviour
{
    [SerializeField]
    GameObject pickUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        GameObject.Instantiate(pickUp, this.transform.position, this.transform.rotation);
    }
}
