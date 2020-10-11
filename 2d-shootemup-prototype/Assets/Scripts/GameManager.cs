using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;
    private GameObject getReadyText;
    private int score;
    private Text scoreText;
    public GameObject gameOverPanel;

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3);
        getReadyText.SetActive(false);
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore()
    {
        score += 25;
    }


    // Start is called before the first frame update
    void Start()
    {
        getReadyText = GameObject.Find("Get Ready Label");
        StartCoroutine(StartGame());
        score = 0;
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }
}
