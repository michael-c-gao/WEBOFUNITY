using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatIncreaserScript : MonoBehaviour
{
    public string ScaleType = "health";

    // Start is called before the first frame update
    void Start()
    {
        switch (ScaleType)
        {
            case "health":
                initializeHealthSettings();
                break;
            case "damage":
                initializeDamageSettings();
                break;
            case "lifesteal":
                initializeLifestealSettings();
                break;
            case "speed":
                initializeSpeedSettings();
                break;
            default:
                print("ScaleType has not been entered properly. Defaulting to initializeHealthSettings().");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string getScaleType()
    {
        return ScaleType;
    }

    private void initializeHealthSettings()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }
    private void initializeDamageSettings()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
    }
    private void initializeLifestealSettings()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }
    private void initializeSpeedSettings()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
    }
}
