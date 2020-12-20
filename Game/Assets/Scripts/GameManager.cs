using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public GameObject titleScreen;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI won;
    protected int score;
    public List<GameObject> targets;
    float spawnRate = 6f;
    public bool gameIsAvtive;
    public Button RestartButton;
    public GameObject powerUp;
    public GameObject egg;
    public int powerCount;




    // Start is called before the first frame update
    void Start()
    {

      

    }

    public void StartGame(float difficulty)
    {

        gameIsAvtive = true;
        StartCoroutine(SpawnTarget());
        StartCoroutine(SpawnPowerUp());
        StartCoroutine(SpawnEggs());
        score = 0;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
    }

    // Update is called once per frame
    void Update()
    {
        Gamewon();
        powerCount = FindObjectsOfType<Powerup>().Length;

    }

    IEnumerator SpawnTarget()
    {
        while (gameIsAvtive)
        {

            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);


        }

    }
    IEnumerator SpawnPowerUp()
    {
        
        while (gameIsAvtive && powerCount==0)
        {

            yield return new WaitForSeconds(9);

            Instantiate(powerUp);


        }

    }

    IEnumerator SpawnEggs()
    {
        while (gameIsAvtive)
        {

            yield return new WaitForSeconds( spawnRate/1.5f);

            Instantiate(egg);


        }

    }





    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void Gamewon()
    {
        if (score >= 30)
        {
            RestartButton.gameObject.SetActive(true);
            won.gameObject.SetActive(true);
            gameIsAvtive = false;
            
        }
        else
        {
            SpawnTarget();
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        gameIsAvtive = false;
    }
    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   


}
