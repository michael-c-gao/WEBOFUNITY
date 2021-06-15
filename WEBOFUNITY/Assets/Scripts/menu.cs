using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{




    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    // Start is called before the first frame update
    public void PlayGame()
    {
        Cursor.visible = true;
        GameOverScreen.isGameOver = false;
        PauseMenu.isPaused = false;
        GameWin.isWin = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        Time.timeScale = 1;
    }

    


    public void exitGame()
    {
        Application.Quit();
    }
    
}
