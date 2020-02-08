using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace star_system
{
    public class ElipsePlanetMovement : PlanetMover
    {
        [SerializeField] private float ratioXToY;

        public override void Init(PlanetData data)
        {
            data.XAxis = data.DistanceFromCenter;
            data.YAxis = data.DistanceFromCenter * ratioXToY;
        }

        public override Vector2 Evaluate(PlanetData data)
        {
            float angle = Mathf.Deg2Rad * 360f * data.OrbitProgress;
            float x = Mathf.Sin(angle) * data.XAxis;
            float y = Mathf.Cos(angle) * data.YAxis;
            return new Vector2(x, y);
        }
    }
}