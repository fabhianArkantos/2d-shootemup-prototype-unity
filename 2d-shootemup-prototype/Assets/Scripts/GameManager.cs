using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Time.timeScale = 0;
            Debug.Log("Game Over!");
            Restart();
        }
    }

    private void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
