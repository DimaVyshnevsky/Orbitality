using System;
using System.Collections.Generic;
using UnityEngine;
using star_system;

namespace physics
{
    public class GravitySystem : MonoBehaviour
    {
        [SerializeField] private EnvironmentCreator _planetContainer;

        private List<Transform> spaceObjects = new List<Transform>();
        private object lockObj = new object();

        private static GravitySystem _instance;
        public static GravitySystem Instance => _instance;

        //todo: calculate interactions
        //todo: add sun gravity
        //todo: calculation if launch from AI planet

        public void Awake()
        {
            _instance = this;
        }

        public Vector3 CorrectMovement(Vector3 objectPosition, Vector3 movementDirection)
        {
            lock(lockObj)
            {
                Vector3 updatedDirection = movementDirection;

                foreach (var planet in _planetContainer.Planets)
                {
                    PlanetConfig config = planet.Data;

                    if (config.PlayerPlanet)
                        continue;

                    Vector3 planetPosition = planet.transform.position;
                    float distance = Vector3.Distance(objectPosition, planetPosition);

                    if (distance > config.InfluenceGravityRadius)
                        continue;

                    //calculate force
                    float coef = (1f / config.InfluenceGravityRadius) * distance;
                    coef = config.GravityForcePerDistance.Evaluate(coef);
                    float force = config.Gravity * coef;

                    //calculate planet vector
                    Vector3 directionToPlanet = planetPosition - objectPosition;
                    updatedDirection += Vector3.Normalize(directionToPlanet) * force;
                }

                return updatedDirection;
            }
        }
    }
}