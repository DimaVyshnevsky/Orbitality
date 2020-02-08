using System;
using UnityEngine;
using utils;

namespace star_system
{
    public class EnvironmentCreator : MonoBehaviour
    {
        [SerializeField] private StarSystemConfig _config;
        [SerializeField] private EnvironmentMover _environmentMover;
        [SerializeField] private PlanetMover _movementType;

        private PlanetData[] _planetsData;
        public PlanetData[] PlanetsData => _planetsData;

        private void Start()
        {
            GenerateEnvironment();
            _environmentMover.Init(_movementType, this);
        }

        private void GenerateEnvironment()
        {
            int planetCont = Utils.GetRandomIntValue(_config.PlanetsCount);
            _planetsData = new PlanetData[planetCont];

            for (int i = 0; i < planetCont; i++)
            {
                GeneratePlanet(i, out _planetsData[i]);
            }
        }

        private void GeneratePlanet(int id, out PlanetData data)
        {
            data = GeneratePlanetData(id);
            GenerateGameObject(data);
        }

        private PlanetData GeneratePlanetData(int id)
        {
            int lifes = Utils.GetRandomIntValue(_config.PlanetLife);
            float radius = Utils.GetRandomFloatValue(_config.PlanetRadius);
            float axisSpeed = Utils.GetRandomFloatValue(_config.PlanetAxisSpeed);
            float gravity = Utils.GetRandomFloatValue(_config.PlanetGravity);

            PlanetData data = new PlanetData(id, radius, lifes, axisSpeed, gravity);

            return data;
        }

        private Planet GenerateGameObject(PlanetData data)
        {
            int randomPlanet = Utils.GetRandomIntValue(0, _config.PlanetPref.Length);
            Vector3 startPosition = GeneratePlanetPosition(data, id);
            Planet planet = Instantiate(_config.PlanetPref[randomPlanet], startPosition, Quaternion.identity, this.transform).GetComponent<star_system.Planet>();
            float orbitSpeed = Utils.GetRandomFloatValue(_config.OrbitSpeed);

            data.PlanetObject = planet;
            return data.PlanetObject
        }

        private Vector3 GeneratePlanetPosition(PlanetData data, int step)
        {
            step++;
            float radiusFromCenter = step * _config.BetweenPlanetDistance;
            data.DistanceFromCenter = radiusFromCenter;
            _movementType.Init(data);
            Vector2 orbitPosition = Evaluate(data);
            return new Vector3(orbitPosition.x, 0, orbitPosition.y);
        }

        private Vector2 Evaluate(PlanetData data)
        {         
            return _movementType.Evaluate(data);
        }
    }
}