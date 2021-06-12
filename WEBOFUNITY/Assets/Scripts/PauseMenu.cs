using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        
    }

    // Update is called once per frame
    public void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (isPaused)
            {
                Cursor.visible = false;
                ResumeGame();
            }
            else
            {
                PauseGame();
                Cursor.visible = true;
            }
        }
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        ResumeGame();
        
        SceneManager.LoadScene("menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
