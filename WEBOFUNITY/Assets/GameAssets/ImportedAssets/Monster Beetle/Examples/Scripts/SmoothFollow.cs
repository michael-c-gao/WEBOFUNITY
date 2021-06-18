using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Behaviours.Camera
{
    public class SmoothFollow : MonoBehaviour
    {

        public Transform target;
        private Transform _thisTransform;


        void Start()
        {
            _thisTransform = GetComponent<Transform>();
        }

        void Update()
        {
            if (target)
            {
                Vector3 destination = target.position;
                destination.y = _thisTransform.position.y;
               _thisTransform.position = Vector3.Slerp(_thisTransform.position, destination, 1f * Time.deltaTime);
            }
        }
    }
}
