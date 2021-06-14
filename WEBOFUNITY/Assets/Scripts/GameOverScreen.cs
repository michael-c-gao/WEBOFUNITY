using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public static bool isGameOver = false;
    public Transform teleportTarget;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        isGameOver = true;
        Time.timeScale = 0;
        Cursor.visible = true;
    }


    public void Setup()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        isGameOver = true;
        Cursor.visible = true;
    }

    public void Restart()
    {
        isGameOver = false;
        Cursor.visible = false;
        Time.timeScale = 1;
        PlayerStats.health = 100;
        Player.transform.position = teleportTarget.transform.position;
        gameObject.SetActive(false);
    }

    public void ExitButton()
    {
        isGameOver = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("menu");
    }
}
