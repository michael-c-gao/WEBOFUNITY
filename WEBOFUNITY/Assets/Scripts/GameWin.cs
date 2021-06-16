using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public static bool isWin = false;

    // Start is called before the first frame update
    public void Start()
    {
        Time.timeScale = 1;
        gameObject.SetActive(true);
        isWin = true;
}

    public void ExiteButton()
    {
        isWin = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("menu");
    }
}
