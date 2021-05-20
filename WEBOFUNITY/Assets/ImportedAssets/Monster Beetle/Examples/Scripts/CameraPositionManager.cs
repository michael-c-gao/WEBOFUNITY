using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionManager : MonoBehaviour
{

    public Transform[] Positions;

    private int _index;

    public void Next()
    {
        if (_index++ >= Positions.Length - 1) _index = 0;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Positions[_index].position, 1f * Time.deltaTime);

        transform.rotation = Quaternion.Lerp(transform.rotation, Positions[_index].rotation, 1 * Time.deltaTime);
    }

}
