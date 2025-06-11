using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText; // to keimeno pou tha grafei to score
    public TMP_Text lossText;
    public GameObject gameOverPanel; // to panel pou tha emfanistei otan teleiwsei to game (eite xaseis eite kerdiseis)
    public TMP_Text winText;
    public GameObject winPanel;

    private float survivalTime = 0f;
    private bool isOver = false;


    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false); // kanw disable (na min fainetai) to panel otan ksekinaei to game
        winPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOver) // isOver == false
        {
            survivalTime += Time.deltaTime;
            scoreText.text = "Score: " + Mathf.FloorToInt(survivalTime);
        }

        if (isOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // restart scene
        }
    }

    public void GameOver()
    {
        isOver = true;
        gameOverPanel.SetActive(true);
        lossText.text = "Your final Score is " + Mathf.FloorToInt(survivalTime) + "\n Press R to play again"; // \n -> new line (enter)
    }

    public void WinGame()
    {
        isOver = true;
        winPanel.SetActive(true);
        winText.text = "Your final Score is " + Mathf.FloorToInt(survivalTime) + "\n Press R to play again"; // \n -> new line (enter)
    }
}