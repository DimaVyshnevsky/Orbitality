using UnityEngine;
using UnityEngine.Events;
using missile_system;

namespace star_system
{
    public class Planet : MonoBehaviour
    {
        [SerializeField] private Orbit _orbit;
        [SerializeField] private AxisRotation _axisRotation;
        [SerializeField] private Transform _body;

        [SerializeField] private UnityEvent GetDamageEvent;
        [SerializeField] private UnityEvent DestroyPlanetEvent;

        private PlanetConfig _config;
        private float _lifes;

        public PlanetConfig Data => _config;
        public float Lifes => _lifes;

        public void Init(PlanetConfig config, Transform sun)
        {
            _config = config;
            _lifes = config.Life;
            _orbit.Init(config.EllipsePosition.x, config.EllipsePosition.y, config.OrbitSpeed, config.YOffset, config.RotateClockwise, sun);
            _axisRotation.Init(config.AxisSpeed);
            SetScale(config.Diameter);
        }

        private void SetScale(float diameter)
        {
            _body.localScale = Vector3.one * diameter;
        }

        public void SetDamage(float damage)
        {
            _lifes -= damage;

            if (_lifes <= 0)
            {
                DestroyPlanetEvent?.Invoke();
                return;
            }

            GetDamageEvent?.Invoke();
        }

        public void DestroyPlanet()
        {
            Destroy(this.gameObject);
        }
    }
}