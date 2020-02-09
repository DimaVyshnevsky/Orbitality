using UnityEngine;
using missile_system;

namespace star_system
{
    public class EnvironmentCreator : MonoBehaviour
    {
        [SerializeField] private StarSystemConfig _starSystem;
        [SerializeField] private Transform _sun;

        private Planet[] _planets;
        private MissileLauncher _playerLauncher;

        public Planet[] Planets => _planets;

        private void Start()
        {
            GenerateEnvironment();
        }

        private void GenerateEnvironment()
        {
            int planetCont = _starSystem.Planets.Length;
            _planets = new Planet[planetCont];

            for (int i = 0; i < planetCont; i++)
                _planets[i] = GeneratePlanet(_starSystem.Planets[i]);
        }

        private Planet GeneratePlanet(PlanetConfig planetConfig)
        {
            Planet planet = Instantiate(planetConfig.Pref, Vector3.zero, Quaternion.identity, this.transform).GetComponent<star_system.Planet>();
            planet.Init(planetConfig, _sun);

            if (planetConfig.PlayerPlanet)
                _playerLauncher = planet.gameObject.GetComponent<MissileLauncher>();

            return planet;
        }

        public MissileLauncher GetPlayerLauncher()
        {
            return _playerLauncher;
        }
    }
}