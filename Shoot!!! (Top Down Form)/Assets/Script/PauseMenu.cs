using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public bool isPaused;
    public GameObject pauseMenuCanvas;


    void Start()
    {

    }

    void Update()
    {
        if (isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        isPaused = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void ReturnToMenu()
    {
        Application.LoadLevel(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
