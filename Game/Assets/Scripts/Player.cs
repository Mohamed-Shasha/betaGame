using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed ;
    public float turnSpeed ;
    public GameManager gameManager;
    public float horInput;
    public float verticalInput;
    public GameObject explosion;
    public ParticleSystem dirt;
    public AudioClip powerUpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
        dirt.Play();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horInput = Input.GetAxis("Horizontal");

        if (gameManager.gameIsAvtive == true)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
            transform.Rotate(Vector3.up, turnSpeed * horInput * Time.deltaTime);
        }
        if (transform.position.y < -1)
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }

    }
    
     public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Power"))
        {

            playerAudio.PlayOneShot(powerUpSound, 1.0f);

        }

    }




    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Egg") && gameManager.gameIsAvtive)
        {
            gameManager.UpdateScore(5);
            playerAudio.PlayOneShot(crashSound, 1.0f);

        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject particle = Instantiate(explosion, transform.position, transform.rotation);
            particle.GetComponent<ParticleSystem>().Play();
            dirt.Stop();
            Destroy(gameObject);
            gameManager.GameOver();

        }

    }

  


}
