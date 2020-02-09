using UnityEngine;
using utils;

namespace star_system
{
    [CreateAssetMenu(fileName = "StarSystemConfig", menuName = "Configs/StarSystem", order = 1)]
    public class StarSystemConfig : ScriptableObject
    {
        public PlanetConfig[] Planets;
    }
}