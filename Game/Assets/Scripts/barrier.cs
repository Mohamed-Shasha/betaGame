using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{
    private float xrange = 22;
    private float zrange = 9;
    private GameManager gameManager;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameManager.gameIsAvtive == true)
        {
            if (player.transform.position.x > RandomSpawnPos().x && player.transform.position.z > RandomSpawnPos().z)
            {
                transform.position = RandomSpawnPos();
            }
            

        }

    }

    // Update is called once per frame
    void Update()
    {

      }
      
      
    }
    Vector3 RandomSpawnPos()
    {

        return new Vector3(Random.Range(-xrange, xrange), 0, Random.Range(-zrange, 25));
    }

}
