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
    float spawnRate = 1.5f;
    public bool gameIsAvtive;
    public Button RestartButton;
   


    // Start is called before the first frame update
    void Start()
    {

      

    }

    public void StartGame(float difficulty)
    {

        gameIsAvtive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
    }

    // Update is called once per frame
    void Update()
    {
        Gamewon();
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

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void Gamewon()
    {
        if (score == 30)
        {
            RestartButton.gameObject.SetActive(true);
            won.gameObject.SetActive(true);
            gameIsAvtive = false;
            
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