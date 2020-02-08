using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace star_system
{
    public class Planet : MonoBehaviour
    {
        [SerializeField] private ElipseOrbit _elipseOrbit;
        [SerializeField] private AxisRotation _axisRotation;
        [SerializeField] private Transform _object;

        public void Init(PlanetData data)
        {
            _elipseOrbit.Init()
        }

        public void SetScale(float radius)
        {
            _object.localScale = Vector3.one * radius * 2;
        }
    }
}