using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

   
    private Rigidbody enemyRb;
    private GameObject player;
    private Player play;
    public GameManager gameManager;
    private float xrange = 25;
    
   
    void Start()
    {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        player = GameObject.Find("Player");
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {


        if (gameManager.gameIsAvtive == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.020f);
        }


    }

    Vector3 RandomSpawnPos()
    {
       

            return new Vector3(Random.Range(-xrange, xrange), 0, Random.Range(-35,35));
        }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy") && gameManager.gameIsAvtive)
        {
            Destroy(gameObject);
        }

    }


}