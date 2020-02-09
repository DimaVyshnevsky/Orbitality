using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace missile_system
{
    [CreateAssetMenu(fileName = "missiles_config", menuName = "Configs/MissilesConfig", order = 3)]
    public class MissilesConfigContainer : ScriptableObject
    {
        public MissileConfig[] Missiles;
    }
}