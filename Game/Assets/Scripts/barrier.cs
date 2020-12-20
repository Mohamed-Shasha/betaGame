using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{
    private float xrange = 22;
   
    // Start is called before the first frame update
    void Start()
    {
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {

    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xrange, xrange), 0, Random.Range(2, 20));
    }
}
