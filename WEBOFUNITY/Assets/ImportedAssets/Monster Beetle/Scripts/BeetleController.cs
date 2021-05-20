using UnityEngine;

namespace Assets.Monster_Beetle.Scripts
{
    public class BeetleController : MonoBehaviour
    {

        public Transform Target;

        public float RotationSpeed = 5;

        public float RunSpeed = 5;

        private MovementTools _movementTools;
        void Start()
        {
            _movementTools = new MovementTools(this.gameObject);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (Target != null && Vector3.Distance(Target.position, transform.position) > 3f)
                _movementTools.RunTo(Target, RunSpeed, RotationSpeed);

            else _movementTools.Stop();
        }
    }
}
