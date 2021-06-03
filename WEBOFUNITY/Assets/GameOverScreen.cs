using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }
    void Update()
    {
        Cursor.visible = true;
    }

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Enviro");
    }

    public void ExitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("menu");
    }
}
