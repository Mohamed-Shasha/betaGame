using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggs : MonoBehaviour
{
    private float xrange = 16;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {

    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xrange, xrange),1, Random.Range(5, 33));
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("Enemy") && gameManager.gameIsAvtive)
        {
            Destroy(gameObject);

        }

    }
}
