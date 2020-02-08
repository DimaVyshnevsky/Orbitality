using UnityEngine;
using utils;

namespace star_system
{
    [CreateAssetMenu(fileName = "StarSystemConfig", menuName = "Configs/StarSystem", order = 1)]
    public class StarSystemConfig : ScriptableObject
    {
        public GameObject[] PlanetPref;
        public utils.RangeInt PlanetLife;

        [Header("Movement characteristic")]
        public RangeFloat PlanetAxisSpeed;
        public RangeFloat OrbitSpeed;
        public RangeFloat OrbitProgress;

        [Header("Position in space")]
        public utils.RangeInt PlanetsCount;
        public float BetweenPlanetDistance;
        public RangeFloat PlanetRadius;

        [Header("Gravity")]
        public SpaceObject Sun;
        public RangeFloat PlanetGravity;
        public AnimationCurve GravityForcePerDistance;
    }
}