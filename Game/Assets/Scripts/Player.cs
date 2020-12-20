using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public GameManager gameManager;
    public float horInput;
    public float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horInput = Input.GetAxis("Horizontal");

        if (gameManager.gameIsAvtive == true) { 
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        transform.Translate(Vector3.right * speed * Time.deltaTime * horInput);
    }
        if (transform.position.y < -1)
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }



    }
    private void OnCollisionEnter(Collision collision)
    {
        
            if (collision.gameObject.CompareTag("Egg") && gameManager.gameIsAvtive )
            {
                gameManager.UpdateScore(5);       
                
            }
       if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Barrier"))
        {
            Destroy(gameObject);
            gameManager.GameOver();

        }

    }
 


}
