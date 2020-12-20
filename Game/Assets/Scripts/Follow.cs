using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private Vector3 offset = new Vector3(0, 25,-17);
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameIsAvtive == true)
        {
            transform.position = player.transform.position + offset;
        }
    }
}
