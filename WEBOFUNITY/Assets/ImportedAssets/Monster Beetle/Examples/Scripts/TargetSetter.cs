using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Monster_Beetle.Scripts;
using UnityEngine;

public class TargetSetter : MonoBehaviour
{

    private Camera _camera;

    private BeetleController _beetleController;

    public GameObject Pointer;

    private

    void Start()
    {
        _camera = FindObjectOfType<Camera>();
        _beetleController = FindObjectOfType<BeetleController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            var raycasts = Physics.RaycastAll(ray).ToArray();

            var hit = raycasts.FirstOrDefault(x => x.transform.name.Equals("Plane"));

            Pointer.transform.position = hit.point;
        }
    }
}
