using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace star_system
{
    public class Orbit : MonoBehaviour
    {
        [SerializeField] private float _xSpread;
        [SerializeField] private float _zSpread;
        [SerializeField] private float _yOffset;
        [SerializeField] private Transform _centerPoint;

        [SerializeField] private float _rotSpeed;
        [SerializeField] private bool _rotateClockwise;
        [SerializeField] private bool _initialize;

        private float _timer = 0;

        public void Init(float xSpread, float zSpread, float rotSpeed, float yOffset, bool rotateClockwise, Transform centerPoint)
        {
            _xSpread = xSpread;
            _zSpread = zSpread;
            _rotSpeed = rotSpeed;
            _yOffset = yOffset;
            _rotateClockwise = rotateClockwise;
            _centerPoint = centerPoint;
            _timer = utils.Utils.GetRandomIntValue(0, 100);
            _initialize = true;
        }

        void FixedUpdate()
        {
            if (!_initialize)
                return;

            _timer += Time.deltaTime * _rotSpeed;
            Rotate();
        }

        void Rotate()
        {
            if (_rotateClockwise)
            {
                float x = -Mathf.Cos(_timer) * _xSpread;
                float z = Mathf.Sin(_timer) * _zSpread;
                Vector3 pos = new Vector3(x, _yOffset, z);
                transform.position = pos + _centerPoint.position;
            }
            else
            {
                float x = Mathf.Cos(_timer) * _xSpread;
                float z = Mathf.Sin(_timer) * _zSpread;
                Vector3 pos = new Vector3(x, _yOffset, z);
                transform.position = pos + _centerPoint.position;
            }
        }
    }
}