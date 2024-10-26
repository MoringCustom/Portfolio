using UnityEngine;

namespace BS.Units.Weapons.Projectiles
{
    public class Thrower
    {
        private readonly float _formulaVariable = 2f;

        public Vector3 CalculateVelocityByHeight(Vector3 start, Vector3 end, float height)
        {
            float timeToRise = CalculateTimeByHeight(height);
            float timeToFall = CalculateTimeByHeight(height + (start - end).y);

            Vector3 horizontalVelocity = end - start;
            horizontalVelocity.y = 0;
            horizontalVelocity /= timeToRise + timeToFall;

            Vector3 verticalVelocity = -Physics.gravity * timeToRise;

            return horizontalVelocity + verticalVelocity;
        }

        private float CalculateTimeByHeight(float height)
        {
            var gravityFactor = Mathf.Abs(Physics.gravity.y);

            return Mathf.Sqrt(_formulaVariable * height / gravityFactor);
        }
    }
}