using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;


    private int score;

    //private bool firstrun = false;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        gameOver.SetActive(false);
        Pause();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

        }
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1;
        player.enabled = true;

        Pipe[] pipes = FindObjectsOfType<Pipe>();
        for(int i=0; i< pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }

        

    }

    public void Pause()
    {
        Time.timeScale = 0f ;
        player.enabled = false;

    }


    public void GameOver()
    {
        Debug.Log("game over");
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

        }
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
