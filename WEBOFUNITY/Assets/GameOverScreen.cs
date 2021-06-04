using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public static bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = true;
        Time.timeScale = 0;
    }
    void Update()
    {
        
        Cursor.visible = true;
    }

    public void Setup()
    {
        isGameOver = true;
        gameObject.SetActive(true);
    }

    public void Restart()
    {
        isGameOver = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Enviro");
    }

    public void ExitButton()
    {
        isGameOver = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("menu");
    }
}
