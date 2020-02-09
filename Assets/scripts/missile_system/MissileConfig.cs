using UnityEngine;
using System.Collections;

namespace missile_system
{
    [CreateAssetMenu(fileName = "missile_", menuName = "Configs/ Missile", order = 4)]
    public class MissileConfig : ScriptableObject
    {
        public GameObject Pref;
        public float StartAcceleration = 10f;
        public float Speed = 80f;
        public float SpeedMax = 80f;
        public float SpeedMult = 1f;
        public float LifeTime = 5f;
        public bool IsLifeTime;
        public float Mass = 1f;
        public Vector3 Noise = new Vector3(20f, 20f, 20f);
        public bool NoiseActive;
    }
}