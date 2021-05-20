using System.Collections;
using System.Collections.Generic;
using Assets.Monster_Beetle.Scripts;
using UnityEngine;

public class ColorSetter : MonoBehaviour
{
    private Renderer _renderer;

    public Color[] Colors;
    private int _index;

    void Start ()
	{
	    _renderer = FindObjectOfType<BeetleController>().GetComponentInChildren<Renderer>();
	}

    public void Next()
    {
        if (_index++ >= Colors.Length - 1) _index = 0;

        _renderer.material.color = Colors[_index];
    }
}
