using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using physics;
using Random = UnityEngine.Random;

namespace missile_system
{
    public class MoverMissile : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rig;
        [SerializeField] private bool _fire;
        [SerializeField] private MissileConfig _config;

        [SerializeField] private UnityEvent InteractionEvent;
        [SerializeField] private UnityEvent OnCollisionEnterEvent;

        private float _speed;
        private bool _interaction;

        private void Awake()
        {
            _rig.mass = _config.Mass;
            _speed = _config.Speed;

            _rig.velocity = transform.forward * _config.StartAcceleration;
        }

        private void FixedUpdate()
        {
            if (!_fire)
                return;

            Vector3 movementDirection = transform.forward * _speed *Time.fixedDeltaTime;
            movementDirection = GravitySystem.Instance.CorrectMovement(transform.position, movementDirection);

            _rig.AddForce(movementDirection);

            transform.LookAt(transform.position + _rig.velocity);
           
             if (_config.NoiseActive)
                _rig.velocity += new Vector3(Random.Range(-_config.Noise.x, _config.Noise.x), Random.Range(-_config.Noise.y, _config.Noise.y), Random.Range(-_config.Noise.z, _config.Noise.z));

            if (_speed < _config.SpeedMax)
                _speed += _config.SpeedMult * Time.fixedDeltaTime;
        }

        private void OnCollisionEnter(Collision col)
        {
            OnCollisionEnterEvent?.Invoke();
        }

        public void Fire()
        {
            if(_config.IsLifeTime)
                StartCoroutine(TimerOn(_config.LifeTime));
        
                _fire = true;
        }
        
        private IEnumerator TimerOn(float time)
        {
            yield return new WaitForSeconds(time);
            InteractionEvent?.Invoke();
        }

        public void Interaction(Transform tr)
        {
            InteractionEvent?.Invoke();
        }

        public void DestroyMissile()
        {
            Destroy(this.gameObject);
        }
    }
}
