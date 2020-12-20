using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody enemyRb;
    private GameObject player;
    private GameObject power;
    private Player play;
    public bool powerup = false;
    private GameManager gameManager;
    private Player playerRB;
    public GameObject explosion;
    private float multiplier = 2;
    private GameObject enemy;
    void Start()
    {
        
  gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            player = GameObject.Find("Player");
            playerRB = GameObject.Find("Player").GetComponent<Player>();
            power = GameObject.Find("powerUp");
            enemy = GameObject.Find("Enemy");

        if (gameManager.gameIsAvtive == true)
        {
           

         if (player.transform.position.x > RandomSpawnPos().x && player.transform.position.z > RandomSpawnPos().z)
            {
                transform.position = RandomSpawnPos();
            }



        }
    }
       
    


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            powerup = true;
            StartCoroutine(picked(other));

        }

    }
    IEnumerator picked(Collider player)
    {
       
        GameObject particle = Instantiate(explosion, transform.position, transform.rotation);
        particle.GetComponent<ParticleSystem>().Play();
        player.transform.localScale *= 1.4f;
        playerRB.speed *= multiplier;
      
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        
        yield return new WaitForSeconds(7);
        playerRB.speed /= multiplier;
        player.transform.localScale /= 1.3f;
        Destroy(gameObject);

    }

   

    public Vector3 RandomSpawnPos()
    {

        return new Vector3(Random.Range(-14, 15), 0.5f, Random.Range(-14, 25));
    }


    

   
        



}







