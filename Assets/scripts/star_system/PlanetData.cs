using System;
using System.Collections.Generic;
using UnityEngine;

namespace star_system
{
    [Serializable]
    public class SpaceObject
    {
        public float Radius;
        public float Gravity;
        public Vector3 Position;
    }

    public class PlanetData : SpaceObject
    {
        private int _id;
        private int _lifes;
        private float _axisSpeed;

        public float OrbitSpeed;
        public float OrbitProgress;
        public float XAxis;
        public float YAxis;

        public float DistanceFromCenter;
        public Transform PlanetTransform;

        public int ID => _id;
        public int Lifes => _lifes;
        public float AxisSpeed => _axisSpeed;

        public PlanetData(int id, float radius, int lifes, float axisSpeed, float gravity)
        {
            _id = id;
            _lifes = lifes;
            _axisSpeed = axisSpeed;

            Gravity = gravity;
            Radius = radius;
        }
    }
}