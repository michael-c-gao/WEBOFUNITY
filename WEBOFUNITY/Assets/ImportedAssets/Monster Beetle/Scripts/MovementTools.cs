using UnityEngine;

namespace Assets.Monster_Beetle.Scripts
{
    public class MovementTools
    {

        private Transform _sourceTransform;

        private Animator _animator;

        private Rigidbody _rb;

        private const float RunAnimationSpeedMultiplier = 0.5f;
        private const float RotateAnimationSpeedMultiplier = 0.4f;

        public MovementTools(GameObject bug)
        {
            _sourceTransform = bug.transform;
            _animator = bug.GetComponent<Animator>();
            _rb = bug.GetComponent<Rigidbody>();
        }

        public float RotateTo(Transform target, float rotationSpeed)
        {

            var targetDirection = target.position - _sourceTransform.position;

            var angle = Vector3.Angle(targetDirection, _sourceTransform.forward);

            if (angle < 3) return angle;

            _animator.SetFloat("SpeedM", RotateAnimationSpeedMultiplier * rotationSpeed * (angle * 0.0056f + 1));

            var targetRotation = Quaternion.LookRotation(targetDirection);

            _rb.MoveRotation(Quaternion.Slerp(_sourceTransform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));

            return angle;

        }

        public float RotateTo(Vector3 target, float rotationSpeed)
        {
            var targetDirection = target - _sourceTransform.position;

            var angle = Vector3.Angle(targetDirection, _sourceTransform.forward);

            if (angle < 3) return angle;

            _animator.SetFloat("SpeedM", RotateAnimationSpeedMultiplier * rotationSpeed * (angle * 0.0056f + 1));

            var targetRotation = Quaternion.LookRotation(targetDirection);

            _rb.MoveRotation(Quaternion.Slerp(_sourceTransform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));

            return angle;

        }

        public float GetAngleTo(Transform target)
        {
            var targetDirection = target.position - _sourceTransform.position;
            var targetRotation = Quaternion.LookRotation(targetDirection);
            var angle = Vector3.Angle(targetDirection, _sourceTransform.forward);
            return angle;
        }

        public void RunForward(float runSpeed, float? animationSpeed = null)
        {

            if (animationSpeed == null) animationSpeed = runSpeed * RunAnimationSpeedMultiplier;

            float calculatedSpeed = runSpeed;

            _animator.SetFloat("SpeedM", (float)animationSpeed);

            var time = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime % 1;

            if ((time > 0.4 && time < 0.6) || time > 0.9 || time < 0.1)
                calculatedSpeed = runSpeed * 0.33f;

            _rb.MovePosition(_rb.position + _rb.rotation * Vector3.forward * calculatedSpeed * Time.deltaTime);
        }

        //Todo баг со скоростью (возможно сделать отдельную анимацию)
        public void RunBackward(float runSpeed, float? animationSpeed = null)
        {

            runSpeed *= 0.8f;
            if (animationSpeed == null) animationSpeed = -runSpeed * RunAnimationSpeedMultiplier;

            float calculatedSpeed = runSpeed;

            _animator.SetFloat("SpeedM", (float)animationSpeed);

            var time = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime % 1;

            if ((time > 0.4 && time < 0.6) || time > 0.9 || time < 0.1)
                calculatedSpeed = runSpeed * 0.33f;


            _rb.MovePosition(_rb.position + _rb.rotation * Vector3.back * calculatedSpeed * Time.deltaTime);
        }

        /// <summary>
        /// Поворот к объекту и бег
        /// </summary>
        /// <param name="target"></param>
        /// <param name="runSpeed"></param>
        /// <param name="rotateSpeed"></param>
        public void RunTo(Transform target, float runSpeed, float rotateSpeed)
        {
            var angle = RotateTo(target, rotateSpeed);

            if (angle < 90) { }
            RunForward(runSpeed / (angle * 0.017f + 1), runSpeed * RunAnimationSpeedMultiplier * (angle * 0.017f + 1));
        }


        public void RunTo(Vector3 point, float runSpeed, float rotateSpeed)
        {
            var angle = RotateTo(point, rotateSpeed);

            if (angle < 90) { }
            RunForward(runSpeed / (angle * 0.017f + 1), runSpeed * RunAnimationSpeedMultiplier * (angle * 0.017f + 1));
        }



        public void Stop()
        {
            _animator.SetFloat("SpeedM", 0f);
        }

        public void Eat()
        {
            _animator.SetFloat("SpeedM", 0f);
            _animator.SetBool("isEating", true);

        }



    }




}
