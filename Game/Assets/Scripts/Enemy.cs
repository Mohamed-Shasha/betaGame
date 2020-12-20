using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update


    private Rigidbody enemyRb;
    private GameObject player;
    private GameObject enemy;
    public GameManager gameManager;
    private Powerup power;
   

    void Start()
    {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");


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




        if (gameManager.gameIsAvtive == true)
        {
            transform.LookAt(player.transform);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.006f);


            if (transform.position.y < 0)
            {
                Destroy(gameObject);
                gameManager.GameOver();
            }
        }


    }


    public Vector3 RandomSpawnPos()
    {

        return new Vector3(Random.Range(-20, 20), 0, Random.Range(-8, 20));
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player") )
        {
            Destroy(gameObject);


        }
    }

}
