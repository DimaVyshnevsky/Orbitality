using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElipseOrbit : MonoBehaviour
{
    [SerializeField] private Transform _planet;
    [SerializeField] public float _xAxis;
    [SerializeField] public float _yAxis;
    [SerializeField] public float _orbitSpeed;
    [SerializeField] public float _orbitProgress;

    public void Init(float xAxis, float yAxis, float orbitSpeed, float orbitProgress)
    {
        _xAxis = xAxis;
        _yAxis = yAxis;
        _orbitSpeed = orbitSpeed;
        _orbitProgress = orbitProgress;
    }

    public Vector2 Evaluate()
    {
        float angle = Mathf.Deg2Rad * 360f * _orbitProgress;
        float x = Mathf.Sin(angle) * _xAxis;
        float y = Mathf.Cos(angle) * _yAxis;
        return new Vector2(x, y);
    }

    private void GetNewPlanetPosition()
    {
        if (_orbitSpeed < 0.1f)
            _orbitSpeed = 0.1f;

        float orbitSpeed = 1f / _orbitSpeed;
        _orbitProgress += Time.deltaTime * orbitSpeed;
        _orbitProgress %= 1f;
        Vector2 orbitPosition = Evaluate();
        _planet.localPosition = new Vector3(orbitPosition.x, 0, orbitPosition.y);
    }

    private void FixedUpdate()
    {
        GetNewPlanetPosition();
    }
}
