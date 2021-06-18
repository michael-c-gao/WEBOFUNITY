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

    public void PlayGame()
    {
        GameOverScreen.isGameOver = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        SceneManager.LoadScene("Enviro");

    }




    public void exitGame()
    {
        Application.Quit();
    }

}
