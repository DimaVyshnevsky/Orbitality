﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace missile_system
{
    public class MoverMissile : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rig;
        [SerializeField] private bool _fire;
        [SerializeField] private MissileConfig _config;

        [SerializeField] private UnityEvent ExplosionEvent;
        [SerializeField] private UnityEvent OnCollisionEnterEvent;

        private float _speed;

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

            _rig.AddForce(transform.forward * _speed * Time.fixedDeltaTime);

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
            Explosion();
        }

        public void Explosion()
        {
            ExplosionEvent?.Invoke();
        }

        public void DestroyMissile()
        {
            Destroy(this.gameObject);
        }
    }
}
