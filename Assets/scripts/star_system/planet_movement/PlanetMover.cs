using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace star_system
{
    public abstract class PlanetMover : MonoBehaviour
    {
        public abstract void Init(PlanetData data);
        public abstract Vector2 Evaluate(PlanetData data);
    }
}