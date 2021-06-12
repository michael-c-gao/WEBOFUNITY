using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex = 0;


    void Update()
    {
        for (int i = 0; i < popUps.Length; i++){
            if (i == popUpIndex){
                popUps[i].SetActive(true);
            }else{
                popUps[i].SetActive(false);
            }
        }

        if (popUpIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                popUpIndex++;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                popUpIndex++;
            }
        }

        }

        }

         