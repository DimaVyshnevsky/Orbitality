using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace old_data
{
    public class EnvironmentMover : MonoBehaviour
    {
        /*private PlanetMover _movementType;
        private EnvironmentCreator _spaceObjectContainer;
        private bool initialize;

        public void Init(PlanetMover movementType, EnvironmentCreator spaceObjectContainer)
        {
            _movementType = movementType;
            _spaceObjectContainer = spaceObjectContainer;

            if (spaceObjectContainer.PlanetsData == null || spaceObjectContainer.PlanetsData.Length == 0)
                    return;

               initialize = true;
        }

        private void FixedUpdate()
        {
            if (!initialize)
                return;

            for (int i = 0; i < _spaceObjectContainer.PlanetsData.Length; i++)
            {
                PlanetData data = _spaceObjectContainer.PlanetsData[i];

                if (data.Lifes <= 0)
                    continue;

                data.PlanetTransform.localPosition = GetNewPlanetPosition(data);
                RotatePlanet(data);
            }
        }

        private Vector3 GetNewPlanetPosition(PlanetData data)
        {
            if (data.OrbitSpeed < 0.1f)
                data.OrbitSpeed = 0.1f;

            float orbitSpeed = 1f / data.OrbitSpeed;
            data.OrbitProgress += Time.deltaTime * orbitSpeed;
            data.OrbitProgress %= 1f;
            Vector2 orbitPosition = _movementType.Evaluate(data);
            return new Vector3(orbitPosition.x, 0, orbitPosition.y);
       }

        private void RotatePlanet(PlanetData data)
        {
            data.PlanetTransform.transform.Rotate(Vector3.up, data.AxisSpeed);
        }*/
    }
}