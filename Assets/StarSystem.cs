using System;
using UnityEngine;
using utils;

namespace star_system
{
    public class PlanetData
    {
        private int _id;
        private int _lifes;
        private float _radius;
        private float _axisSpeed;
        private float _gravity;

        public float OrbitPeriod;//10
        public float OrbitProgress;
        public float XAxis;//10
        public float YAxis;//5

        public int ID => _id;
        public int Lifes => _lifes;
        public float Radius => _radius;
        public float AxisSpeed => _axisSpeed;
        public float Gravity => _gravity;

        public PlanetData(int id, float radius, int lifes, float axisSpeed, float orbitPeriod, float gravity)
        {
            _id = id;
            _radius = radius;
            _lifes = lifes;
            _axisSpeed = axisSpeed;
            _gravity = gravity;

            OrbitPeriod = orbitPeriod;
        }
    }

    [CreateAssetMenu(fileName = "PlanetData", menuName = "Configs/StarSystem", order = 1)]
    public class StarSystemConfig : ScriptableObject
    {
        public utils.RangeInt _planetsCount;
        public utils.RangeInt _planetLife;
        public RangeFloat _betweenPlanetDistance;
        public RangeFloat _planetRadius;
        public RangeFloat _planetAxisSpeed;
        public RangeFloat _planetGravity;
        public RangeFloat _orbitPeriod;
        public RangeFloat _orbitProgress;
        public RangeFloat _xAxisRange;
        public RangeFloat _yAxisRange;
    }

    public class StarSystem : MonoBehaviour
    {
        //todo: get asteroid
        //todo: get planet
        //todo: get rocket
        //todo: sky box

        [SerializeField] private GameObject _planetPref;
        [SerializeField] private StarSystemConfig _config;

        private Transform[] _planetsTransform;
        private PlanetData[] _planetsData;

        private void Start()
        {
            GenerateEnvironment();
        }

        private void GenerateEnvironment()
        {
            int planetCont = Utils.GetRandomIntValue(_config._planetsCount);
            _planetsTransform = new Transform[planetCont];
            _planetsData = new PlanetData[planetCont];

            for (int i = 0; i < planetCont; i++)
            {
                GeneratePlanet(i, out _planetsData[i], out _planetsTransform[i]);
            }
        }

        private void GeneratePlanet(int id, out PlanetData data, out Transform planetTransform)
        {
            data = GeneratePlanetData(id);
            Vector3 startPosition = GeneratePlanetPosition(data);
            planetTransform = Instantiate(_planetPref, startPosition, Quaternion.identity, this.transform).transform;
        }

        private PlanetData GeneratePlanetData(int id)
        {
            int lifes = Utils.GetRandomIntValue(_config._planetLife);
            float radius = Utils.GetRandomFloatValue(_config._planetRadius);
            float axisSpeed = Utils.GetRandomFloatValue(_config._planetRadius);
            float orbitSpeed = Utils.GetRandomFloatValue(_config._planetRadius);
            float gravity = Utils.GetRandomFloatValue(_config._planetRadius);

            return new PlanetData(id, radius, lifes, axisSpeed, orbitSpeed, gravity);
        }

        private Vector3 GeneratePlanetPosition(PlanetData data)
        {
            Vector2 orbitPosition = Evaluate(data.OrbitPeriod, data.XAxis, data.YAxis);
            return new Vector3(orbitPosition.x, 0, orbitPosition.y);
        }

        public Vector2 Evaluate(float t, float xAxis, float yAxis)
        {
            float angle = Mathf.Deg2Rad * 360f * t;
            float x = Mathf.Sin(angle) * xAxis;
            float y = Mathf.Cos(angle) * yAxis;
            return new Vector2(x, y);
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < _planetsData.Length; i++)
            {
                if (_planetsData[i].Lifes <= 0)
                    continue;

                Transform planetTransform = _planetsTransform[_planetsData[i].ID];
                RotatePlanet(_planetsData[i], planetTransform);
            }
        }

        private void RotatePlanet(PlanetData data, Transform planet)
        {
            if (data.OrbitPeriod < 0.1f)
                data.OrbitPeriod = 0.1f;

            float orbitSpeed = 1f / data.OrbitPeriod;
            data.OrbitPeriod += Time.deltaTime * orbitSpeed;
            data.OrbitPeriod %= 1f;
            Vector2 orbitPosition = Evaluate(data.OrbitPeriod, data.XAxis, data.YAxis);
            planet.localPosition = new Vector3(orbitPosition.x, 0, orbitPosition.y);
        }
    }
}

namespace utils
{
    [Serializable]
    public struct RangeFloat
    {
        public float MaxValue;
        public float MinValue;
    }

    [Serializable]
    public struct RangeInt
    {
        public int MaxValue;
        public int MinValue;
    }

    public static class Utils
    {
        public static int GetRandomIntValue(RangeInt range)
        {
            return UnityEngine.Random.Range(range.MinValue, range.MaxValue);
        }

        public static float GetRandomFloatValue(RangeFloat range)
        {
            return UnityEngine.Random.Range(range.MinValue, range.MaxValue);
        }
    }
}
