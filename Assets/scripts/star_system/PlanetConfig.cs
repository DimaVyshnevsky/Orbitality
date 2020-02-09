using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace star_system
{
    [CreateAssetMenu(fileName = "PlanetConfig", menuName = "Configs/PlanetConfig", order = 2)]
    public class PlanetConfig : ScriptableObject
    {
        public GameObject Pref;
        public Vector2 EllipsePosition;
        public int Life;
        public float AxisSpeed;
        public float OrbitSpeed;
        public float YOffset;
        public bool RotateClockwise;
        [Range(1, 5)] public float Diameter;
        public float Gravity;
        public float InfluenceGravityRadius;
        public AnimationCurve GravityForcePerDistance;

        public bool PlayerPlanet;
    }
}