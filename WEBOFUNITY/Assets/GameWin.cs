using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{


    // Start is called before the first frame update
    public void Setup()
    {

        gameObject.SetActive(true);
    }

    public void ExiteButton()
    {
        
        Time.timeScale = 1;
        SceneManager.LoadScene("menu");
    }
}
