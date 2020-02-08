using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace star_system
{
    public class AxisRotation : MonoBehaviour
    {
        [SerializeField] private Transform _planet;
        [SerializeField] private float _speed;

        void Update()
        {
            RotatePlanet();
        }

        public void Init(float speed)
        {
            _speed = speed;

        }

        private void RotatePlanet()
        {
            _planet.Rotate(Vector3.up, _speed);
        }
    }
}